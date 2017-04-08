using Bosphorus.Common.Api.Exceptionn;

namespace Bosphorus.Common.Api.Enum.Provider
{
    public class EnumerationNotExistsBosphorusException<TId> : BosphorusException
    {
        private const string MessageFormat = "Enumeration not found";

        public EnumerationNotExistsBosphorusException(TId id)
            : base(ExceptionMessage.Build(MessageFormat).Add("Id", id))
        {
        }

        public EnumerationNotExistsBosphorusException(string name)
            : base(ExceptionMessage.Build(MessageFormat).Add("Name", name))
        {
        }
    }
}
