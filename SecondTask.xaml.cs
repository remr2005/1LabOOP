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
            _1LabOOP.MainWindow secondWindow = new _1LabOOP.MainWindow();
            secondWindow.Show();
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            _1LabOOP.MainWindow secondWindow = new _1LabOOP.MainWindow();
            secondWindow.Show();
        }
        // Проверка на ввод только римских цифр
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
        // Перевод а арабские цифры
        private void TxtBox_TextChanged_to_arabic(object sender, TextChangedEventArgs e)
        {
            Label_Rome.Content = remove_rome(TxtBox.Text);
        }
        // Проверка на ввод только арабских цифр цифр, а так же на не превышенее максимума
        private void TxtBox_PreviewTextInput_arabic(object sender, TextCompositionEventArgs e)
        {
            if (!"1234567890".Contains(e.Text) || (e.Text == "0" && TxtBox_arabic.Text.Length == 0) || Int32.Parse(TxtBox_arabic.Text + e.Text)>3999)
            {
                e.Handled = true;
            }
        }
        // когда текст в textbox меняется
        private void TxtBox_TextChanged_to_rome(object sender, TextChangedEventArgs e)
        {
            // переводим в римские цифры
            Label_Arabic.Content = return_rome(TxtBox_arabic.Text);
        }
        // к сожалению PrewiewTextInput не обрабатывает не символьные клавиши, пробел в том числе, поэтому что бы пользователь не мог ввести пробел испоьзуется PrewiewKeyDown
        // блокирует пробело во все TextBox-ах
        private void InputTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Проверяем, нажата ли клавиша пробела
            if (e.Key == Key.Space)
            {
                // Если пробел, то запрещаем ввод
                e.Handled = true;
            }
        }
        // Перевод из десятичной в любую другую
        private void TxtBox_Number(object sender, TextCompositionEventArgs e)
        {
            if (!"1234567890".Contains(e.Text) || (e.Text == "0" && Number_box.Text.Length == 0))
            {
                e.Handled = true;
            }
        }
        // Переводим число
        private void TxtBox_Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Возвращаю пустую строку если основание или число пусты
            if (string.IsNullOrEmpty(Base_Box.Text) || string.IsNullOrEmpty(Number_box.Text))
            {
                Label_number.Content = "";
                return;
            }
            // перевожу основание и число в int
            int a = Int32.Parse(Number_box.Text);
            int b = Int32.Parse(Base_Box.Text);
            Label_number.Content = from_tenth_to(a,b);
        }

    }
}
