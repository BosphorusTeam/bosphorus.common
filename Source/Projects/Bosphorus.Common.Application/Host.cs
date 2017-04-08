using Bosphorus.Common.Api.Enum;

namespace Bosphorus.Common.Runtime
{
    public class Host : Enumeration
    {
        public static readonly Host Null = new Host { Id = 1 };
        public static readonly Host WinForm = new Host { Id = 2 };
        public static readonly Host Console = new Host { Id = 3 };
        public static readonly Host Test = new Host { Id = 4 };
        public static readonly Host IIS = new Host { Id = 5 };
        public static readonly Host WCF = new Host { Id = 6 };
    }
}
