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
        /// <summary>
        /// Initializes a new instance of the <see cref="SecondTask"/> class.
        /// </summary>
        public SecondTask()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event for the button to open the main window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _1LabOOP.MainWindow secondWindow = new _1LabOOP.MainWindow();
            secondWindow.Show();
        }

        /// <summary>
        /// Handles the Click event for the button to open the third task window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            _1LabOOP.ThirdTask secondWindow = new _1LabOOP.ThirdTask();
            secondWindow.Show();
        }

        /// <summary>
        /// Handles the PreviewTextInput event for the TxtBox control.
        /// This method restricts user input to Roman numerals only.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // если пользователь вводит что угодно кроме "IVXCLDM" или
            // пользователь вводит - и при этом строка не пустая
            // отменить ввод
            if (!"IVXCLDM".Contains(e.Text) || (e.Text == "-" && TxtBox.Text.Length != 0))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the TextChanged event for the TxtBox control.
        /// This method converts Roman numerals to Arabic numerals.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TxtBox_TextChanged_to_arabic(object sender, TextChangedEventArgs e)
        {
            Label_Rome.Content = remove_rome(TxtBox.Text);
        }

        /// <summary>
        /// Handles the PreviewTextInput event for the Arabic number input.
        /// This method restricts user input to Arabic numerals only and ensures the value does not exceed the maximum.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TxtBox_PreviewTextInput_arabic(object sender, TextCompositionEventArgs e)
        {
            if (!"1234567890".Contains(e.Text) || (e.Text == "0" && TxtBox_arabic.Text.Length == 0) || Int32.Parse(TxtBox_arabic.Text + e.Text) > 3999)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the TextChanged event for the Arabic number input.
        /// This method converts Arabic numerals to Roman numerals.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TxtBox_TextChanged_to_rome(object sender, TextChangedEventArgs e)
        {
            // переводим в римские цифры
            Label_Arabic.Content = return_rome(TxtBox_arabic.Text);
        }

        /// <summary>
        /// Handles the PreviewKeyDown event to prevent the space character from being entered in any TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void InputTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Проверяем, нажата ли клавиша пробела
            if (e.Key == Key.Space)
            {
                // Если пробел, то запрещаем ввод
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the TextCompositionEventArgs for the Number input.
        /// This method restricts user input to Arabic numerals only.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TxtBox_Number(object sender, TextCompositionEventArgs e)
        {
            if (!"1234567890".Contains(e.Text) || (e.Text == "0" && Number_box.Text.Length == 0))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the TextChanged event for the Number input.
        /// This method converts the number to a different base.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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
            Label_number.Content = from_tenth_to(a, b);
        }
    }
}
