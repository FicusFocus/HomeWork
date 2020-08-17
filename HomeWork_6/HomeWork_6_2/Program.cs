using System;
using System.Dynamic;

namespace HomeWork_6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(7, 7);
            Renderer render = new Renderer();

            render.DrowPosition(player.PositionX, player.PositionY);
        }
    }

    class Player
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public Player(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }
    }

    class Renderer
    {
        public void DrowPosition(int x, int y, char positionSimbool = 'Ж')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(positionSimbool);
        }
    }
}
