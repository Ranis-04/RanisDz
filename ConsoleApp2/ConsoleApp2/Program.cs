using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            GameLoop(player);
        }
        static void GameLoop(Player player)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Проверить состояние игрока");
                Console.WriteLine("2. Использовать зелье");
                Console.WriteLine("3. Атаковать с луком");
                Console.WriteLine("4. Атаковать мечом");
                Console.WriteLine("5. Закончить игру");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        player.ShowStatus();
                        break;
                    case "2":
                        player.UsePotion();
                        break;
                    case "3":
                        player.AttackWithBow();
                        break;
                    case "4":
                        player.AttackWithSword();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }
    }

    class Player
    {
        public int Health { get; set; } = 100;
        public int Potions { get; set; } = 3;
        public int Gold { get; set; } = 0;
        public int Arrows { get; set; } = 5;
        public List<string> Inventory { get; set; } = new List<string>();

        public void ShowStatus()
        {
            Console.WriteLine($"Здоровье: {Health}");
            Console.WriteLine($"Зелья: {Potions}");
            Console.WriteLine($"Золото: {Gold}");
            Console.WriteLine($"Стрелы: {Arrows}");
            Console.WriteLine("Инвентарь: " + (Inventory.Count > 0 ? string.Join(", ", Inventory) : "пусто"));
        }

        public void UsePotion()
        {
            if (Potions > 0)
            {
                Health += 20; // Восстановление 20 здоровья
                Potions--;
                Console.WriteLine("Вы использовали зелье восстановления. Здоровье увеличено на 20.");
            }
            else
            {
                Console.WriteLine("У вас нет зелий для использования.");
            }
        }

        public void AttackWithBow()
        {
            if (Arrows > 0)
            {
                Random rand = new Random();
                int damage = rand.Next(5, 16); // Урон от 5 до 15
                Console.WriteLine($"Вы атаковали с луком и нанесли {damage} урона!");
                Arrows--;
            }
            else
            {
                Console.WriteLine("У вас нет стрел для атаки с луком.");
            }
        }

        public void AttackWithSword()
        {
            Random rand = new Random();
            int damage = rand.Next(10, 21); // Урон от 10 до 20
            Console.WriteLine($"Вы атаковали мечом и нанесли {damage} урона!");
        }
    }
}

