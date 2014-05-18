namespace Bosphorus.Common.Clr.Enum
{
    public partial class Enumeration<TId>
    {
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Enumeration<TId> left, Enumeration<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enumeration<TId> left, Enumeration<TId> right)
        {
            return !Equals(left, right);
        }
    }
}
