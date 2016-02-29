﻿using Bosphorus.Common.Api.Enum;

namespace Bosphorus.Common.Application
{
    public class Perspective: Enumeration
    {
        public readonly static Perspective Null = new Perspective { Id = 1 };
        public readonly static Perspective Debug = new Perspective { Id = 2 };
        public readonly static Perspective Release = new Perspective { Id = 4 };
    }
}
