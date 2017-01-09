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
        private List<coup> coupList;

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

        internal List<coup> CoupList
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
            CoupList = new List<coup>();

        }

        public bool JouerCoup(coup clic)
        {
            this.Plateau.appliqueCoup(clic);
            this.coupList.Add(clic);
            return (this.Plateau.EstGagnant);
        }


    }
}
