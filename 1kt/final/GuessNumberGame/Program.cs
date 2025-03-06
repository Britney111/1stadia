using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в игру 'Угадай число наоборот'!");

        // Ввод минимального числа диапазона
        Console.Write("Введите минимальное число диапазона (n): ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Ошибка: введено некорректное значение для минимального числа.");
            return;
        }

        // Ввод максимального числа диапазона
        Console.Write("Введите максимальное число диапазона (m): ");
        if (!int.TryParse(Console.ReadLine(), out int m))
        {
            Console.WriteLine("Ошибка: введено некорректное значение для максимального числа.");
            return;
        }

        // Проверка корректности диапазона
        if (n >= m)
        {
            Console.WriteLine("Ошибка: минимальное число должно быть меньше максимального.");
            return;
        }

        // Инструкция для игрока
        Console.WriteLine($"Загадайте число от {n} до {m} и нажмите Enter, чтобы начать.");
        Console.ReadLine();

        int attempts = 0; // Счетчик попыток
        string response;

        do
        {
            int guess = (n + m) / 2; // Текущее предполагаемое число
            attempts++;

            Console.WriteLine($"Попытка {attempts}: Программа предполагает, что вы загадали число {guess}.");
            Console.Write("Введите 'больше', 'меньше' или 'угадал': ");

            response = Console.ReadLine()?.Trim().ToLower(); // Обработка ввода

            if (response == "больше")
            {
                n = guess + 1; // Увеличиваем нижнюю границу диапазона
            }
            else if (response == "меньше")
            {
                m = guess - 1; // Уменьшаем верхнюю границу диапазона
            }
            else if (response != "угадал")
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите 'больше', 'меньше' или 'угадал'.");
            }

            // Проверка на выход за пределы диапазона
            if (n > m)
            {
                Console.WriteLine("Ошибка: диапазон чисел стал невалидным. Проверьте свои ответы.");
                return;
            }

        } while (response != "угадал");

        // Игра завершена
        Console.WriteLine($"Программа угадала ваше число {n} за {attempts} попыток!");
    }
}