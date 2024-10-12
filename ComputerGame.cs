using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame
{
    
    public class ComputerGame : IGame
    {
        private int _numberToGuess;
        private int _maxAttempts;

        public ComputerGame(int maxAttempts = 5)
        {
            _maxAttempts = maxAttempts;
        }

        public void StartGame()
        {
            Random random = new Random();
            _numberToGuess = random.Next(1, 101); // Загадать число от 1 до 100
            Console.WriteLine("Я загадал число от 1 до 100. У тебя есть " + _maxAttempts + " попыток, чтобы его угадать!");

            for (int attempts = 0; attempts < _maxAttempts; attempts++)
            {
                Console.Write("Введи число: ");
                if (int.TryParse(Console.ReadLine(), out int playerGuess))
                {
                    if (playerGuess < _numberToGuess)
                    {
                        Console.WriteLine("Слишком низкое число.");
                    }
                    else if (playerGuess > _numberToGuess)
                    {
                        Console.WriteLine("Слишком высокое число.");
                    }
                    else
                    {
                        Console.WriteLine("Поздравляю! Ты угадал число.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введи корректное число.");
                }
            }

            Console.WriteLine("К сожалению, ты не угадал число. Загаданное число было: " + _numberToGuess);
            Console.ReadKey();
        }
    }
}
