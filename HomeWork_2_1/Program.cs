using System;

namespace HomeWork_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
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
                        Console.Write("Сколько желаете купить: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        switch (buy)
                        {
                            case 1:
                                if (rub >= currencyCount * rubToUsd)
                                {
                                    usd += currencyCount;
                                    rub -= currencyCount * rubToUsd;
                                }
                                else
                                {
                                    Console.WriteLine("У Вас недостаточно средств для покупки такого количества валюты");
                                }
                                break;
                            case 2:
                                if (rub >= currencyCount * rubToEur)
                                {
                                    eur += currencyCount;
                                    rub -= currencyCount * rubToEur;
                                }
                                else
                                {
                                    Console.WriteLine("У Вас недостаточно средств для покупки такого количества валюты");
                                }
                                break;
                            default:
                                Console.WriteLine("Шо за слово непонятный???");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Какую валюту желаете купить: 1 - рубли, 2 - евро");
                        Console.Write("1 - рубли, 2 - евро");
                        buy = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Сколько желаете купить: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        switch (buy)
                        {
                            case 1:
                                if (usd >= currencyCount / rubToUsd)
                                {
                                    rub += currencyCount;
                                    usd -= currencyCount / rubToUsd;
                                }
                                else
                                {
                                    Console.WriteLine("У Вас недостаточно средств для покупки такого количества валюты");
                                }
                                break;
                            case 2:
                                if (usd >= currencyCount * usdToEur)
                                {
                                    eur += currencyCount;
                                    usd -= currencyCount * usdToEur;
                                }
                                break;
                            default:
                                Console.WriteLine("Шо за слово непонятный???");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Какую валюту желаете купить");
                        Console.Write("1 - рубли, 2 - доллары: ");
                        buy = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Сколько желаете купить: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        switch (buy)
                        {
                            case 1:
                                if (eur >= currencyCount / rubToEur)
                                {
                                    rub += currencyCount;
                                    eur -= currencyCount / rubToEur;
                                }
                                else
                                {
                                    Console.WriteLine("У Вас недостаточно средств для покупки такого количества валюты");
                                }
                                break;
                            case 2:
                                if (eur >= currencyCount / usdToEur)
                                {
                                    usd += currencyCount;
                                    eur -= currencyCount / usdToEur;
                                }
                                break;
                            default:
                                Console.WriteLine("Шо за слово непонятный???");
                                break;
                        }
                        break;
                    case 0:
                        endProgram = false;
                        break;
                    default:
                        Console.WriteLine("Шо за слово непонятный???");
                        break;
                }

                Console.WriteLine($"баланс в рублях после операции - {rub}, баланс в долларах после операции - {usd}," +
                                          $"Баланс в евро после операции {eur} \n");
            }
        }
    }
}
