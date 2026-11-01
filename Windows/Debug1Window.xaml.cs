using Frosty.Controls;
using Microsoft.Scripting.Hosting.Shell;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace IronPythonPlugin.Windows
{
    /// <summary>
    /// Interaction logic for Debug1Window.xaml
    /// </summary>
    public partial class IronPythonManagerWindow : FrostyDockableWindow
    {
        public Debug1Window()
        {
            InitializeComponent();

            Python.Interpreter.Initialize();

            Binding CmdBinding = new Binding
            {
                Source = Python.Interpreter.CommandLineModel,
                Path = new PropertyPath("CommandLine"),
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            BindingOperations.SetBinding(cmd, TextBox.TextProperty, CmdBinding);

        }

        private void cmd_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmd.IsFocused)
                cmd.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
            cmd.ScrollToEnd();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Python.Interpreter.ExecuteString(input.Text);
        }
    }
}
