namespace Bosphorus.Common.Clr.Enum
{
    public partial class Enumeration<TEnumeration, TId>
    {
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Enumeration<TEnumeration, TId> left, Enumeration<TEnumeration, TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enumeration<TEnumeration, TId> left, Enumeration<TEnumeration, TId> right)
        {
            return !Equals(left, right);
        }
    }
}
