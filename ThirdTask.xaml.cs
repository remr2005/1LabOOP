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
    /// Логика взаимодействия для ThirdTask.xaml
    /// </summary>
    public partial class ThirdTask : Window
    {
        public ThirdTask()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _1LabOOP.ThirdTask secondWindow = new _1LabOOP.ThirdTask();
            secondWindow.Show();
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            _1LabOOP.MainWindow secondWindow = new _1LabOOP.MainWindow();
            secondWindow.Show();
        }
        // Для числового textbox
        private void TxtBox_PreviewTextInput_Num(object sender, TextCompositionEventArgs e)
        {
            // если пользователь вводит что угодно кроме "0123456789-," или
            // пользователь вводит - и при этом строка не пустая или
            // пользователь вводит запятую когда строка пустая или когда уже содержит ,
            // отменить ввод
            if (!"0123456789,".Contains(e.Text) || (e.Text == "," && (NumberBox.Text.Length == 0 || NumberBox.Text.Contains(","))))
            {
                e.Handled = true;
            }
        }
        // Для точности
        private void TxtBox_PreviewTextInput_t(object sender, TextCompositionEventArgs e)
        {
            // если пользователь вводит что угодно кроме "0123456789-," или
            // пользователь вводит - и при этом строка не пустая или
            // пользователь вводит запятую когда строка пустая или когда уже содержит ,
            // отменить ввод
            if (!"0123456789,".Contains(e.Text) || (e.Text == "," && (T_box.Text.Length == 0 || T_box.Text.Contains(","))))
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

        private void NumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(T_box.Text) || string.IsNullOrEmpty(NumberBox.Text)) { Answer_Label.Content = ""; }
            else
            {
                try
                {
                    decimal num = Decimal.Parse(NumberBox.Text);
                    decimal t = Decimal.Parse(T_box.Text);
                    Answer_Label.Content = my_sqrt(num,t ).ToString();
                }
                catch { Answer_Label.Content = ""; }

            }
        }
    }
}
