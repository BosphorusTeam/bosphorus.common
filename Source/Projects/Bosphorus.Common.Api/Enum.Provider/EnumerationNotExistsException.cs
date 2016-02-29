using Bosphorus.Common.Api.Exception;

namespace Bosphorus.Common.Api.Enum.Provider
{
    public class EnumerationNotExistsException<TId> : ExceptionBase
    {
        private const string EXCEPTION_MESSAGE = "Enumeration not found";

        public EnumerationNotExistsException(TId id)
            : base(ExceptionMessage.Build(EXCEPTION_MESSAGE).Add("Id", id))
        {
        }

        public EnumerationNotExistsException(string name)
            : base(ExceptionMessage.Build(EXCEPTION_MESSAGE).Add("Name", name))
        {
        }
    }
}
