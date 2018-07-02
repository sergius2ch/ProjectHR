using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIControls.Utils
{
    public class NotifyObservableCollection<T> : ObservableCollection<T>
    {
        public event Action Changed = delegate { };


        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            Changed();
            base.OnCollectionChanged(e);
        }
    }
}
