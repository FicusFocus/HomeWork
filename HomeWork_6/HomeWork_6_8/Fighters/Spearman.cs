using System;
using System.Collections.Generic;
using System.Text;

//TODO: крит удаор + 70% урона, шанс 40%. Наложить повязку. 
//TODO: Периодическое лечение не 3 хода + 50 HP за тик. В перезаписи TakeDamage есть bool  который сморит активен ли навык и считает сколько тиков осталось.
//TODO: с каждым тиком лечение увеличивается на 30 (50, 80, 110)

namespace HomeWork_6_8.Fighters
{
    class Spearman : Fighter
    {
        public Spearman(string name) : base(name, 70, 400, 20) { }
    }
}
