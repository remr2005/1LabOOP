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
using static _1LabOOP.perevod;

namespace _1LabOOP
{
    /// <summary>
    /// Логика взаимодействия для ThirdTask.xaml
    /// </summary>
    public partial class ThirdTask : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThirdTask"/> class.
        /// </summary>
        public ThirdTask()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event for the button to open another instance of the ThirdTask window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _1LabOOP.ThirdTask secondWindow = new _1LabOOP.ThirdTask();
            secondWindow.Show();
        }

        /// <summary>
        /// Handles the Click event for the button to open the main window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            _1LabOOP.MainWindow secondWindow = new _1LabOOP.MainWindow();
            secondWindow.Show();
        }

        /// <summary>
        /// Handles the PreviewTextInput event for the numerical TextBox.
        /// This method restricts user input to digits and commas.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TxtBox_PreviewTextInput_Num(object sender, TextCompositionEventArgs e)
        {
            // если пользователь вводит что угодно кроме "0123456789," или
            // пользователь вводит запятую когда строка пустая или когда уже содержит запятую,
            // отменить ввод
            if (!"0123456789,".Contains(e.Text) || (e.Text == "," && (NumberBox.Text.Length == 0 || NumberBox.Text.Contains(","))))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the PreviewTextInput event for the precision TextBox.
        /// This method restricts user input to digits and commas.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TxtBox_PreviewTextInput_t(object sender, TextCompositionEventArgs e)
        {
            // если пользователь вводит что угодно кроме "0123456789," или
            // пользователь вводит запятую когда строка пустая или когда уже содержит запятую,
            // отменить ввод
            if (!"0123456789,".Contains(e.Text) || (e.Text == "," && (T_box.Text.Length == 0 || T_box.Text.Contains(","))))
            {
                e.Handled = true;
            }
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
        /// Handles the TextChanged event for the NumberBox.
        /// This method calculates and displays the result based on the inputs.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void NumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Проверяем, заполнены ли поля для ввода
            if (string.IsNullOrEmpty(T_box.Text) || string.IsNullOrEmpty(NumberBox.Text))
            {
                Answer_Label.Content = ""; // Если поля пусты, очищаем ответ
            }
            else
            {
                try
                {
                    // Парсим введенные значения
                    decimal num = Decimal.Parse(NumberBox.Text);
                    decimal t = Decimal.Parse(T_box.Text);
                    // Вычисляем результат и отображаем его
                    Answer_Label.Content = my_sqrt(num, t).ToString();
                }
                catch
                {
                    Answer_Label.Content = ""; // Если возникла ошибка, очищаем ответ
                }
            }
        }
    }
}
