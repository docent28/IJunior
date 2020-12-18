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

            Fighter soldier = new Fighter("Soldier", 200, 50, 25);
            Fighter archer = new Fighter("Archer", 250, 25, 15);
            Fighter lancer = new Fighter("Lancer", 150, 30, 20);
            Fighter knight = new Fighter("Knight", 300, 35, 30);
            Fighter robber = new Fighter("Robber", 100, 20, 25);
            Fighter[] fighters = { soldier, archer, lancer, knight, robber };

            playingField.ClearFieldStats();
            Console.CursorVisible = true;
            playingField.ShowFighters(fighters);
            playingField.SelectFighters(fighters);
            Console.CursorVisible = false;




            Console.ReadKey();
        }
    }

    class Fighter
    {
        private string _name;
        private int _health;
        private int _damage;
        private int _armor;

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public Fighter(string name, int health, int damage, int armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }

        public void TakePosition(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(this._name[0]);
        }

        public void ShowStats()
        {
            Console.WriteLine(_name + " HP - " + _health + " DMG " + _damage + " ARMOR " + _armor);
        }
    }

    class PlayingField
    {
        private int _leftBorderFieldStats = 50;
        private int _widthFieldStats = 70;
        private int _fighterIndexOne = 0;
        private int _fighterIndexTwo = 0;
        private int _fieldSize = 10;

        public void SelectFighters(Fighter[] fighters)
        {
            string numericValue;

            while (_fighterIndexOne <= 0 || _fighterIndexOne > 5)
            {
                Console.SetCursorPosition(_leftBorderFieldStats, fighters.Length + 1);
                Console.Write("Укажите номер первого бойца (> 0 и < 6) - ");
                numericValue = Console.ReadLine();
                if (int.TryParse(numericValue, out _fighterIndexOne))
                {
                    if (_fighterIndexOne <= 0 || _fighterIndexOne > 6)
                    {
                        ReportNumberError(fighters.Length, 1);
                    }
                }
                else
                {
                    ReportInputError(fighters.Length, 1);
                }
            }
            Fighter firstFighter = fighters[_fighterIndexOne - 1];

            while (_fighterIndexTwo <= 0 || _fighterIndexTwo > 5 || _fighterIndexOne == _fighterIndexTwo)
            {
                Console.SetCursorPosition(_leftBorderFieldStats, fighters.Length + 2);
                Console.Write("Укажите номер второго бойца (> 0 и < 6) - ");
                numericValue = Console.ReadLine();
                if (int.TryParse(numericValue, out _fighterIndexTwo))
                {
                    if (_fighterIndexTwo <= 0 || _fighterIndexTwo > 6)
                    {
                        ReportNumberError(fighters.Length, 2);
                    }
                    if (_fighterIndexOne == _fighterIndexTwo)
                    {
                        ReportSelectionError(fighters.Length, 2);
                    }
                }
                else
                {
                    ReportInputError(fighters.Length, 2);
                }
            }
            Fighter secondFighter = fighters[_fighterIndexTwo - 1];

            InitialPlacement(firstFighter, secondFighter);
        }

        private void InitialPlacement(Fighter firstFighter, Fighter secondFighter)
        {
            int positionXFirst;
            int positionYFirst;
            int positionXSecond;
            int positionYSecond;
            Random random = new Random();
            int[] positionsX = new int[_fieldSize];
            int[] positionsY = new int[_fieldSize];

            positionsX[0] = 2;
            for (int i = 1; i < _fieldSize; i++)
            {
                positionsX[i] = positionsX[i - 1] + 4;
            }
            positionsY[0] = 1;
            for (int i = 1; i < _fieldSize; i++)
            {
                positionsY[i] = positionsY[i - 1] + 2;
            }

            positionXFirst = positionsX[random.Next(0, _fieldSize)];
            positionYFirst = positionsY[random.Next(0, _fieldSize)];
            firstFighter.TakePosition(positionXFirst, positionYFirst);

            positionXSecond = positionXFirst;
            while (positionXFirst == positionXSecond)
            {
                positionXSecond = positionsX[random.Next(0, _fieldSize)];
            }
            positionYSecond = positionYFirst;
            while (positionYFirst == positionYSecond)
            {
                positionYSecond = positionsY[random.Next(0, _fieldSize)];
            }
            secondFighter.TakePosition(positionXSecond, positionYSecond);
        }

        private void ReportSelectionError(int fightersLength, int downwardOffset)
        {
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset);
            Console.Write("Неправильное значение. Боец не может драться сам с собой");
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset + 1);
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset);
            Console.WriteLine(new string(' ', _widthFieldStats));
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset + 1);
            Console.WriteLine(new string(' ', _widthFieldStats));
        }

        private void ReportNumberError(int fightersLength, int downwardOffset)
        {
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset);
            Console.Write("Неправильное значение. Необходимо значение больше 0 и меньше 6");
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset + 1);
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset);
            Console.WriteLine(new string(' ', _widthFieldStats));
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset + 1);
            Console.WriteLine(new string(' ', _widthFieldStats));
        }

        private void ReportInputError(int fightersLength, int downwardOffset)
        {
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset);
            Console.Write("Неправильное значение. Необходимо числовое значение");
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset + 1);
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset);
            Console.WriteLine(new string(' ', _widthFieldStats));
            Console.SetCursorPosition(_leftBorderFieldStats, fightersLength + downwardOffset + 1);
            Console.WriteLine(new string(' ', _widthFieldStats));
        }

        public void CreatingField()
        {
            for (int i = 0; i < _fieldSize; i++)
            {
                Console.WriteLine("|---|---|---|---|---|---|---|---|---|---|");
                Console.WriteLine("|   |   |   |   |   |   |   |   |   |   |");
            }
            Console.WriteLine("|---|---|---|---|---|---|---|---|---|---|");
        }

        public void ClearFieldStats()
        {
            int heightFieldStats = 10;

            for (int i = 0; i < heightFieldStats; i++)
            {
                Console.SetCursorPosition(_leftBorderFieldStats, i);
                Console.WriteLine(new string(' ', _leftBorderFieldStats));
            }
        }

        public void ShowFighters(Fighter[] fighters)
        {
            for (int i = 0; i < fighters.Length; i++)
            {
                Console.SetCursorPosition(_leftBorderFieldStats, i);
                Console.Write(i + 1 + " ");
                fighters[i].ShowStats();
            }
        }
    }
}
