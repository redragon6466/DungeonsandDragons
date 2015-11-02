using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDSim.UI.ViewModel
{
    public abstract class ViewModelBase : NotificationBase, IDisposable
    {
        protected ViewModelBase()
        {
        }

        protected override void OnDispose()
        {
        }
    }
}
