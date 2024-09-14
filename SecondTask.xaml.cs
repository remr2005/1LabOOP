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
using System.Windows.Shapes;
using static _1LabOOP.perevod;

namespace _1LabOOP
{
    /// <summary>
    /// Логика взаимодействия для SecondTask.xaml
    /// </summary>
    public partial class SecondTask : Window
    {
        public SecondTask()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Здесь можно добавить логику, которая выполнится при нажатии кнопки
            _1LabOOP.MainWindow secondWindow = new _1LabOOP.MainWindow();
            secondWindow.Show();
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            // Здесь можно добавить логику, которая выполнится при нажатии кнопки
            _1LabOOP.MainWindow secondWindow = new _1LabOOP.MainWindow();
            secondWindow.Show();
        }
        private void TxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // если пользователь вводит что угодно кроме "0123456789-" или
            // пользователь вводит - и при этом строка не пустая
            // отменить ввод
            if (!"IVXCLDM".Contains(e.Text) || (e.Text == "-" && TxtBox.Text.Length != 0))
            {
                e.Handled = true;
            }
        }
        // Когда содержимое TextBox меняется
        private void TxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Label_Rome.Content = remove_rome(TxtBox.Text); 
        }
        // к сожалению PrewiewTextInput не обрабатывает не символьные клавиши, пробел в том числе, поэтому что бы пользователь не мог ввести пробел испоьзуется PrewiewKeyDown
        private void InputTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Проверяем, нажата ли клавиша пробела
            if (e.Key == Key.Space)
            {
                // Если пробел, то запрещаем ввод
                e.Handled = true;
            }
        }
    }
}
