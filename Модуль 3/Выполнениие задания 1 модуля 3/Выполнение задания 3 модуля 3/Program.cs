using System;

//Делегат для выполнения задачи
delegate void TaskDelegate(string taskName);

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите название задачи: ");
        string task = Console.ReadLine();

        Console.WriteLine("Выберите действие: ");
        Console.WriteLine("1 - отправить уведомление");
        Console.WriteLine("2 - записать журнал");
        int choice = int.Parse(Console.ReadLine());

        // Выбираем делегат в зависимости от выбора пользователя
        TaskDelegate action;

        if (choice == 1)
            action = SendNotification;
        else
            action = WriteToLog;

        // Выполняем задачу через делегат
        action(task);
    }

    // Метод отправки уведомления
    static void SendNotification(string task)
    {
        Console.WriteLine($"Уведомление: задача \"{task}\" выполнена.");
    }

    // Метод записи в журнал
    static void WriteToLog(string task)
    {
        Console.WriteLine($"Журнал: задача \"{task}\" записана.");
    }
}