using System;

namespace Выполнение_задания_5_модуля_5
{
    // Базовый абстрактный класс для всех операций
    public abstract class Operation
    {
        // Абстрактный метод — каждая операция реализует по-своему
        public abstract double Calculate(double a, double b);
    }
}