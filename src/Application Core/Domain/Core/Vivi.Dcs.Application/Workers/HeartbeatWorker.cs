using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.NetworkInformation;
using Vivi.Dcs.Contracts.Requests;
using Vivi.SharedKernel.Contracts.Queue;

namespace Vivi.Dcs.Application.Workers;

public class HeartbeatWorker : BackgroundService
{
    protected readonly ISubscriber<AsprtuVerify> _queueSubscriber;
    protected readonly IPublisher<AsprtuVerify> _queuePublisher;

    private readonly ILogger<HeartbeatWorker> _logger;

    private readonly TimeSpan _timeout = TimeSpan.FromSeconds(60);

    public HeartbeatWorker(
        IQueueFactory<AsprtuVerify> queueFactory,
        ILogger<HeartbeatWorker> logger

        )
    {
        _queueSubscriber = queueFactory.CreateSubscriber();
        _queuePublisher = queueFactory.CreatePublisher();
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Heartbeat monitor started.");
        var probeTasks = new List<Task>();
        _queueSubscriber.Observable?.Subscribe(options =>
        {
            Task? probeTask = null;
            probeTask = Task.Run(async () =>
            {
                try
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        if (!await TryProbeAsync(options, stoppingToken))
                        {
                            _logger.LogWarning($"Service {options.AppId} is considered dead.");
                            Rebuild(item => item.AppId != options.AppId);
                            break;
                        }
                        await Task.Delay(_timeout, stoppingToken);
                    }
                }
                finally
                {
                    // 任务结束时，从列表中移除自身
                    lock (probeTasks)
                    {
                        probeTasks.Remove(probeTask);
                    }
                }
            }, stoppingToken);

            lock (probeTasks)
            {
                probeTasks.Add(probeTask);
            }
        }, stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            Task[] tasksCopy;
            lock (probeTasks)
            {
                tasksCopy = [.. probeTasks];
            }
            if (tasksCopy.Length == 0)
            {
                // 避免空转
                await Task.Delay(100, stoppingToken);
            }
            await Task.WhenAll(tasksCopy);
        }
    }

    /// <summary>
    /// 异步探测指定服务的注册接口是否可用
    /// </summary>
    /// <param name="verify">包含地址和应用ID的验证对象</param>
    /// <param name="cancellationToken">取消令牌，支持取消操作</param>
    /// <returns>返回是否成功探测到服务（HTTP请求成功）</returns>
    private async Task<bool> TryProbeAsync(AsprtuVerify verify, CancellationToken cancellationToken = default)
    {
        using var ping = new Ping();

        try
        {
            var replyTask = ping.SendPingAsync(verify.Address, 1000);
            var reply = await replyTask;
            return reply.Status == IPStatus.Success;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 根据条件筛选队列中的元素，将满足条件的元素重新入队到目标队列
    /// </summary>
    /// <param name="predicate">判断元素是否满足条件的委托</param>
    /// <exception cref="ArgumentNullException">当传入的委托为空时抛出异常</exception>
    private void Rebuild(Predicate<AsprtuVerify> predicate)
    {
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in _queueSubscriber.DequeueAll())
        {
            if (predicate(item))
            {
                _queuePublisher.TryEnqueue(item);
            }
        }
    }
}