using System;
using System.Collections.Generic;
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

namespace Filip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();

            Controller.SetCanvas(CanvasSimulation);
            RefreshCommandsListBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Controller.FilipRobot.Step();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Controller.FilipRobot.Turn();
        }

        private void ButtonCommandSave_Click(object sender, RoutedEventArgs e)
        {
            CommandsManager.AddCommand(TextBoxEditor.Text.ToUpper());
            RefreshCommandsListBox();
        }

        private void ButtonCommandExecute_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshCommandsListBox()
        {
            ListBoxCommands.Items.Clear();

            foreach (string item in CommandsManager.GetAllCommandsNames())
            {
                ListBoxCommands.Items.Add(item);
            }
        }

        private void ListBoxCommands_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBoxCommands.SelectedItem != null)
            {
                string commandName = ListBoxCommands.SelectedItem.ToString();
                CommandsManager.ExecuteCommand(commandName);
            }
        }
    }
}
