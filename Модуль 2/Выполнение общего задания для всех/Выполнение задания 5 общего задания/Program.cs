using System;

// Класс-аргумент события — передаёт данные о температуре
class TemperatureEventArgs : EventArgs
{
    public int Temperature { get; set; }
    public TemperatureEventArgs(int t) { Temperature = t; }
}

// Класс-датчик температуры
class TemperatureSensor
{
    // Событие, на которое можно подписаться
    public event EventHandler<TemperatureEventArgs> TemperatureChanged;

    private int temperature;

    // Свойство температуры
    public int Temperature
    {
        get { return temperature; }
        set
        {
            // Если температура изменилась — генерируем событие
            if (temperature != value)
            {
                temperature = value;
                OnTemperatureChanged();
            }
        }
    }

    // Метод генерации события
    protected void OnTemperatureChanged()
    {
        // Проверяем, есть ли подписчики, и вызываем событие
        if (TemperatureChanged != null)
            TemperatureChanged(this, new TemperatureEventArgs(temperature));
    }
}

// Класс-термостат — подписывается на событие
class Thermostat
{
    // Обработчик события
    public void OnTemperatureChanged(object sender, TemperatureEventArgs e)
    {
        if (e.Temperature < 18)
            Console.WriteLine($"Температура {e.Temperature}°C — отопление ВКЛЮЧЕНО");
        else
            Console.WriteLine($"Температура {e.Temperature}°C — отопление ВЫКЛЮЧЕНО");
    }
}

class Program
{
    static void Main()
    {
        // Создаём датчик и термостат
        TemperatureSensor sensor = new TemperatureSensor();
        Thermostat thermostat = new Thermostat();

        // Подписываемся на событие: при изменении температуры вызовется OnTemperatureChanged
        sensor.TemperatureChanged += thermostat.OnTemperatureChanged;

        // Изменяем температуру — срабатывает событие, термостат реагирует
        sensor.Temperature = 20;
        sensor.Temperature = 15;
        sensor.Temperature = 10;
        sensor.Temperature = 22;
    }
}