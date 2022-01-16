using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTracking.Models
{
    public abstract class BaseEntity : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public int Id { get; set; }

        public event PropertyChangingEventHandler? PropertyChanging;
        public event PropertyChangedEventHandler? PropertyChanged;
        

        protected void OnPropertyChanging([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    // POCO (Plain Old CLR Object)
    public class Customer : BaseEntity
    {
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                OnPropertyChanging();
                firstName = value;
                OnPropertyChanged();
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName; set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
    }
}
