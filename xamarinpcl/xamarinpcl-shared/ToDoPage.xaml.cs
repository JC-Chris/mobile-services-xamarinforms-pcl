﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarinpclshared
{
    public partial class ToDoPage
    {
        public ToDoPage()
        {
            InitializeComponent();
            BindingContext = new ToDosViewModel();
        }
    }
}
