using System;
using System.Diagnostics;

namespace Bosphorus.Common.Clr.Enum
{
    public abstract class EnumerationBase
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }

    [Serializable]
    [DebuggerDisplay("{Name} - {Id}")]
    public abstract partial class Enumeration<TId>: EnumerationBase
    {
        public TId Id { get; set; }
   }

    [Serializable]
    [DebuggerDisplay("{Name} - {Id}")]
    public abstract class Enumeration : Enumeration<int>
    {
    }
}
