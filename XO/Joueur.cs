using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace XO
{
    public class Indices
    {
        private int i;
        private int j;

        public Indices(int l,int c)
        {
            this.i = l;
            this.j = c;
        }
        public bool ind_equals(int l,int c)
        {
            if (i == l && j == c) return true;
            return false;
        }
    }
    class Joueur
    {
        private string name;
        public char car;
        private List<Indices> res_j= new List<Indices>();
        private int nb;
        public Joueur(string name, char car)
        {
            this.name = name;
            this.car = car;
            nb = 0;
        }

        public void show_name()
        {
            Console.WriteLine(this.name);
        }
        public void add_case(int i,int j)
        {
            Indices IN= new Indices(i, j);
            this.res_j.Add(IN);
            this.nb++;
        }
        public bool is_winner()
        {
            if (this.nb>=3)
            {
                //diagonal
                int cpt = 0;
                for (int i = 0; i < 3; i++) if (this.case_existe(i, i)) cpt++;
                if (cpt == 3) return true;
                //inv diagonal
                cpt = 0;
                for (int i = 0; i < 3; i++) if (this.case_existe(i,3-(i+1))) cpt++;
                if (cpt == 3) return true;
                //même ligne
                for (int i = 0; i < 3; i++)
                {
                    cpt = 0;
                    for (int k = 0; k < 3; k++) if (this.case_existe(i, k)) cpt++;
                    if (cpt == 3) return true;
                }
                //même colonne
                for (int i = 0; i < 3; i++)
                {
                    cpt = 0;
                    for (int k = 0; k < 3; k++) if (this.case_existe(k, i)) cpt++;
                    if (cpt == 3) return true;
                }
            }
            return false;
        }
        public bool case_existe(int l, int c)
        {
            for (int k = 0; k <this.nb;k++)
            {
                if (this.res_j[k].ind_equals(l,c)) return true;
            }
            return false;
        }

    }
}
