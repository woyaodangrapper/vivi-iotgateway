namespace Vivi.Dcs.Contracts.DTOs;

public class AreaTreeNodeDTO : AreaRequestDTO
{
    public List<AreaTreeNodeDTO>? Children { get; set; } = [];

    /// <summary>
    /// 扁平化为列表
    /// </summary>
    /// <returns></returns>
    public List<AreaDTO> Flatten()
    {
        var result = new List<AreaDTO>();

        // 递归遍历树的内部函数
        void Traverse(List<AreaTreeNodeDTO> nodes, Guid? parentId, int currentLevel)
        {
            foreach (var node in nodes)
            {
                Guid? currentPid = parentId ?? node.Pid; // 适配更新根节点被覆盖为null问题
                result.Add(new AreaDTO()
                {
                    Id = node.Id,
                    Pid = currentPid,
                    Name = node.Name ?? string.Empty,
                    Code = node.Code,
                    Type = node.Type,
                    Level = currentLevel,
                    Position = node.Position,
                    BlockCode = node.BlockCode
                });

                if (node.Children != null && node.Children.Count > 0)
                {
                    Traverse(node.Children, node.Id, currentLevel + 1);
                }
            }
        }

        // 调用递归方法
        Traverse([this], null, 0);  // 初始的 level 为 0
        return result;
    }

    /// <summary>
    /// 递归构建树形结构
    /// </summary>
    /// <param name="children"></param>
    public void Build(List<AreaTreeNodeDTO> children)
    {
        var childNodes = children.Where(n => n.Pid == Id).ToList();
        foreach (var child in childNodes)
        {
            var childNode = new AreaTreeNodeDTO
            {
                Id = child.Id,
                Name = child.Name,
                Code = child.Code,
                Type = child.Type,
                Level = child.Level,
                Position = child.Position,
                BlockCode = child.BlockCode,
                Children = [],
                Pid = child.Pid
            };
            Children.Add(childNode);
            childNode.Build(children);
        }
    }
}