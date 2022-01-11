using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace XO
{
    class Game
    {
        private Joueur j1;
        private Joueur j2;
        private char[][] game_table;
        private int nb_check;
        /*********************/
        public Game(Joueur J1, Joueur J2)
        {
            this.game_table = new char[9][];
            for(int i=0;i<9;i++)
            { 
                this.game_table[i] = new char[9]; 
            }
            this.j1 = J1;
            this.j2 = J2;
            this.nb_check = 0;
            //initialisation de la table
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.game_table[i][j] = '-';
                }
            }
        }

        public void show_table()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(this.game_table[i][j]+"\t");
                }
                Console.Write("\n");
            }
        }
        public void remplir_table(int i,int j,char car)
        {
            this.game_table[i][j] = car;
        }
        public bool game_over()
        {
            if (this.nb_check == 9) return true;
            return false;
        }

        public bool case_libre(int i,int j)
        {
            if (!this.j1.case_existe(i, j) && !this.j2.case_existe(i, j)) return true;
            return false;
        }
        
        public void insert_case(char n ,Joueur j)
        {
            switch(n)
            {
                case '1': j.add_case(0, 0); this.remplir_table(0,0,j.car); break;
                case '2': j.add_case(0, 1); this.remplir_table(0, 1, j.car); break;
                case '3': j.add_case(0, 2); this.remplir_table(0, 2, j.car); break;
                case '4': j.add_case(1, 0); this.remplir_table(1, 0, j.car); break;
                case '5': j.add_case(1, 1); this.remplir_table(1, 1, j.car); break;
                case '6': j.add_case(1, 2); this.remplir_table(1, 2, j.car); break;
                case '7': j.add_case(2, 0); this.remplir_table(2, 0, j.car); break;
                case '8': j.add_case(2, 1); this.remplir_table(2, 1, j.car); break;
                case '9': j.add_case(2, 2); this.remplir_table(2, 2, j.car); break;
            }

        }
        public bool choix_valide(char n)
        {
            switch (n)
            {
                case '1': return case_libre(0,0); 
                case '2': return case_libre(0,1); 
                case '3': return case_libre(0, 2); 
                case '4': return case_libre(1, 0); 
                case '5': return case_libre(1, 1);
                case '6': return case_libre(1, 2);
                case '7': return case_libre(2, 0);
                case '8': return case_libre(2, 1);
                case '9': return case_libre(2, 2);
            }
            return false;

        }
        bool show_winner(Joueur j)
        {
            if(j.is_winner())
            {
                this.show_table();
                Console.Write("\nle joueur ");
                j.show_name();
                Console.Write(" a gagner\n");
                return true;
            }
            return false;
        }


        public void jouer()
        {
            char n;
            while (!this.game_over())
            {
                do
                {
                    this.show_table();
                    Console.WriteLine("Joueur 1: choisisez une case");
                    n = Char.Parse( Console.ReadLine());
                } while (!this.choix_valide(n));
                this.nb_check++;
                Console.WriteLine(this.nb_check);
                this.insert_case(n, j1);
                if (this.show_winner(j1)) return;
                do
                {
                    this.show_table();
                    Console.WriteLine("Joueur 2: choisisez une case");
                     n = Char.Parse(Console.ReadLine());
                } while (!this.choix_valide(n));
                this.insert_case(n, j2);
                this.nb_check++;
                if (this.show_winner(j2)) return;
                
            }
            Console.WriteLine("Personne n'a gagner ");
        }

    }
}
