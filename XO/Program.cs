using System;

namespace XO
{
    class Program
    {
        static void Main(string[] args)
        {
            Joueur j1=new Joueur("hiba",'x');
            Joueur j2=new Joueur("j2",'O');
            Game MyGame=new Game(j1,j2);
            MyGame.jouer();
        }
    }
}
