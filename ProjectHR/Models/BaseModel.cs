using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectHR.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        protected bool _isChanged;

        public BaseModel()
        {
            _isChanged = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
                _isChanged = true;
            }
        }
    }
}
