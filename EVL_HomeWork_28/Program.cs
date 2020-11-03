using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_28
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player_one = new Player();
            Player player_two = new Player("Том", 37);
            Player player_three = new Player("Джерри", 45, "баскетболист");

            player_one.ShowInfo();
            player_two.ShowInfo();
            player_three.ShowInfo();
            Console.WriteLine();
        }
    }

    class Player
    {
        private string _name;
        private int _age;
        private string _profession;

        public Player()
        {
            _name = "неизвестно";
            _age = 25;
            _profession = "непонятная";
        }

        public Player(string name, int age)
        {
            _name = name;
            _age = age;
            _profession = "разнорабочий";
        }

        public Player(string name, int age, string profession)
        {
            _name = name;
            _age = age;
            _profession = profession;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя игрока - {_name}. Ему {_age} лет. Его профессия - {_profession}.");
        }
    }

}
