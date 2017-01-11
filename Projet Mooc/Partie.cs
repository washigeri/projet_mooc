using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Mooc
{
    struct coup { int x; int y;

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }
         
    class Partie
    {
        private Plateau plateau;
        private Stack<coup> coupList;

        internal Plateau Plateau
        {
            get
            {
                return plateau;
            }

            set
            {
                plateau = value;
            }
        }

        internal Stack<coup> CoupList
        {
            get
            {
                return coupList;
            }

            set
            {
                coupList = value;
            }
        }

        public Partie()
        {
            Plateau = new Plateau();
            CoupList = new Stack<coup>();

        }

        public void JouerCoup(coup clic)
        {
            Plateau.appliqueCoup(clic);
            coupList.Push(clic);
            
        }


    }
}
