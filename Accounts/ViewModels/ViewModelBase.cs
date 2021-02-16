using System;

namespace Web.ViewModels
{
    public abstract class BaseViewModel : LayoutViewModel
    {
        public virtual bool ContainsVueApplication => false;

        protected BaseViewModel(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {      
        }

        protected BaseViewModel(): base()
        {
        }

    }

    public abstract class LayoutViewModel
    {
        private IServiceProvider ServiceProvider { get; }

        protected LayoutViewModel(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        protected LayoutViewModel()
        {
        }
    }
}