using System;

namespace HomeWork_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerHelth = 3000; 
            int wrathLignung = 250;
            int thunderstorm = 175;
            int darkAndLight = playerHelth;
            int rejection = 55;
            int enemyHelth = 30000;
            int enemyDamage = 350;
            int abilitySelection;

            bool shockOn = false;
            bool vampirismOn = false;
            bool shieldOn = false;

            Random rnd = new Random();

            Console.WriteLine("описание способностей героя:\n" +
                              "1) wrathLignung наносит 250 урона.\n" +
                              "если цель под шоком то урон увеличивается на 300%\n" +
                              "2) thunderstorm наносит 175 урона и накладывает шок на 7 ходов.\n" +
                              "Шок каждый ход наносит 175 урона.\n" +
                              "3) darkAndLight - восстанавливает все здоровье персонажа,\n " +
                              "либо наносит врагу столько урона, сколько у персонажа здоровья\n" +
                              "4) rejection - накладывает на героя щит который отражает 55% урона,\n" +
                              "дает вампиризм способностей 7%. Длительность 5 ходов.");

            while(playerHelth >0 && enemyHelth > 0)
            {
                Console.WriteLine($"Здоровье игрока - {playerHelth}, здоровье босса - {enemyHelth}");
                Console.WriteLine("Выберите способность которую ходтите использовать: 1 - wrathLignung, 2 - thunderstorm, 3 - darkAndLight, 4 - rejection");
                abilitySelection = Convert.ToInt32(Console.ReadLine());

                switch(abilitySelection)
                {
                    case 1:
                        if (shockOn = true)
                        {
                            enemyDamage -= wrathLignung * 3;
                        }
                        else
                        {
                            enemyDamage -= wrathLignung;
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
            }
        }
    }
}
