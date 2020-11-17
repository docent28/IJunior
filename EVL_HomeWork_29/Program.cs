using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_29
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            Player player = new Player(15, 20, "Red");

            renderer.DrawPlayer(player.X, player.Y, player.Color);
        }
    }

    class Renderer
    {
        public void DrawPlayer(int x, int y, string color="White", char ch = '#')
        {
            Console.SetCursorPosition(x, y);
            switch (color)
            {
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.Write(ch);
            Console.ResetColor();
        }
    }

    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Color { get; private set; }

        public Player(int x, int y, string color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}
