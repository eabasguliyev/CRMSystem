using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CrmSystem.Domain.Models;

namespace CrmSystem.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Company Company { get; set; }
        public static Employee LoggedUser { get; set; }
    }
}
