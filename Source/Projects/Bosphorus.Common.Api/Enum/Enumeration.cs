namespace Bosphorus.Common.Api.Enum
{
    public abstract class EnumerationBase
    {
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }

    public abstract partial class Enumeration<TId>: EnumerationBase
    {
        public virtual TId Id { get; set; }
   }

    public abstract class Enumeration : Enumeration<int>
    {
    }
}
