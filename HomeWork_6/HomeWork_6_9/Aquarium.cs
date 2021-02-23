using System;
using System.Collections.Generic;
using System.Text;

//Есть аквариум, в котором плавают рыбы. В этом аквариуме может быть не больше определенного количества рыб.
//Рыб можно как добавить так и убрать из аквариума.(Программа должна быть в цикле для того чтоб рыбы могли жить.)
//Все рыбы отображаются списком, так же у рыб есть возраст. За 1 итерацию рыбы стареют на определенное количество жизней и могут умереть.
//Рыб так же вывести в консоль, чтоб можно было мониторить показатели.

namespace HomeWork_6_9
{
    class Aquarium
    {
        private int _placeAmount = 10;
        private List<Fish> _fishInAquarium = new List<Fish>();
        private List<Fish> _fish = new List<Fish>();

        private void AllFish()
        {
            _fish.Add(new Fish(""))
        }

        public void AddFish()
        {

        }

        public void ShowInhabitants()
        {
            for (int i = 0; i < _fish.Count; i++)
            {
                _fish[i].Showinfo();
            }
        }
    }
}
