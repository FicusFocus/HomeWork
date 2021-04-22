using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork6_10_Zoo
{
    class Zoo
    {
        private List<Aviary> _aviarys = new List<Aviary>();

        public Zoo()
        {
            AddAviarys();
        }

        public void ShowAviaryInfo(int aviaryNumber)
        {
            
        }

        public void AddAviarys()
        {
            _aviarys.Add(new Aviary(4, "Elephant", "toot"));
            _aviarys.Add(new Aviary(15, "Parrot", "tweet"));
            _aviarys.Add(new Aviary(8, "Seal", "ow-ow-ow"));
            _aviarys.Add(new Aviary(5, "Lion", "roar"));
            _aviarys.Add(new Aviary(10, "Hyena", "laugh"));
            _aviarys.Add(new Aviary(8, "Dingo", "woof"));
            _aviarys.Add(new Aviary(9, "Fox", "What does the fox say? ヽ(ﾟ〇ﾟ)/"));
        }
    }
}
