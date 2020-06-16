using System;

namespace HomeWork_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //usdToRub = 0.014f,  eurToRub = 0.013f, eurToUsd = 0.89f;
            float rubToUsd = 69.88f, rubToEur = 78.57f, usdToEur = 1.12f;
            float rub, usd, eur;
            float currencyCount;
            int sale, buy;

            bool endProgram = true;

            Console.WriteLine("Доброго времени суток, введите Ваш баланс");
            Console.Write("Введите баланс в рублях: ");
            rub = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите баланс в долларах: ");
            usd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите баланс в евро: ");
            eur = Convert.ToInt32(Console.ReadLine());

            while (endProgram == true) 
            {
                Console.WriteLine("Выберите какую валюту желаете продать");
                Console.WriteLine("1 - рубли, 2 - доллары, 3 - евро");
                Console.WriteLine("нажмите 0 для выхода");
                sale = Convert.ToInt32(Console.ReadLine());

                switch (sale)
                {
                    case 1:
                        Console.WriteLine("Какую валюту желаете купить");
                        Console.Write("1 - доллары, 2 - евро: ");
                        buy = Convert.ToInt32(Console.ReadLine());

                        switch (buy)
                        {
                            case 1:
                                Console.Write("Сколько желаете купить: ");
                                currencyCount = Convert.ToSingle(Console.ReadLine());
                                if (rub >= currencyCount * rubToUsd)
                                {
                                    usd += currencyCount;
                                    rub -= currencyCount * rubToUsd;
                                    Console.WriteLine($"баланс в рублях после операции - {rub}, баланс в долларах после операции - {usd}");
                                }
                                else Console.WriteLine("У Вас недостаточно средств для покупки такого количества валюты");
                                break;
                            case 2:
                                Console.Write("Сколько желаете купить: ");
                                currencyCount = Convert.ToSingle(Console.ReadLine());
                                if (rub >= currencyCount * rubToEur) 
                                {
                                    eur += currencyCount;
                                    rub -= currencyCount * rubToEur;
                                    Console.WriteLine($"баланс в рублях после операции - {rub}, баланс в евро после операции - {eur}");
                                }
                                else Console.WriteLine("У Вас недостаточно средств для покупки такого количества валюты");
                                break;

                        }
                        break;
                    case 2:
                        Console.WriteLine("Какую валюту желаете купить");
                        Console.Write("1 - рубли, 2 - евро: ");
                        buy = Convert.ToInt32(Console.ReadLine());

                        switch (buy)
                        {
                            case 1:
                                Console.Write("Сколько желаете купить: ");
                                currencyCount = Convert.ToSingle(Console.ReadLine());
                                if (usd >= currencyCount / rubToUsd)
                                {
                                    rub += currencyCount;
                                    usd -= currencyCount / rubToUsd;
                                    Console.WriteLine($"баланс в долларах после операции - {usd}, баланс в рублях  после операции - {rub}");
                                }
                                else Console.WriteLine("У Вас недостаточно средств для покупки такого количества валюты");
                                break;
                            case 2:
                                Console.Write("Сколько желаете купить: ");
                                currencyCount = Convert.ToSingle(Console.ReadLine());
                                if (usd >= currencyCount / usdToEur)
                                {
                                    rub += currencyCount;
                                    usd -= currencyCount / usdToEur;
                                    Console.WriteLine($"баланс в долларах после операции - {usd}, баланс в евро  после операции - {eur}");
                                }
                                else Console.WriteLine("У Вас недостаточно средств для покупки такого количества валюты");
                                break;
                        }
                    case 3:
                        Console.WriteLine("Какую валюту желаете купить");
                        Console.Write("1 - рубли, 2 - доллары: ");
                        buy = Convert.ToInt32(Console.ReadLine());

                        switch (buy)
                        {
                            case 1:
                                Console.Write("Сколько желаете купить: ");
                                currencyCount = Convert.ToSingle(Console.ReadLine());
                                if (eur >= currencyCount / rubToEur)
                                {
                                    rub += currencyCount;
                                    eur -= currencyCount / rubToEur;
                                    Console.WriteLine($"баланс в евро после операции - {eur}, баланс в рублях после операции - {rub}");
                                }
                                else Console.WriteLine("У Вас недостаточно средств для покупки такого количества валюты");
                                break;
                            case 2:
                                Console.Write("Сколько желаете купить: ");
                                currencyCount = Convert.ToSingle(Console.ReadLine());
                                if (eur >= currencyCount / usdToEur)
                                {
                                    usd += currencyCount;
                                    eur -= currencyCount / usdToEur;
                                    Console.WriteLine($"баланс в евро после операции - {eur}, баланс в долларах  после операции - {usd}");
                                }
                                else Console.WriteLine("У Вас недостаточно средств для покупки такого количества валюты");
                                break;
                        }
                    case 0:
                        endProgram = false;
                        break;
                }
            }
        }
    }
}
