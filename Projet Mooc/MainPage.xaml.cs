using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System.Text;
using System.IO;
using Windows.Storage;

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
        
        public MainPage()
        {
            this.InitializeComponent();
            setNbCoups(0);
            defaut = (SolidColorBrush)button11.Background;
            mapButtonToPlateau();
            button11.Click += any_button_Click;
            button12.Click += any_button_Click;
            button13.Click += any_button_Click;
            button21.Click += any_button_Click;
            button22.Click += any_button_Click;
            button23.Click += any_button_Click;
            button31.Click += any_button_Click;
            button32.Click += any_button_Click;
            button33.Click += any_button_Click;
            appBarButtonCancel.Click += any_button_Click;
            





        }
        #region Events_buttons

     

        private void button_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 1;
            clic.Y = 1;
            p.JouerCoup(clic);
                      
        }
        private void button12_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 1;
            clic.Y = 2;
            p.JouerCoup(clic);
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 1;
            clic.Y = 3;
            p.JouerCoup(clic);
        }

        private void button21_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 2;
            clic.Y = 1;
            p.JouerCoup(clic);
        }

        private void button22_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 2;
            clic.Y = 2;
            p.JouerCoup(clic);
        }

        private void button23_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 2;
            clic.Y = 3;
            p.JouerCoup(clic);
        }

        private void button31_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 3;
            clic.Y = 1;
            p.JouerCoup(clic);
        }

        private void button32_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 3;
            clic.Y = 2;
            p.JouerCoup(clic);

        }

        private void button33_Click(object sender, RoutedEventArgs e)
        {
            clic.X = 3;
            clic.Y = 3;
            p.JouerCoup(clic);
            
        }
        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            p = new Partie();
            mapButtonToPlateau();
            setNbCoups(p.CoupList.Count());
            textBlockVictoire.Text = String.Empty;
            button11.IsEnabled = true;
            button12.IsEnabled = true;
            button13.IsEnabled = true;
            button21.IsEnabled = true;
            button22.IsEnabled = true;
            button23.IsEnabled = true;
            button31.IsEnabled = true;
            button32.IsEnabled = true;
            button33.IsEnabled = true;
            validatebtn.IsEnabled = false;
            appBarButtonCancel.IsEnabled = false;
            nomField.Text = String.Empty;
            nomText.Text = String.Empty;
            nomField.IsEnabled = false;
            textBlockscore.Text = String.Empty;
            

        }

        private void appBarButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                coup last = p.CoupList.Pop();
                p.Plateau.appliqueCoup(last);
            }
            catch (InvalidOperationException)
            {}
            
        }




        private async void any_button_Click(object sender, RoutedEventArgs e)
        {
            int a = p.CoupList.Count();
            setNbCoups(a);
            var isWin = await Task.Run<Boolean>(() =>
           {
               return p.Plateau.PlateauGagnant();
           });
            if (isWin)
            {
                textBlockVictoire.Text = "Victoire !";
                button11.IsEnabled = false;
                button12.IsEnabled = false;
                button13.IsEnabled = false;
                button21.IsEnabled = false;
                button22.IsEnabled = false;
                button23.IsEnabled = false;
                button31.IsEnabled = false;
                button32.IsEnabled = false;
                button33.IsEnabled = false;
                await afficheTextScore();
                
            }
            mapButtonToPlateau();
            if (p.CoupList.Count == 0 || isWin)
                appBarButtonCancel.IsEnabled = false;
            else
                appBarButtonCancel.IsEnabled = true;

        }

        private async void validatebtn_Click(object sender, RoutedEventArgs e)
        {
            await WriteFile();
            validatebtn.IsEnabled = false;
            await afficheTextScore();
            validatebtn.IsEnabled = false;
            nomField.Text = String.Empty;
            nomText.Text = String.Empty;
            nomField.IsEnabled = false;

        }

        


        #endregion
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

        private void setNbCoups(int nb)
        {
            textBlock1.Text = String.Format("Nombre de coups joués: {0}", nb.ToString());
            
        }

        public async Task WriteFile()
        {
            string filePath = @"Scores.txt";
            string nom = String.Empty;
            string text = String.Format("{0}    {1}     {2}\n", nomField.Text, p.CoupList.Count, DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy"));
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.CreateFileAsync(filePath, CreationCollisionOption.OpenIfExists);


            await WriteTextAsync(file, text);
        }

        private async Task WriteTextAsync(StorageFile filePath, string text)
        {


            await Windows.Storage.FileIO.AppendTextAsync(filePath, text);
        }


        public async Task ReadFile()
        {
            string filePath = @"Scores.txt";
            try
            {
                string text = await ReadTextAsync(filePath);
                textBlockscore.Text = text;
            }
            catch (Exception)
            {}

        }

        private async Task<string> ReadTextAsync(string filePath)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile storageFile = await storageFolder.GetFileAsync(filePath);
            StringBuilder sb = new StringBuilder();

            var buffer = await FileIO.ReadBufferAsync(storageFile);
            using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
            {
                string text = dataReader.ReadString(buffer.Length);
                return text;
            }
                       
        }

        private async Task afficheTextScore()
        {
            nomText.Text = "Nom:";
            nomField.IsEnabled = true;
            validatebtn.IsEnabled = true;
            await ReadFile();

        }




        #endregion


    }
}
