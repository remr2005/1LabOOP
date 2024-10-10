using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        private int count_it = 0;
        private decimal guess; 
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

        // Кнопка для следующей итерации
        private void Button_Next_Iteration(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumberBox.Text)) return;
            if (string.IsNullOrEmpty(ApproxBox.Text)) this.guess = approximation(decimal.Parse(NumberBox.Text));
            ApproxBox.Text = this.guess.ToString();
            decimal it = iteration(this.guess, Decimal.Parse(NumberBox.Text));
            if (Math.Abs(this.guess - it) > 0.00000000000000000000000000000001m)
            {
                this.count_it++;
                Counnt_iterations_Box.Text = this.count_it.ToString();
                hange.Text = Math.Abs(this.guess - it).ToString();
                Result.Text = it.ToString();
                this.guess = it;
            }
        }

        // кнопка для нахождения апроксимации
        private void Button_generate_approximation(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumberBox.Text)) return;
            this.guess = approximation(decimal.Parse(NumberBox.Text));
            ApproxBox.Text = this.guess.ToString();
        
        }
        // Если пользователь изменил число
        private void NumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.count_it = 0;
        }

        /// <summary>
        /// Handles the PreviewTextInput event for the TxtBox control.
        /// This method restricts user input to certain characters.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        /// <summary>
        /// Handles the PreviewTextInput event for the TxtBox2 control.
        /// This method restricts user input to certain characters.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TxtBox_PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            // если пользователь вводит что угодно кроме "0123456789-," или
            // пользователь вводит - и при этом строка не пустая или
            // пользователь вводит запятую когда строка пустая или когда уже содержит ,
            // отменить ввод
            if (!"0123456789,".Contains(e.Text) || (e.Text == "," && (ApproxBox.Text.Length == 0 || ApproxBox.Text.Contains(","))))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the PreviewKeyDown event for the InputTextBox control.
        /// This method prevents the user from entering a space character.
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

        private void Button_Click_Full_Calculate(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumberBox.Text)) return;
            if (string.IsNullOrEmpty(ApproxBox.Text)) this.guess = approximation(decimal.Parse(NumberBox.Text));
            ApproxBox.Text = this.guess.ToString();
            decimal it = iteration(this.guess, Decimal.Parse(NumberBox.Text));
            while (Math.Abs(this.guess - it) > 0.00000000000000000000000000000001m)
            {
                this.count_it++;
                this.guess = it;
                it = iteration(this.guess, Decimal.Parse(NumberBox.Text));
            }
            Counnt_iterations_Box.Text = this.count_it.ToString();
            hange.Text = Math.Abs(this.guess - it).ToString();
            Result.Text = it.ToString();
        }
    }
}
