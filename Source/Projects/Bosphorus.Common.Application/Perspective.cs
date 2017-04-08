using Bosphorus.Common.Api.Enum;

namespace Bosphorus.Common.Runtime
{
    public class Perspective: Enumeration
    {
        public static readonly Perspective Null = new Perspective { Id = 1 };
        public static readonly Perspective Debug = new Perspective { Id = 2 };
        public static readonly Perspective Release = new Perspective { Id = 4 };
    }
}
