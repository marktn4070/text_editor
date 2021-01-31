using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Data;

namespace CoronaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] municipalityNames { get; set; }
        public MainWindow()
        {
            InitializeComponent();


            municipalityNames = new string[] { "Albertslund", "Allerød", "Assens", "Ballerup", "Billund", "Bornholm", "Brøndby", "Brønderslev",
                "Christiansø", "Dragør", "Egedal", "Esbjerg", "Fanø", "Favrskov", "Faxe", "Fredensborg", "Fredericia", "Frederiksberg",
                "Frederikshavn", "Frederikssund", "Furesø", "Faaborg-Midtfyn", "Gentofte", "Gladsaxe", "Glostrup", "Greve", "Gribskov",
                "Guldborgsund", "Haderslev", "Halsnæs", "Hedensted", "Helsingør", "Herlev", "Herning", "Hillerød", "Hjørring", "Holbæk",
                "Holstebro", "Horsens", "Hvidovre", "Høje-Taastrup", "Hørsholm", "Ikast-Brande", "Ishøj", "Jammerbugt", "Kalundborg",
                "Kerteminde", "Kolding", "København", "Køge", "Langeland", "Lejre", "Lemvig", "Lolland", "Lyngby-Taarbæk", "Læsø",
                "Mariagerfjord", "Middelfart", "Morsø", "Norddjurs", "Nordfyns", "Nyborg", "Næstved", "Odder", "Odense", "Odsherred",
                "Randers", "Rebild", "Ringkøbing-Skjern", "Ringsted", "Roskilde", "Rudersdal", "Rødovre", "Samsø", "Silkeborg", "Skanderborg",
                "Skive", "Slagelse", "Solrød", "Sorø", "Stevns", "Struer", "Svendborg", "Syddjurs", "Sønderborg", "Thisted", "Tønder", "Tårnby",
                "Vallensbæk", "Varde", "Vejen", "Vejle", "Vesthimmerlands", "Viborg", "Vordingborg", "Ærø", "Aabenraa", "Aalborg", "Aarhus"
            };
            DataContext = this;
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileLocation.Text = openFileDialog.FileName;
            }
        }

        private void ToDataPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CSVdatareader();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CSVdatareader()
        {
            DataPage dataPage = new DataPage();
            string linje = "";

            string[] csvLines = File.ReadAllLines(FileLocation.Text);
            for (int i = 1; i < csvLines.Length; i++)
            {
                if (csvLines[i].Contains(Kommunevalg.Text))
                {
                    linje = csvLines[i];
                }



            }

            string[] rowdata = linje.Split(';');
            dataPage.MnicipalityID = rowdata[0];

            dataPage.Testede = rowdata[2];
            dataPage.Bekræftede = rowdata[3];
            dataPage.Kumulative = rowdata[5];
            dataPage.Befolningstal = rowdata[4];
            dataPage.Show();
            dataPage.KommuneNavn = Kommunevalg.Text;





        }

        private void Minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
