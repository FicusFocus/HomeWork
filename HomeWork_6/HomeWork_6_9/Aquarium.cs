using System;
using System.Collections.Generic;
using System.Text;

//Есть аквариум, в котором плавают рыбы. В этом аквариуме может быть не больше определенного количества рыб.
//Рыб можно как добавить так и убрать из аквариума.(Программа должна быть в цикле для того чтоб рыбы могли жить.)
//Все рыбы отображаются списком, так же у рыб есть возраст. За 1 итерацию рыбы стареют на определенное количество жизней и могут умереть.
//Рыб так же вывести в консоль, чтоб можно было мониторить показатели.

//TODO: Криво добавляется возраст рыб. Несколько одинаковых рыб считает за одну и в итоге дает один возраст. Изменить создание рыб нр- Скат, Скат1 и т.д
//TODO: Добавить рыбам смерть.
//TODO: Сделать шкалу хп рыб в процентах.

namespace HomeWork_6_9
{
    class Aquarium
    {
        private int _placeAmount = 10;
        private List<Fish> _fishInAquarium = new List<Fish>();
        private List<Fish> _fishs = new List<Fish>();

        public Aquarium()
        {
            FishList();
        }

        public void LifeInside()
        {
            FillTheAquarium();

            while (true)
            {
                ShowInhabitants();


                Console.ReadLine();
                Console.Clear();

                AddFishsAge();
            }
        }

        private void AddFishsAge()
        {
            for (int i = 0; i < _fishInAquarium.Count; i++)
            {
                _fishInAquarium[i].AddAge();
            }
        }

        private void FillTheAquarium()
        {
            Random rand = new Random();
            while (_fishInAquarium.Count < _placeAmount)
            {
                int randdomfish = rand.Next(0, _fishs.Count);
                string fishName = _fishs[randdomfish].Name;
                string newName = fishName;
                int fishNumber = 1;

                while (CheckNames(newName))
                {
                    fishNumber++;
                    newName = fishName + Convert.ToString(fishNumber);
                    CheckNames(newName);
                }

                _fishInAquarium.Add(new Fish(newName, _fishs[randdomfish].MaxAge));
            }

            Console.WriteLine("Аквариум Полон.\n");
        }

        public bool CheckNames(string fishName)
        {
            bool alreadyInAquarium = false;

            for (int i = 0; i < _fishInAquarium.Count; i++)
            {
                if (_fishInAquarium[i].Name == fishName)
                {
                    alreadyInAquarium = true;
                    break;
                }
                else
                {
                    alreadyInAquarium = false;
                }
            }

            return alreadyInAquarium;
        }

        private void ShowInhabitants()
        {
            foreach (var fish in _fishInAquarium)
            {
                fish.Showinfo();
            }
        }

        private void FishList()
        {
            _fishs.Add(new Fish("Скат", 23));
            _fishs.Add(new Fish("Бычок", 6));
            _fishs.Add(new Fish("Сомик", 10));
            _fishs.Add(new Fish("Илистый прыгун", 3));
            _fishs.Add(new Fish("Пескарь", 7));
            _fishs.Add(new Fish("Угорь", 12));
            _fishs.Add(new Fish("Рыба игла", 10));
        }
    }
}
