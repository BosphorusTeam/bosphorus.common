using Castle.Core;
using Castle.MicroKernel;

namespace Bosphorus.Common.Api.Container.Coc
{
    public class ComponentModelConvention
    {
        public IKernel Kernel { get; }
        public ComponentModel ComponentModel { get; }

        public ComponentModelConvention(IKernel kernel, ComponentModel model)
        {
            this.Kernel = kernel;
            this.ComponentModel = model;
        }
    }
}