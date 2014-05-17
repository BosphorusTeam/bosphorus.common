using System;
using System.Diagnostics;

namespace Bosphorus.Common.Clr.Enum
{
    [Serializable]
    [DebuggerDisplay("{Name} - {Id}")]
    public abstract partial class Enumeration<TEnumeration, TId>
        where TEnumeration : Enumeration<TEnumeration, TId>, new()
    {
        public virtual TId Id { get; set; }
        public virtual string Name { get; set; }

        public override sealed string ToString()
        {
            return Name;
        }

   }

    [Serializable]
    [DebuggerDisplay("{Name} - {Id}")]
    public abstract class Enumeration<TEnumeration> : Enumeration<TEnumeration, int>
        where TEnumeration : Enumeration<TEnumeration>, new()
    {
    }
}
