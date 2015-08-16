using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosphorus.Common.Core.Call
{
    public class CallInvoker: ICallListener
    {
        public event EventHandler<EventArgs> BeforeCall;

        public event EventHandler<EventArgs> AfterCall;

        public CallInvoker()
        {
            BeforeCall += delegate { };
            AfterCall += delegate { };
        }

        public void InvokeBeforeCall()
        {
            BeforeCall(this, new EventArgs());
        }

        public void InvokeAfterCall()
        {
            AfterCall(this, new EventArgs());
        }
    }
}
