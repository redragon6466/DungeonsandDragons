using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDSim.UI.ViewModel
{
    /// <summary>
    /// Base class for all classes in the application interested
    /// notifications thru INotifyPropertyChanged.
    /// This is the base class for ModelBase and ViewModelBase.
    /// This class is abstract.
    /// </summary>
    public abstract class NotificationBase : BindableBase, IDisposable
    {
        /// <summary>
        /// Flag that indicates if property notification is suspended, true.
        /// Otherwise, false.
        /// </summary>
        private bool _suspendPropertyChanged;

        #region Public Methods and Operators

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            OnDispose();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected abstract void OnDispose();

        /// <summary>
        /// Provides PropertyChanged optimization when setting 
        /// multiple properties at once by suspending PropertyChanged 
        /// notifications. 
        /// 
        /// SuspendPropertyChanged should always have a matching call
        /// to ResumePropertyChanged.
        /// 
        /// Use this before you will be setting multiple
        /// properties at once. After all properties are set
        /// then use ResumePropertyChanged.
        /// </summary>
        protected void SuspendPropertyChanged()
        {
            _suspendPropertyChanged = true;
        }

        #endregion
    }
}

