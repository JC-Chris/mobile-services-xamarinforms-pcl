using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace xamarinpclshared
{
    public class ToDosViewModel : INotifyPropertyChanged
    {
        public ToDosViewModel()
        {
            ToDos = new ObservableCollection<ToDoViewModel>();

            this.RefreshCommand = new Command(async(nothing) => {
                var incomplete = await Common.GetIncompleteItems().ToListAsync();
                ToDos.Clear();
                foreach(var item in incomplete)
                    ToDos.Add(new ToDoViewModel { ToDoItem = item });
            });

            this.AddCommand = new Command<string>(async (nothing) => 
            {
                var newToDo = new ToDoItem { Text = NewToDoText };
                await Common.MobileService.GetTable<ToDoItem>().InsertAsync(newToDo);
                NewToDoText = string.Empty;
                ToDos.Add(new ToDoViewModel { ToDoItem = newToDo });
            });
        }
        public ICommand RefreshCommand { get; set; }
        public ICommand AddCommand { get; set; }


        public ObservableCollection<ToDoViewModel> ToDos{ get; set; }

        private string _newToDoText;
        public string NewToDoText 
        { 
            get { return _newToDoText; } 
            set 
            { 
                _newToDoText = value;
                OnPropertyChanged("NewToDoText");
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
        
    public class ToDoViewModel : INotifyPropertyChanged
    {
        private ToDoItem _toDoItem;
        public ToDoItem ToDoItem
        { 
            get{ return _toDoItem; } 
            set
            {
                _toDoItem = value;
                _toDoItem.PropertyChanged += async (sender, e) => 
                {
                    if (e.PropertyName == "Complete")
                        await Common.MobileService.GetTable<ToDoItem>().UpdateAsync(_toDoItem);
                };
                OnPropertyChanged("ToDoItem"); 
            }
        }
        public ICommand CompleteCommand { get; set; }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
