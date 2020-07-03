using System;

namespace HomeWork_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int plauerDamage = 0;
            int playerHelth = 3000; 
            int wrathLightning = 250;
            int thunderstorm = 175;
            int darkAndLight = 3;
            int enemyHelth = 30000;
            int enemyDamage;
            int shock = 0;
            int shield = 0;
            int vampirism;
            int abilitySelection;

            bool shockOn = false;
            bool vampirismOn = false;
            bool shieldOn = false;

            Random rnd = new Random();

            Console.WriteLine("описание способностей героя:\n" +
                              "1) wrathLightning наносит 250 урона.\n" +
                              "если цель под шоком то урон увеличивается на 300%\n" +
                              "2) thunderstorm наносит 175 урона и накладывает шок на 7 ходов.\n" +
                              "Шок каждый ход наносит 175 урона.\n" +
                              "3) darkAndLight - восстанавливает все здоровье персонажа,\n " +
                              "либо наносит врагу столько урона, сколько у персонажа здоровья, при этом теряется 10% текущего запаса здоровья.\n" +
                              "Способность может быть использована только 3 раза за бой.\n" +
                              "4) rejection - накладывает на героя щит который отражает 40% урона,\n" +
                              "дает вампиризм способностей 25%. Длительность 5 ходов.\n");

            while(playerHelth > 0 && enemyHelth > 0)
            {
                Console.WriteLine($"Здоровье игрока - {playerHelth}, здоровье босса - {enemyHelth}");
                Console.WriteLine("Выберите способность которую ходтите использовать: 1 - wrathLightning, 2 - thunderstorm, 3 - darkAndLight, 4 - rejection");

                abilitySelection = Convert.ToInt32(Console.ReadLine());

                switch(abilitySelection)
                {
                    case 1:
                        if (shockOn == true)
                        {
                            plauerDamage = wrathLightning * 3;
                            enemyHelth -= plauerDamage;

                            Console.WriteLine($"Вы нанесли урон в размере: {wrathLightning * 3} способностью wrathLightning");
                        }
                        else
                        {
                            plauerDamage = wrathLightning;
                            enemyHelth -= plauerDamage;

                            Console.WriteLine($"Вы нанесли урон в размере: {wrathLightning} способностью wrathLightning");
                        }
                        break;
                    case 2:
                        plauerDamage = thunderstorm;
                        enemyHelth -= plauerDamage;
                        shockOn = true;
                        shock = 7;

                        Console.WriteLine($"Вы нанесли {plauerDamage} урона способностью thunderstorm");
                        break;
                    case 3:
                        if (darkAndLight > 0)
                        {
                            Console.WriteLine("1 - применить на врага. 2 - применить на себя.");

                            abilitySelection = Convert.ToInt32(Console.ReadLine());

                            if (abilitySelection == 1)
                            {
                                plauerDamage = playerHelth;
                                enemyHelth -= plauerDamage;
                                playerHelth -= darkAndLight / 100 * 15;

                                Console.WriteLine($"Вы нанесли {plauerDamage} урона.");
                            }
                            else
                            {
                                playerHelth += 3000;
                            }
                            darkAndLight--;

                            Console.WriteLine($"возможно использовать данное заклинание еще {darkAndLight} раз");
                        }
                        else
                        {
                            Console.WriteLine("Нет возможности использовать данное заклинание.");
                        }
                        break;
                    case 4:
                        shield = 5;
                        shieldOn = true;
                        vampirismOn = true;
                        break;
                }
                if (vampirismOn == true)
                {
                    vampirism = plauerDamage / 100 * 25;
                    playerHelth += vampirism;
                    Console.WriteLine("вы востановили здоровье в размере: " + vampirism);
                }
                if (shield > 0)
                {
                    shield--;
                }
                else
                {
                    shieldOn = false;
                    vampirismOn = false;
                }
                if (shock > 0)
                {
                    shock--;
                    enemyHelth -= 175;
                }
                else
                {
                    shockOn = false;
                }

                Console.WriteLine("shock = " + shock);
                Console.WriteLine("shield = " + shield);

                enemyDamage = rnd.Next(500, 750);
                if (shieldOn == true)
                {
                    enemyDamage -= enemyDamage / 100 * 40;
                    playerHelth -= enemyDamage;
                }else
                {
                    playerHelth -= enemyDamage;
                }

                Console.WriteLine("наносит урон в размере: " + enemyDamage);
            }

            if (playerHelth > 0)
            {
                Console.WriteLine("Поздравляем босс повержен");
            }
            else
            {
                Console.WriteLine("Поражение. Вашу душу пожрали");
            }
        }
    }
}