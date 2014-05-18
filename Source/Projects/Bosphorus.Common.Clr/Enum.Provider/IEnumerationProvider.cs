using System.Collections.Generic;

namespace Bosphorus.Common.Clr.Enum.Provider
{
    public interface IEnumerationProvider<TEnumeration>
    {
        IList<TEnumeration> GetAll();
    }
}
