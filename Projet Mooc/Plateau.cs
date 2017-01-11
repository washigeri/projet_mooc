using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Mooc
{
    enum Couleur {Noir, Blanc };
    
    class Plateau
        {
        private Couleur[,] cases;
        


        internal Couleur[,] Cases
        {
            get
            {
                return cases;
            }

            set
            {
                cases = value;
            }
        }

        public Plateau()
        {
            Cases = new Couleur[3,3]{ { Couleur.Noir, Couleur.Noir, Couleur.Noir}, { Couleur.Noir, Couleur.Noir, Couleur.Noir}, { Couleur.Noir, Couleur.Noir, Couleur.Noir} };
            
        }

        public bool PlateauGagnant()
        {
            int a = 0;
            foreach(Couleur col in Cases)
            {
                if (col == Couleur.Blanc)
                    a++;
            }
            return (a == 9);
        }

        public void appliqueCoup(coup clic)
        {
            string str = clic.X.ToString() + clic.Y.ToString();
            switch (str)
            {
                case "11":
                    Cases[0,0] = 1 - Cases[0,0];
                    Cases[0, 1] = 1 - Cases[0, 1];
                    Cases[1, 0] = 1 - Cases[1, 0];
                    Cases[1, 1] = 1 - Cases[1, 1];
                    break;
                case "12":
                    for (int i = 0; i < 3; i++)
                        Cases[0, i] = 1 - Cases[0, i];
                    break;
                case "13":
                    Cases[0, 2] = 1 - Cases[0, 2];
                    Cases[0, 1] = 1 - Cases[0, 1];
                    Cases[1, 2] = 1 - Cases[1, 2];
                    Cases[1, 1] = 1 - Cases[1, 1];
                    break;
                case "21":
                    for( int i = 0; i< 3; i++)
                    {
                        Cases[i, 0] = 1 - Cases[i, 0];
                    }
                    break;
                case "22":
                    Cases[0, 1] = 1 - Cases[0, 1];
                    Cases[2, 1] = 1 - Cases[2, 1];
                    for(int i = 0; i< 3; i++)
                    {
                        Cases[1, i] = 1 - Cases[1, i];
                    }
                    break;
                case "23":
                    for (int i = 0; i < 3; i++)
                        Cases[2, i] = 1 - Cases[2, i];
                    break;
                case "31":
                    Cases[2, 0] = 1 - Cases[2, 0];
                    Cases[2, 1] = 1 - Cases[2, 1];
                    Cases[1, 0] = 1 - Cases[1, 0];
                    Cases[1, 1] = 1 - Cases[1, 1];
                    break;
                case "32":
                    for (int i = 0; i < 3; i++)
                        Cases[2, i] = 1 - Cases[2, i];
                    break;
                case "33":
                    Cases[2, 2] = 1 - Cases[2, 2];
                    Cases[2, 1] = 1 - Cases[2, 1];
                    Cases[1, 2] = 1 - Cases[1, 2];
                    Cases[1, 1] = 1 - Cases[1, 1];
                    break;
            }
        }

    }
}
