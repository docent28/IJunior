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

            Soldier soldier = new Soldier("Soldier", 200, 50, 25, 1);
            Archer archer = new Archer("Archer", 250, 25, 15, 2);
            Lancer lancer = new Lancer("Lancer", 150, 30, 20, 2);
            Knight knight = new Knight("Knight", 300, 35, 30, 3);
            Robber robber = new Robber("Robber", 100, 20, 25, 4);
            Fighter[] fighters = { soldier, archer, lancer, knight, robber };

            playingField.ClearFieldStats();
            Console.CursorVisible = true;
            playingField.ShowFighters(fighters);
            playingField.SelectFighters(fighters);
            Console.CursorVisible = false;

            Fighter firstFighter = fighters[playingField.FirstFighter - 1];
            Fighter secondFighter = fighters[playingField.SecondFighter - 1];

            Console.SetCursorPosition(50, 15);
            firstFighter.ShowStats();
            Console.SetCursorPosition(50, 16);
            secondFighter.ShowStats();

            firstFighter.TakePosition(14, 5);
            secondFighter.TakePosition(18, 7);

            while (firstFighter.Health > 0 && secondFighter.Health > 0)
            {
                Console.ReadKey();
                firstFighter.MovePosition(firstFighter, secondFighter, playingField.СellWidth);
            }
        }
    }

    class Fighter
    {
        protected string _name;
        protected int _health;
        protected int _damage;
        protected int _armor;
        protected int _moving;

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int Health { get { return _health; } private set { } }
        public int Moving { get { return _moving; } private set { } }

        public Fighter(string name, int health, int damage, int armor, int moving)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
            _moving = moving;
        }

        virtual public void MovePosition(Fighter attackingPlayer, Fighter defendingPlayer, int cellWidth)
        {
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
            Console.WriteLine(_name + " HP - " + _health + " DMG " + _damage + " ARMOR " + _armor + " MOVING " + _moving);
        }
    }

    class Soldier : Fighter
    {
        public Soldier(string name, int health, int damage, int armor, int moving) : base(name, health, damage, armor, moving)
        {
        }

        public override void MovePosition(Fighter attackingPlayer, Fighter defendingPlayer, int cellWidth)
        {
            Random random = new Random();
            int directionX;
            int directionY;
            int positionX = attackingPlayer.PositionX;
            int positionY = attackingPlayer.PositionY;

            if (Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) / cellWidth >= attackingPlayer.Moving &&
                Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) / (cellWidth / 2) >= attackingPlayer.Moving)
            {
                directionX = random.Next(0, 2);
                if (directionX == 0)
                {
                    directionY = 1;
                }
                else
                {
                    directionY = 0;
                }
                if (attackingPlayer.PositionX > defendingPlayer.PositionX && attackingPlayer.PositionY > defendingPlayer.PositionY)
                {
                    positionX = attackingPlayer.PositionX - directionX * attackingPlayer.Moving * cellWidth;
                    positionY = attackingPlayer.PositionY - directionY * attackingPlayer.Moving * cellWidth / 2;
                }
                if (attackingPlayer.PositionX < defendingPlayer.PositionX && attackingPlayer.PositionY < defendingPlayer.PositionY)
                {
                    positionX = attackingPlayer.PositionX + directionX * attackingPlayer.Moving * cellWidth;
                    positionY = attackingPlayer.PositionY + directionY * attackingPlayer.Moving * cellWidth / 2;
                }
                if (attackingPlayer.PositionX > defendingPlayer.PositionX && attackingPlayer.PositionY < defendingPlayer.PositionY)
                {
                    positionX = attackingPlayer.PositionX - directionX * attackingPlayer.Moving * cellWidth;
                    positionY = attackingPlayer.PositionY + directionY * attackingPlayer.Moving * cellWidth / 2;
                }
                if (attackingPlayer.PositionX < defendingPlayer.PositionX && attackingPlayer.PositionY > defendingPlayer.PositionY)
                {
                    positionX = attackingPlayer.PositionX + directionX * attackingPlayer.Moving * cellWidth;
                    positionY = attackingPlayer.PositionY - directionY * attackingPlayer.Moving * cellWidth / 2;
                }
            }
            else if (Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) / cellWidth >= attackingPlayer.Moving &&
                Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) == 0)
            {
                directionX = 1;
                if (attackingPlayer.PositionX > defendingPlayer.PositionX &&
                    (Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) / cellWidth != attackingPlayer.Moving))
                {
                    positionX = attackingPlayer.PositionX - directionX * attackingPlayer.Moving * cellWidth;
                    positionY = attackingPlayer.PositionY;
                }
                if (attackingPlayer.PositionX < defendingPlayer.PositionX &&
                    (Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) / cellWidth != attackingPlayer.Moving))
                {
                    positionX = attackingPlayer.PositionX + directionX * attackingPlayer.Moving * cellWidth;
                    positionY = attackingPlayer.PositionY;
                }
            }
            else if (Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) / (cellWidth / 2) >= attackingPlayer.Moving &&
                Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) == 0)
            {
                directionY = 1;
                if (attackingPlayer.PositionY > defendingPlayer.PositionY &&
                    (Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) / (cellWidth / 2) != attackingPlayer.Moving))
                {
                    positionX = attackingPlayer.PositionX;
                    positionY = attackingPlayer.PositionY - directionY * attackingPlayer.Moving * cellWidth / 2;
                }
                if (attackingPlayer.PositionY < defendingPlayer.PositionY &&
                    (Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) / (cellWidth / 2) != attackingPlayer.Moving))
                {
                    positionX = attackingPlayer.PositionX;
                    positionY = attackingPlayer.PositionY + directionY * attackingPlayer.Moving * cellWidth / 2;
                }
            }
            else if (Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) / cellWidth < attackingPlayer.Moving)
            {
                positionX = defendingPlayer.PositionX;
            }
            else if (Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) / (cellWidth / 2) < attackingPlayer.Moving)
            {
                positionY = defendingPlayer.PositionY;
            }
            else
            {
                positionX = attackingPlayer.PositionX;
                positionY = attackingPlayer.PositionY;
            }

            Console.SetCursorPosition(attackingPlayer.PositionX, attackingPlayer.PositionY);
            Console.WriteLine(" ");
            attackingPlayer.TakePosition(positionX, positionY);
        }
    }

    class Archer : Fighter
    {
        public Archer(string name, int health, int damage, int armor, int moving) : base(name, health, damage, armor, moving)
        {
        }

        public override void MovePosition(Fighter attackingPlayer, Fighter defendingPlayer, int cellWidth)
        {
            Random random = new Random();
            int directionX;
            int directionY;
            int positionX = attackingPlayer.PositionX;
            int positionY = attackingPlayer.PositionY;

            if (Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) / cellWidth >= attackingPlayer.Moving &&
                Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) / (cellWidth / 2) >= attackingPlayer.Moving)
            {
                directionX = random.Next(0, 2);
                if (directionX == 0)
                {
                    directionY = 1;
                }
                else
                {
                    directionY = 0;
                }
                if (attackingPlayer.PositionX > defendingPlayer.PositionX && attackingPlayer.PositionY > defendingPlayer.PositionY)
                {
                    positionX = attackingPlayer.PositionX - directionX * attackingPlayer.Moving * cellWidth;
                    positionY = attackingPlayer.PositionY - directionY * attackingPlayer.Moving * cellWidth / 2;
                }
                if (attackingPlayer.PositionX < defendingPlayer.PositionX && attackingPlayer.PositionY < defendingPlayer.PositionY)
                {
                    positionX = attackingPlayer.PositionX + directionX * attackingPlayer.Moving * cellWidth;
                    positionY = attackingPlayer.PositionY + directionY * attackingPlayer.Moving * cellWidth / 2;
                }
                if (attackingPlayer.PositionX > defendingPlayer.PositionX && attackingPlayer.PositionY < defendingPlayer.PositionY)
                {
                    positionX = attackingPlayer.PositionX - directionX * attackingPlayer.Moving * cellWidth;
                    positionY = attackingPlayer.PositionY + directionY * attackingPlayer.Moving * cellWidth / 2;
                }
                if (attackingPlayer.PositionX < defendingPlayer.PositionX && attackingPlayer.PositionY > defendingPlayer.PositionY)
                {
                    positionX = attackingPlayer.PositionX + directionX * attackingPlayer.Moving * cellWidth;
                    positionY = attackingPlayer.PositionY - directionY * attackingPlayer.Moving * cellWidth / 2;
                }
            }
            else if (Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) / cellWidth >= attackingPlayer.Moving &&
                Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) == 0)
            {
                directionX = 1;
                if (attackingPlayer.PositionX > defendingPlayer.PositionX &&
                    (Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) / cellWidth != attackingPlayer.Moving))
                {
                    positionX = attackingPlayer.PositionX - directionX * attackingPlayer.Moving * cellWidth;
                    if (Math.Abs(positionX - defendingPlayer.PositionX) / cellWidth < attackingPlayer.Moving)
                    {
                        positionX = defendingPlayer.PositionX + attackingPlayer.Moving * cellWidth;
                    }
                    positionY = attackingPlayer.PositionY;
                }
                if (attackingPlayer.PositionX < defendingPlayer.PositionX &&
                    (Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) / cellWidth != attackingPlayer.Moving))
                {
                    positionX = attackingPlayer.PositionX + directionX * attackingPlayer.Moving * cellWidth;
                    if (Math.Abs(positionX - defendingPlayer.PositionX) / cellWidth < attackingPlayer.Moving)
                    {
                        positionX = defendingPlayer.PositionX - attackingPlayer.Moving * cellWidth;
                    }
                    positionY = attackingPlayer.PositionY;
                }
            }
            else if (Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) / (cellWidth / 2) >= attackingPlayer.Moving &&
                Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) == 0)
            {
                directionY = 1;
                if (attackingPlayer.PositionY > defendingPlayer.PositionY &&
                    (Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) / (cellWidth / 2) != attackingPlayer.Moving))
                {
                    positionX = attackingPlayer.PositionX;
                    positionY = attackingPlayer.PositionY - directionY * attackingPlayer.Moving * cellWidth / 2;
                    if (Math.Abs(positionY - defendingPlayer.PositionY) / (cellWidth / 2) < attackingPlayer.Moving)
                    {
                        positionY = defendingPlayer.PositionY + attackingPlayer.Moving * (cellWidth / 2);
                    }
                }
                if (attackingPlayer.PositionY < defendingPlayer.PositionY &&
                    (Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) / (cellWidth / 2) != attackingPlayer.Moving))
                {
                    positionX = attackingPlayer.PositionX;
                    positionY = attackingPlayer.PositionY + directionY * attackingPlayer.Moving * cellWidth / 2;
                    if (Math.Abs(positionY - defendingPlayer.PositionY) / (cellWidth / 2) < attackingPlayer.Moving)
                    {
                        positionY = defendingPlayer.PositionY - attackingPlayer.Moving * (cellWidth / 2);
                    }
                }
            }
            else if (Math.Abs(defendingPlayer.PositionX - attackingPlayer.PositionX) / cellWidth < attackingPlayer.Moving)
            {
                positionX = defendingPlayer.PositionX;
            }
            else if (Math.Abs(defendingPlayer.PositionY - attackingPlayer.PositionY) / (cellWidth / 2) < attackingPlayer.Moving)
            {
                positionY = defendingPlayer.PositionY;
            }
            else
            {
                positionX = attackingPlayer.PositionX;
                positionY = attackingPlayer.PositionY;
            }

            Console.SetCursorPosition(attackingPlayer.PositionX, attackingPlayer.PositionY);
            Console.WriteLine(" ");
            attackingPlayer.TakePosition(positionX, positionY);
        }
    }

    class Lancer : Fighter
    {
        public Lancer(string name, int health, int damage, int armor, int moving) : base(name, health, damage, armor, moving)
        {
        }
    }

    class Knight : Fighter
    {
        public Knight(string name, int health, int damage, int armor, int moving) : base(name, health, damage, armor, moving)
        {
        }
    }

    class Robber : Fighter
    {
        public Robber(string name, int health, int damage, int armor, int moving) : base(name, health, damage, armor, moving)
        {
        }
    }

    class PlayingField
    {
        private int _leftBorderFieldStats = 50;
        private int _widthFieldStats = 70;
        private int _fighterIndexOne = 0;
        private int _fighterIndexTwo = 0;
        private int _fieldSize = 10;

        public int СellWidth
        {
            get
            {
                return 4;
            }
            private set
            {
            }
        }

        public int FirstFighter
        {
            get
            {
                return _fighterIndexOne;
            }
            private set { }
        }
        public int SecondFighter
        {
            get
            {
                return _fighterIndexTwo;
            }
            private set { }
        }

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
                    if (_fighterIndexOne <= 0 || _fighterIndexOne > 5)
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
                    if (_fighterIndexTwo <= 0 || _fighterIndexTwo > 5)
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
