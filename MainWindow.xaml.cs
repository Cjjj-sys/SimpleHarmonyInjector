using SimpleInjectorLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleHarmonyInjector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private ProcessHelper processHelper = new ProcessHelper();

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            listBoxProcess.ItemsSource = null;
            processHelper.Refresh();
            listBoxProcess.ItemsSource = processHelper.ProcessList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBoxProcess.ItemsSource = processHelper.ProcessList;
        }

        private void buttonInject_Click(object sender, RoutedEventArgs e)
        {
            var injectHelper = new InjectHelper() { ProcessId = (uint)(listBoxProcess.SelectedItem as Process).Id,
                                                    AssemblyPath = "StonePlannerPatch.dll",
                                                    TypeName = "StonePlannerPatch.EndPoint",
                                                    MethodName = "Main",
            };
            try
            {
                if (injectHelper.TryInject())
                {
                    textBlockStatus.Text = "注入成功";
                }
                else
                {
                    textBlockStatus.Text = "注入失败";
                }
            }
            catch (Exception exception)
            {
                textBlockStatus.Text = $"注入失败 原因: {exception.Message}";
            }
            
        }
    }
}
