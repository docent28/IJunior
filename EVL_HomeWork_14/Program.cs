using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_14
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
Жизнь босса                         Boss's Life
жизнь игрока                        player's life
атака игрока                        player attack
невидимка                           invisible being
возвращение из портала              returning from the portal
переход в портал                    go to portal
длительное восстановление           long-term recovery
базовый урон                        baseline damage
оплата невидимости                  paying for invisibility
оплата портала                      payment of the portal
продолжительность невидимости       duration of invisibility
увеличение здоровья                 increased health
увеличение урона                    increased damage
оплата восстановления               payment for recovery
количество тактов восстановления    number of recovery cycles
сила удара босса                    force of boss strike
строка заклинания                   spell string
номер хода                          stroke number
внутри портала                      inside the portal
стать невидимкой                    become invisible
счет невидимости                    invisibility count
счет портала                        portal account
признак восстановления              sign of recovery
счет восстановления                 recovery account
             */
            Random rand = new Random();
            int bossLife = rand.Next(100, 501);
            int playerLife = rand.Next(100, 501);
            int baseLineDamage = rand.Next(50, 100);
            int maxPlayerLife = rand.Next(600, 1001);
            int maxBossLife = rand.Next(600, 1001);
            int payingInvisibility = maxPlayerLife / 100 * rand.Next(10, 26);
            int paymentPortal = rand.Next(10, 26);
            int durationInvisibility = rand.Next(3, 6);
            int increasedHealth = rand.Next(15, 51);
            int increaseLoss = rand.Next(20, 26);
            int paymentRecovery = rand.Next(30, 100);
            int numberRecoveryCycles = rand.Next(10, 16);
            int forceBossStrike;
            int strokeNumber = 1;
            int invisibilityCount = 0;
            int portalAccount = 0;
            int recoveryAccount = 0;
            string playerAttack = "конгён";
            string becomeInvisible = "поиджи анын сарам";
            string returningFromPortal = "хёнгванэсо торавассо";
            string gotoPortal = "хёнгванэ кассо";
            string longRecovery = "орэ ккынын хвэбок";
            bool bossMove;
            bool insidePortal = false;
            bool invisibleBeing = false;
            bool signRecovery = false;
            string spellString;

            Console.WriteLine("Игра - Победи БОССА");
            Console.WriteLine("Условия:");
            Console.WriteLine("Максимальный уровень жизни у БОССА - " + maxBossLife);
            Console.WriteLine("Максимальный уровень жизни у игрока - " + maxPlayerLife);
            Console.WriteLine("Случайным образом выбирается игрок, делающий первый ход");
            Console.WriteLine("Величина урона, наносимого БОССОМ, для каждого хода случайна");
            Console.WriteLine("Игрок может пользоваться следующими заклинаниями:");
            Console.WriteLine();
            Console.WriteLine("конгён - атака, может наноситься урон от " + baseLineDamage + " единиц\n" +
                "Сила атаки в дальнейшем может увеличиваться");
            Console.WriteLine();
            Console.WriteLine("поиджи анын сарам - призыв духа Невидимости. Тратится " + payingInvisibility + " единиц здоровья.\n" +
                "Невидимость держится " + durationInvisibility + " игровых тактов");
            Console.WriteLine();
            Console.WriteLine("хёнгванэ кассо - переход в портал. Тратится " + paymentPortal + " единиц здоровья\n" +
                "БОСС не может наносить удары по игроку, который спрятался в портале\n" +
                "В портал нельзя уйти невидимым\n" +
                "В портале нельзя стать невидимым\n" +
                "Из портала нельзя атаковать БОССА\n" +
                "Каждый игровой такт увеличивает здоровье на " + increasedHealth + " единиц\n" +
                "Каждый игровой такт усиливает силу атаки на " + increaseLoss + " единиц");
            Console.WriteLine();
            Console.WriteLine("хёнгванэсо торавассо - возвращение из портала");
            Console.WriteLine();
            Console.WriteLine("орэ ккынын хвэбок - длительное восстановление. Тратится " + paymentRecovery + " единиц здоровья,\n" +
                "но следующие " + numberRecoveryCycles + " игровых тактов восстанавливается по " + increasedHealth + " единиц здоровья за такт");
            Console.WriteLine();

            bossMove = (rand.Next(500, 1001) > rand.Next(500, 1001) ? false : true);

            Console.WriteLine("Начальное значение здоровья у игрока - \t" + playerLife + " \tединиц");
            Console.WriteLine("Начальное значение здоровья у БОССА - \t" + bossLife + " \tединиц");

            while (bossLife > 0 && playerLife > 0)
            {
                if (bossMove)
                {
                    Console.WriteLine();
                    Console.WriteLine("Игровой такт № - " + strokeNumber);
                    Console.WriteLine("Атакует БОСС");
                    forceBossStrike = rand.Next(70, 151);
                    Console.WriteLine("Сила удара - " + forceBossStrike + " единиц");
                    if (!insidePortal && !invisibleBeing)
                    {
                        playerLife -= forceBossStrike;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Игровой такт № - " + strokeNumber);
                    Console.WriteLine("Атакует игрок");
                    Console.Write("Введите заклинание - ");
                    spellString = Console.ReadLine();

                    switch (spellString)
                    {
                        case "конгён":                  // атака
                            if (!insidePortal)
                            {
                                Console.WriteLine("Сила удара - " + baseLineDamage + " единиц");
                                bossLife -= baseLineDamage;
                            }
                            else
                            {
                                Console.WriteLine("Вы находитесь в портале. Урон БОССУ нанести нельзя");
                            }
                            break;
                        case "поиджи анын сарам":       // призыв духа Невидимости
                            if (!invisibleBeing && !insidePortal)
                            {
                                invisibleBeing = true;
                                playerLife -= payingInvisibility;
                                invisibilityCount = 0;
                            }
                            else
                            {
                                Console.WriteLine("Вы зря использовали свой ход. Вы уже были невидимы\n" +
                                    "Или были в портале. Ход переходит к БОССУ");
                            }
                            break;
                        case "хёнгванэ кассо":          // переход в портал
                            if (!insidePortal && !invisibleBeing)
                            {
                                insidePortal = true;
                                playerLife -= paymentPortal;
                                portalAccount = 0;
                            }
                            else
                            {
                                Console.WriteLine("Вы зря использовали свой ход. Вы уже находились в портале\n" +
                                    "Или были невидимы. Ход переходит к БОССУ");
                            }
                            break;
                        case "хёнгванэсо торавассо":    // возвращение из портала
                            if (insidePortal)
                            {
                                Console.WriteLine("Вы вернулись из портала. Берегитесь удара БОССА");
                                insidePortal = false;
                            }
                            else
                            {
                                Console.WriteLine("Вы зря использовали свой ход. Вы не находились в портале\n" +
                                    "Ход переходит к БОССУ");
                            }
                            break;
                        case "орэ ккынын хвэбок":       // длительное восстановление
                            if (signRecovery)
                            {
                                Console.WriteLine("Вы зря использовали свой ход. Вы уже восстанавливались и процесс находился на " 
                                    + recoveryAccount + " шаге из " + numberRecoveryCycles + "\n" +
                                    "Ход переходит к БОССУ");
                            }
                            else
                            {
                                signRecovery = true;
                                recoveryAccount = 0;
                            }
                            break;
                        default:
                            Console.WriteLine("Вы волнуетесь и сказали неправильное заклинание\n" +
                                "Ход переходит к БОССУ");
                            break;
                    }
                }
                Console.WriteLine("Осталось здоровья у игрока - \t" + playerLife + " \tединиц");
                Console.WriteLine("Осталось здоровья у БОССА - \t" + bossLife + " \tединиц");
                if (signRecovery)
                {
                    if (recoveryAccount > 0 && recoveryAccount < numberRecoveryCycles)
                    {
                        playerLife += increasedHealth;
                        if (playerLife > maxPlayerLife)
                        {
                            playerLife = maxPlayerLife;
                        }
                    }
                    else
                    {
                        signRecovery = false;
                    }
                    recoveryAccount++;
                }
                if (insidePortal)
                {
                    if (portalAccount > 0)
                    {
                        playerLife += increasedHealth;
                        if (playerLife > maxPlayerLife)
                        {
                            playerLife = maxPlayerLife;
                        }
                        baseLineDamage += increaseLoss;
                    }
                    portalAccount++;
                }
                if (invisibleBeing)
                {
                    invisibilityCount++;
                    if (invisibilityCount > durationInvisibility)
                    {
                        Console.WriteLine("Вы стали видимы. БОСС может вас ударить");
                        invisibleBeing = false;
                    }
                }
                bossMove = !bossMove;
                strokeNumber++;
                if (playerLife <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Победил БОСС!!!");
                }
                if (bossLife <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы победили!!!");
                }
            }
        }
    }
}
