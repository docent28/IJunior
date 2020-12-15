using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_33
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayingField playingField = new PlayingField();
            playingField.CreatingField();
            Console.CursorVisible = false;

            Console.SetCursorPosition(2, 1);
            Console.Write("R");
            Console.SetCursorPosition(6, 1);
            Console.Write("O");
            Console.SetCursorPosition(6, 5);
            Console.Write("T");
            Console.SetCursorPosition(6, 3);
            Console.Write("D");
            Console.SetCursorPosition(34, 19);
            Console.Write("H");

            Console.ReadKey();
        }
    }

    class Fighter
    {
        private string _name;
        private int _health;
        private int _damage;
        private int _armor;

        public Fighter(string name, int health, int damage, int armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }
    }

    class PlayingField
    {
        public void CreatingField()
        {
            int fieldSize = 10;

            for (int i = 0; i < fieldSize; i++)
            {
                Console.WriteLine("|---|---|---|---|---|---|---|---|---|---|");
                Console.WriteLine("|   |   |   |   |   |   |   |   |   |   |");
            }
            Console.WriteLine("|---|---|---|---|---|---|---|---|---|---|");
        }
    }
}
