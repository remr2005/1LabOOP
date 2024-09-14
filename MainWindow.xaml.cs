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
using _1LabOOP;

namespace _1LabOOP
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

        private void TxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // если пользователь вводит что угодно кроме "0123456789-," или
            // пользователь вводит - и при этом строка не пустая или
            // пользователь вводит запятую когда строка пустая или когда уже содержит ,
            // отменить ввод
            if (!"0123456789-,".Contains(e.Text) || (e.Text == "-" && TxtBox.Text.Length != 0) || (e.Text == "," && (TxtBox.Text.Length == 0 || TxtBox.Text.Contains(","))))
            {
                e.Handled = true;
            }
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Здесь можно добавить логику, которая выполнится при нажатии кнопки
            _1LabOOP.SecondTask secondWindow = new _1LabOOP.SecondTask();
            secondWindow.Show();

        }
    }
}
