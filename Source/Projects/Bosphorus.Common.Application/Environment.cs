using Bosphorus.Common.Api.Enum;

namespace Bosphorus.Common.Runtime
{
    public class Environment: Enumeration
    {
        public static readonly Environment Null = new Environment {Id = 1};
        public static readonly Environment Local = new Environment { Id = 2 };
        public static readonly Environment Development = new Environment { Id = 3 };
        public static readonly Environment Test = new Environment { Id = 4 };
        public static readonly Environment PreProduction = new Environment { Id = 5 };
        public static readonly Environment Production = new Environment { Id = 6 };
    }
}
