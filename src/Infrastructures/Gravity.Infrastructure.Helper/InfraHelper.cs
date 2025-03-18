using Gravity.Infrastructure.Helper.Internal;
using Gravity.Infrastructure.Helper.Internal.Encrypt;

namespace Gravity.Infrastructure.Helper;

public static class InfraHelper
{
    static InfraHelper()
    {
        Encrypt = new EncryptProivder();
        HashConsistent = new HashConsistentGenerater();
        Accessor = new Accessor();
    }

    public static EncryptProivder Encrypt { get; private set; }

    public static HashConsistentGenerater HashConsistent { get; private set; }

    public static Accessor Accessor { get; private set; }
}