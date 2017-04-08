using System.Collections.Generic;

namespace Bosphorus.Common.Api.Enum.Provider
{
    public interface IEnumerationProvider<TEnumeration>
    {
        IList<TEnumeration> GetAll();
    }
}
