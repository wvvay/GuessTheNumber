using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame
{
    public class PlayerVsPlayerGame : IGame
    {
        private int _numberToGuess;
        private int _maxAttempts;
        
        public PlayerVsPlayerGame(int maxAttempts = 5)
        {
            _maxAttempts = maxAttempts;
        }

        public void StartGame()
        {
            Console.Write("Игрок 1, загадайте число от 1 до 100: ");
            _numberToGuess = ReadHiddenNumber();
            Console.Clear();
            Console.WriteLine("Игрок 2, у тебя есть " + _maxAttempts + " попыток, чтобы угадать число!");

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
        
        private int ReadHiddenNumber()
        {
            string input = string.Empty;
            ConsoleKeyInfo keyInfo;

            while (true)
            {
                keyInfo = Console.ReadKey(true); 
                if (keyInfo.Key == ConsoleKey.Enter) 
                    break;

                if (char.IsDigit(keyInfo.KeyChar)) 
                {
                    input += keyInfo.KeyChar; 
                    Console.Write("*"); 
                }
            }

            return int.Parse(input); 
        }
    }


}
