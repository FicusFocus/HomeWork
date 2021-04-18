﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork6_10_Zoo
{
    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();
        private int _plaseAmount;
        private string _name;
        private string _gender;
        private string _sound;

        public Aviary(int plaseAmount, string name, string sound)
        {
            _plaseAmount = plaseAmount;
            _name = name;
            _gender = RandomGender();
            _sound = sound;
        }

        public void FillTheAviary()
        {
            for (int i = 0; i < _plaseAmount; i++)
            {
                _animals.Add(new Animal(_name + (i + 1), _sound, _gender));
            }
        }

        private string RandomGender()
        {
            Random rand = new Random();
            List<string> genders = new List<string>();
            genders.Add("male");
            genders.Add("female");

            int randomGender = rand.Next(0, genders.Count);

            return genders[randomGender];
        }
    }
}