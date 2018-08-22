using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace windowsWishlistAppGroepVM9.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private DataTemplate _template;


        public DataTemplate Template
        {
            get { return _template; }
            set { _template = value; RaisePropertyChanged("Template"); }
        }

        private DataTemplate GetTemplate()
        {
            string s = GetType().Name;
            Debug.WriteLine(s);
            return (DataTemplate)App.Current.Resources[s];
        }

        public ViewModelBase()
        {
            Template = GetTemplate();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
