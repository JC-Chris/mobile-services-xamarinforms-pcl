using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Shared
{
    public class Common
    {
        static Common()
        {
            InitializeClient();
        }

        public static MobileServiceClient MobileService;

        public static void InitializeClient(params DelegatingHandler[] handlers)
        {
            MobileService = new MobileServiceClient(
				@"https://xamarinpcl.azure-mobile.net/",
				null,
                handlers
            );
        }

        public static IMobileServiceTableQuery<ToDoItem> GetIncompleteItems()
        {
            var toDoTable = MobileService.GetTable<ToDoItem>();
            return toDoTable.Where(item => item.Complete == false);
        }
    }

    public class ToDoItem : INotifyPropertyChanged
    {
        public string Id { get; set; }

        private string _text;
        [JsonProperty(PropertyName = "text")]
        public string Text
        { 
            get{ return _text; }
            set
            { 
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged("Text");
                }
            } 
        }

        private bool _complete;
        [JsonProperty(PropertyName = "complete")]
        public bool Complete
        { 
            get{ return _complete; }
            set
            {
                if (_complete != value)
                {
                    _complete = value;
                    OnPropertyChanged("Complete"); 
                }
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
}
