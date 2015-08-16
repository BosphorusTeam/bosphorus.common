﻿using Bosphorus.Common.Clr.Enum;

namespace Bosphorus.Common.Core.Application
{
    public class Host : Enumeration
    {
        public readonly static Host Null = new Host { Id = 1 };
        public readonly static Host WinForm = new Host { Id = 2 };
        public readonly static Host Console = new Host { Id = 3 };
        public readonly static Host Test = new Host { Id = 4 };
        public readonly static Host IIS = new Host { Id = 5 };
        public readonly static Host WCF = new Host { Id = 6 };
    }
}
