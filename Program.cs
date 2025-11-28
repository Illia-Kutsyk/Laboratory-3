using System;

struct Film
{
    public string Name;
    public string Genre;
    public int Year;
    public double Price;

    public Film(string name, string genre, int year, double price)
    {
        Name = name;
        Genre = genre;
        Year = year;
        Price = price;
    }
}

class Program
{
    static void Main()
    {
        string login = "admin";
        string password = "1234";

        int attempts = 0;
        string userLogin, userPass;

        // DO-WHILE — система входу (3 спроби)
        do
        {
            Console.Write("Логін: ");
            userLogin = Console.ReadLine();

            Console.Write("Пароль: ");
            userPass = Console.ReadLine();

            if (userLogin == login && userPass == password)
            {
                Console.WriteLine("Вхід успішний!\n");
                break;
            }

            Console.WriteLine("Невірні дані! Спробуйте ще.\n");
            attempts++;

            if (attempts == 3)
            {
                Console.WriteLine("Спроби вичерпано. Програма завершується.");
                return;
            }

        } while (true);

        Film[] films = new Film[5];

        // FOR — введення фільмів
        for (int i = 0; i < films.Length; i++)
        {
            Console.WriteLine($"Фільм {i + 1}:");

            Console.Write("Назва: ");
            string name = Console.ReadLine();

            Console.Write("Жанр: ");
            string genre = Console.ReadLine();

            int year;
            while (true)
            {
                Console.Write("Рік: ");
                if (int.TryParse(Console.ReadLine(), out year)) break;
                Console.WriteLine("Помилка! Введіть число.");
            }

            double price;
            while (true)
            {
                Console.Write("Ціна: ");
                if (double.TryParse(Console.ReadLine(), out price)) break;
                Console.WriteLine("Помилка! Введіть число.");
            }

            films[i] = new Film(name, genre, year, price);
            Console.WriteLine();
        }

        bool exit = false;

        // WHILE — головне меню
        while (!exit)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1 — Показати всі фільми");
            Console.WriteLine("2 — Статистика");
            Console.WriteLine("0 — Вихід");

            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n--- Список фільмів ---");
                    for (int i = 0; i < films.Length; i++)
                        Console.WriteLine($"{films[i].Name} — {films[i].Price} грн");
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine("\n--- Статистика ---");

                    double sum = 0;
                    double min = double.MaxValue;
                    double max = double.MinValue;
                    string minName = "";
                    string maxName = "";
                    int expensive = 0;

                    for (int i = 0; i < films.Length; i++)
                    {
                        if (films[i].Price <= 0)
                            continue; // пропуск невалідних значень

                        sum += films[i].Price;

                        if (films[i].Price < min)
                        {
                            min = films[i].Price;
                            minName = films[i].Name;
                        }

                        if (films[i].Price > max)
                        {
                            max = films[i].Price;
                            maxName = films[i].Name;
                        }

                        if (films[i].Price > 100)
                            expensive++;
                    }

                    double average = sum / films.Length;

                    Console.WriteLine($"Середня ціна: {average:F2} грн");
                    Console.WriteLine($"Найдешевший: {minName} ({min} грн)");
                    Console.WriteLine($"Найдорожчий: {maxName} ({max} грн)");
                    Console.WriteLine($"Фільмів дорожче 100 грн: {expensive}\n");
                    break;

                case "0":
                    exit = true;
                    Console.WriteLine("Вихід...");
                    break;

                default:
                    Console.WriteLine("Невірний вибір!\n");
                    break;
            }
        }
    }
}