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
    /*
    Неявные преобразования:

    byte    -> short, ushort, int, uint, long, ulong, float, double, decimal 
    sbyte   -> short, int, long, float, double, decimal 
    short   -> int, long, float, double, decimal 
    ushort  -> int, uint, long, ulong, float, double, decimal
    int     -> long, float, double, decimal
    uint    -> long, ulong, float, double, decimal
    long    -> float, double, decimal
    ulong   -> float, double, decimal
    float   -> double
    char    -> ushort, int, uint, long, ulong, float, double, decimal

    Явные преобразования:

    byte   -> short, ushort, int, uint, long, ulong, float, double, decimal 
    sbyte  -> short, int, long, float, double, decimal 
    short  -> int, long, float, double, decimal 
    ushort -> int, uint, long, ulong, float, double, decimal
    int    -> long, float, double, decimal
    uint   -> long, ulong, float, double, decimal
    long   -> float, double, decimal
    ulong  -> float, double, decimal
    float  -> double
    char   -> ushort, int, uint, long, ulong, float, double, decimal
    */

    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
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
            if (!"0123456789-,".Contains(e.Text) || (e.Text == "-" && TxtBox.Text.Length != 0) || (e.Text == "," && (TxtBox.Text.Length == 0 || TxtBox.Text.Contains(","))))
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

        /// <summary>
        /// Handles the Click event for the button control.
        /// This method opens the second task window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Здесь можно добавить логику, которая выполнится при нажатии кнопки
            _1LabOOP.SecondTask secondWindow = new _1LabOOP.SecondTask();
            secondWindow.Show();
        }
    }
}
