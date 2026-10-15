using System;

namespace Выполнение_задания_5_модуля_5
{
    // Класс деления
    public class Division : Operation
    {
        public override double Calculate(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль невозможно!");
            return a / b;
        }
    }
}