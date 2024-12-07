using System;

// Інтерфейс для управління розумним будинком
public interface ISmartHome
{
    void TurnOnLight();
    void TurnOffLight();
    void TurnOnAC();
    void TurnOffAC();
}

// Конкретна реалізація для розумного будинку
public class SmartHome : ISmartHome
{
    public void TurnOnLight()
    {
        Console.WriteLine("Світло вмикається.");
    }

    public void TurnOffLight()
    {
        Console.WriteLine("Світло вимикається.");
    }

    public void TurnOnAC()
    {
        Console.WriteLine("Кондиціонер вмикається.");
    }

    public void TurnOffAC()
    {
        Console.WriteLine("Кондиціонер вимикається.");
    }
}

// Інтерфейс для SMS-управління
public interface ISMSController
{
    void SendCommand(string command);
}

// Конкретна реалізація для SMS-управління
public class SMSController : ISMSController
{
    public void SendCommand(string command)
    {
        Console.WriteLine($"SMS команда отримана: {command}");
    }
}

// Адаптер для SMS управління розумним будинком
public class SmartHomeAdapter : ISMSController
{
    private readonly ISmartHome _smartHome;

    public SmartHomeAdapter(ISmartHome smartHome)
    {
        _smartHome = smartHome;
    }

    public void SendCommand(string command)
    {
        if (command.ToLower() == "включити світло")
        {
            _smartHome.TurnOnLight();
        }
        else if (command.ToLower() == "вимкнути світло")
        {
            _smartHome.TurnOffLight();
        }
        else if (command.ToLower() == "включити кондиціонер")
        {
            _smartHome.TurnOnAC();
        }
        else if (command.ToLower() == "вимкнути кондиціонер")
        {
            _smartHome.TurnOffAC();
        }
        else
        {
            Console.WriteLine("Невідома команда.");
        }
    }
}

// Головний клас для тестування
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Створення об'єкта розумного будинку
        ISmartHome smartHome = new SmartHome();

        // Створення адаптера для SMS
        ISMSController smsController = new SmartHomeAdapter(smartHome);

        // Тестування адаптера через SMS
        Console.WriteLine("Відправлення SMS команд:");

        smsController.SendCommand("включити світло");
        smsController.SendCommand("вимкнути світло");
        smsController.SendCommand("включити кондиціонер");
        smsController.SendCommand("вимкнути кондиціонер");
        smsController.SendCommand("невідома команда");
    }
}
