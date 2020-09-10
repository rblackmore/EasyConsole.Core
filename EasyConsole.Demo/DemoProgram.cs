using System;
using System.Collections.Generic;
using System.Text;

using EasyConsole.Demo.Pages;

namespace EasyConsole.Demo
{
    public class DemoProgram : AppManager
    {
        public DemoProgram() 
            : base("EasyConsole.Core Demo", true)
        {
            AddPage(new MainPage(this));
        }
    }
}
