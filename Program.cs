using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
            Console.WriteLine("Выберите режим: 1 - Игрок против компьютера, 2 - Два игрока");

            if (int.TryParse(Console.ReadLine(), out int mode))
            {
                IGame game;

                switch (mode)
                {
                    case 1:
                        game = new ComputerGame();
                        break;
                    case 2:
                        game = new PlayerVsPlayerGame();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор режима.");
                        return;
                }

                game.StartGame();
            }
            else
            {
                Console.WriteLine("Пожалуйста, выберите корректный режим.");
            }
        }
    }
}
