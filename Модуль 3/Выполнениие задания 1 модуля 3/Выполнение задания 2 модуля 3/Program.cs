using System;

// Класс "Уведомление" с тремя событиями
class Notification
{
    // Объявляем события
    public event Action MessageSent;   // событие для сообщений
    public event Action CallMade;      // событие для звонков
    public event Action EmailSent;     // событие для писем

    // Методы, которые генерируют события
    public void SendMessage()
    {
        Console.WriteLine("Отправка сообщения...");
        MessageSent?.Invoke(); // вызов события, если есть подписчики
    }

    public void MakeCall()
    {
        Console.WriteLine("Совершение звонка...");
        CallMade?.Invoke();
    }

    public void SendEmail()
    {
        Console.WriteLine("Отправка письма...");
        EmailSent?.Invoke();
    }
}

class Program
{
    static void Main()
    {
        Notification notif = new Notification();

        // Регистрируем обработчики событий
        notif.MessageSent += () => Console.WriteLine("Сообщение доставлено!");
        notif.CallMade += () => Console.WriteLine("Звонок завершён!");
        notif.EmailSent += () => Console.WriteLine("Письмо отправлено!");

        // Вызываем события
        notif.SendMessage();
        notif.MakeCall();
        notif.SendEmail();
    }
}