using Microsoft.VisualStudio.TestTools.UnitTesting;
using TK_V3;

namespace TK_V3.Tests;

[TestClass]
public class OhmLawTests
{
    // Тест 1: I = 10 / 5 = 2
    [TestMethod]
    public void TryCalcCurrent_10_5_Returns2()
    {
        bool ok = MainWindow.TryCalcCurrent("10", "5", out double result, out string error);
        Assert.IsTrue(ok);
        Assert.AreEqual(2.0, result, 0.0001);
    }

    // Тест 2: I при R=0 — ошибка
    [TestMethod]
    public void TryCalcCurrent_ZeroR_ReturnsFalse()
    {
        bool ok = MainWindow.TryCalcCurrent("10", "0", out double result, out string error);
        Assert.IsFalse(ok);
        Assert.AreEqual("Ошибка: сопротивление не может быть равно нулю", error);
    }

    // Тест 3: U = 3 * 4 = 12
    [TestMethod]
    public void TryCalcVoltage_3_4_Returns12()
    {
        bool ok = MainWindow.TryCalcVoltage("3", "4", out double result, out string error);
        Assert.IsTrue(ok);
        Assert.AreEqual(12.0, result, 0.0001);
    }

    // Тест 4: R = 20 / 4 = 5
    [TestMethod]
    public void TryCalcResistance_20_4_Returns5()
    {
        bool ok = MainWindow.TryCalcResistance("20", "4", out double result, out string error);
        Assert.IsTrue(ok);
        Assert.AreEqual(5.0, result, 0.0001);
    }

    // Тест 5: R при I=0 — ошибка
    [TestMethod]
    public void TryCalcResistance_ZeroI_ReturnsFalse()
    {
        bool ok = MainWindow.TryCalcResistance("20", "0", out double result, out string error);
        Assert.IsFalse(ok);
        Assert.AreEqual("Ошибка: сила тока не может быть равна нулю", error);
    }

    // Тест 6: некорректный ввод "abc"
    [TestMethod]
    public void TryCalcCurrent_InvalidInput_ReturnsFalse()
    {
        bool ok = MainWindow.TryCalcCurrent("abc", "5", out double result, out string error);
        Assert.IsFalse(ok);
        Assert.AreEqual("Ошибка: некорректное значение в первом поле", error);
    }

    // Тест 7: U = 0 * 0 = 0
    [TestMethod]
    public void TryCalcVoltage_0_0_Returns0()
    {
        bool ok = MainWindow.TryCalcVoltage("0", "0", out double result, out string error);
        Assert.IsTrue(ok);
        Assert.AreEqual(0.0, result, 0.0001);
    }
}