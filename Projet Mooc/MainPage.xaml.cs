using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Projet_Mooc
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        coup clic = new coup();
        Partie p = new Partie();
        SolidColorBrush defaut;
        List<Button> buttonTab;
        public MainPage()
        {
            this.InitializeComponent();
            buttonTab = new List<Button>(9);
            buttonTab.Add(button11);
            buttonTab.Add(button12);
            buttonTab.Add(button13);
            buttonTab.Add(button21);
            buttonTab.Add(button22);
            buttonTab.Add(button23);
            buttonTab.Add(button31);
            buttonTab.Add(button32);
            buttonTab.Add(button33);
            defaut = (SolidColorBrush)button11.Background;
            mapButtonToPlateau();
            



        }
        
        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 1;
            clic.Y = 1;
            p.JouerCoup(clic);
            mapButtonToPlateau();
                      
        }
        #region Méthodes pour modifier plateau et bouttons

        private void mapButtonToPlateau()
        {
            Couleur[,] plat = p.Plateau.Cases;
            for(int i = 0; i<3; i++)
            {
                for(int j = 0; j<3; j++)
                {
                    int a = (i + 1) * 10 + (j+1);
                    switch (a)
                    {
                        case 11:
                            button11.Background = matchCellToColor(plat[0, 0]);
                            break;
                        case 12:
                            button12.Background = matchCellToColor(plat[0, 1]);
                            break;
                        case 13:
                            button13.Background = matchCellToColor(plat[0, 2]);
                            break;
                        case 21:
                            button21.Background = matchCellToColor(plat[1, 0]);
                            break;
                        case 22:
                            button22.Background = matchCellToColor(plat[1, 1]);
                            break;
                        case 23:
                            button23.Background = matchCellToColor(plat[1, 2]);
                            break;
                        case 31:
                            button31.Background = matchCellToColor(plat[2, 0]);
                            break;
                        case 32:
                            button32.Background = matchCellToColor(plat[2, 1]);
                            break;
                        case 33:
                            button33.Background = matchCellToColor(plat[2, 2]);
                            break;

                    }
                }
            }
        }

        private SolidColorBrush matchCellToColor(Couleur c)
        {
            if (c == Couleur.Noir)
                return defaut;
            else
                return (new SolidColorBrush(Windows.UI.Colors.WhiteSmoke));  
        }
        #endregion
        private void button12_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 1;
            clic.Y = 2;
            p.JouerCoup(clic);
            mapButtonToPlateau();
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 1;
            clic.Y = 3;
            p.JouerCoup(clic);
            mapButtonToPlateau();
        }

        private void button21_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 2;
            clic.Y = 1;
            p.JouerCoup(clic);
            mapButtonToPlateau();
        }

        private void button22_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 2;
            clic.Y = 2;
            p.JouerCoup(clic);
            mapButtonToPlateau();
        }

        private void button23_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 2;
            clic.Y = 3;
            p.JouerCoup(clic);
            mapButtonToPlateau();
        }

        private void button31_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 3;
            clic.Y = 1;
            p.JouerCoup(clic);
            mapButtonToPlateau();
        }

        private void button32_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 3;
            clic.Y = 2;
            p.JouerCoup(clic);
            mapButtonToPlateau();
        }

        private void button33_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 3;
            clic.Y = 3;
            p.JouerCoup(clic);
            mapButtonToPlateau();
        }
    }
}
