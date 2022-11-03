using Fractals;
using System.Globalization;

string GetCurrentTime()
    => DateTime.Now.ToString(new CultureInfo("ru-RU"));

Console.WriteLine($"[{GetCurrentTime()}] Запуск приложения");
// тут из json настроички подгружаем
// тут несколько потоков, один следит за настроичками
// другой фракталы показывает

// ну и по хорошему потом добавить визуализацию и формирование данных в разные потоки

// ну и куду хотел подвезти

// ну и курент лэнгдвич тоже необходимо
new Window().Start();
Console.WriteLine($"[{DateTime.Now.ToString(new CultureInfo("ru-RU"))}] Запуск приложения");
Console.WriteLine($"[{GetCurrentTime()}] Остановка приложения");