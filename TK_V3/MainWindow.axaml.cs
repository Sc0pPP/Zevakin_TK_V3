using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TK_V3;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Power_Tok.IsChecked = true;
        Power_Tok.IsCheckedChanged += OnRadioChanged;
        Napr.IsCheckedChanged += OnRadioChanged;
        Sopr.IsCheckedChanged += OnRadioChanged;
    }

    private void OnRadioChanged(object? sender, RoutedEventArgs e)
    {
        if (Label1 == null || Label2 == null || Output == null) return;

        if (Power_Tok.IsChecked == true)
        {
            Label1.Text = "Напряжение(Вольт)";
            Label2.Text = "Сопротивление(ОМ)";
            Output.Text = "Сила Тока=";
        }
        else if (Napr.IsChecked == true)
        {
            Label1.Text = "Сила тока(Ампер)";
            Label2.Text = "Сопротивление(ОМ)";
            Output.Text = "Напряжение=";
        }
        else if (Sopr.IsChecked == true)
        {
            Label1.Text = "Напряжение(Вольт)";
            Label2.Text = "Сила тока(Ампер)";
            Output.Text = "Сопротивление=";
        }
    }

    // ===== Публичные методы для вычислений =====

    public static bool TryCalcCurrent(string input1, string input2, out double result, out string error)
    {
        result = 0; error = "";
        if (!double.TryParse(input1, out double val1))
        {
            error = "Ошибка: некорректное значение в первом поле"; return false;
            
        }

        if (!double.TryParse(input2, out double val2))
        {
            error = "Ошибка: некорректное значение во втором поле"; return false;
            
        }

        if (val2 == 0)
        {
            error = "Ошибка: сопротивление не может быть равно нулю"; return false;
            
        }
        result = val1 / val2;
        return true;
    }

    public static bool TryCalcVoltage(string input1, string input2, out double result, out string error)
    {
        result = 0; error = "";
        if (!double.TryParse(input1, out double val1))
        {
            error = "Ошибка: некорректное значение в первом поле"; return false;
            
        }

        if (!double.TryParse(input2, out double val2))
        {
            error = "Ошибка: некорректное значение во втором поле"; return false;
            
        }
        result = val1 * val2;
        return true;
    }

    public static bool TryCalcResistance(string input1, string input2, out double result, out string error)
    {
        result = 0; error = "";
        if (!double.TryParse(input1, out double val1))
        {
            error = "Ошибка: некорректное значение в первом поле"; return false;
            
        }

        if (!double.TryParse(input2, out double val2))
        {
            error = "Ошибка: некорректное значение во втором поле"; return false;
            
        }

        if (val2 == 0)
        {
            error = "Ошибка: сила тока не может быть равна нулю"; return false;
            
        }
        result = val1 / val2;
        return true;
    }

    // ===== Кнопка вызывает те же методы =====

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Power_Tok.IsChecked == true)
        {
            if (TryCalcCurrent(Input1.Text!, Input2.Text!, out double res, out string err))
            {
                Output.Text = $"Сила Тока= {res:F4} А";
            }
            else
            {
                Output.Text = err;
            }
        }
        else if (Napr.IsChecked == true)
        {
            if (TryCalcVoltage(Input1.Text!, Input2.Text!, out double res, out string err))
            {
                Output.Text = $"Напряжение= {res:F4} В";
            }
            else
            {
                Output.Text = err;
            }
        }
        else if (Sopr.IsChecked == true)
        {
            if (TryCalcResistance(Input1.Text!, Input2.Text!, out double res, out string err))
            {
                Output.Text = $"Сопротивление= {res:F4} Ом";
            }
            else
            {
                Output.Text = err;
            }
        }
    }
}