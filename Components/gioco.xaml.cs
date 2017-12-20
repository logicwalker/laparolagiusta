using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.Xml.Linq;
using System.IO;

using Microsoft.Phone.Controls;
using netretis.Resources;


using System.Device.Location;
using System.IO.IsolatedStorage;
using System.Windows.Navigation;
using System.Windows.Controls.Primitives;
using netretis;
using Microsoft.Phone.Shell;
using System.Threading;
using Microsoft.Phone.Tasks;

namespace netretis
{
    public partial class gioco : UserControl
    {


        int nPunteggio = 0;
        int nAiuto = 0;
        bool bIndovinato = false;

        const string strDataFileEnablePos = "data.gps";
        const string strDataFileEnablePos2Tiinx = "data.gps2Tiinx";
        netretis.core.SaveLoadLocal SaveLoadObj = new netretis.core.SaveLoadLocal();

        Microsoft.Phone.Marketplace.LicenseInformation license = new Microsoft.Phone.Marketplace.LicenseInformation();
        public MarketplaceDetailTask detailTask = new MarketplaceDetailTask();



        // Isostorage is used to maintain the saved geo-location across app sessions
        IsolatedStorageFile isoStore;
        const string strDataFile = "data.bin";




        // Constructor
        public gioco()
        {
            InitializeComponent();


            isoStore = IsolatedStorageFile.GetUserStoreForApplication();

            nPunteggio = SaveLoadObj.LoadFromIsoStore("punteggio");
            punteggio.Text = "Punteggio: " + nPunteggio;

        }




        public static XDocument RemoveNamespace(XDocument xDocument)
        {
            foreach (XElement oElement in xDocument.Root.DescendantsAndSelf())
            {
                if (oElement.Name.Namespace != XNamespace.None)
                {
                    oElement.Name = XNamespace.None.GetName(oElement.Name.LocalName);
                }
                if (oElement.Attributes().Where(a => a.IsNamespaceDeclaration || a.Name.Namespace != XNamespace.None).Any())
                {
                    oElement.ReplaceAttributes(oElement.Attributes().Select(a => a.IsNamespaceDeclaration ? null : a.Name.Namespace != XNamespace.None ? new XAttribute(XNamespace.None.GetName(a.Name.LocalName), a.Value) : a));
                }
            }

            return xDocument;
        }





        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            gioca();


        }


        public class NewsItem
        {
            public string parola1_SX { get; set; }
            public string parola1_DX { get; set; }
            public string parola2_SX { get; set; }
            public string parola2_DX { get; set; }
            public string parola3_SX { get; set; }
            public string parola3_DX { get; set; }
            public string soluzione { get; set; }

        }

        private void txtindovina_TextChanged(object sender, TextChangedEventArgs e)
        {


            string trattini = "";
            if (txtindovina.Text.ToString().Length <= soluzione.Text.ToString().Length)
            {
                for (int i = 0; i < soluzione.Text.ToString().Length - txtindovina.Text.ToString().Length; i++)
                    trattini = trattini + "_ ";

                txttrattini1.Text = txtindovina.Text.ToUpper() + trattini;
                txttrattini2.Text = txtindovina.Text.ToUpper() + trattini;
                txttrattini3.Text = txtindovina.Text.ToUpper() + trattini;


                parola1.Text = parola1sx.Text + txttrattini1.Text + parola1dx.Text;
                parola2.Text = parola2sx.Text + txttrattini2.Text + parola2dx.Text;
                parola3.Text = parola3sx.Text + txttrattini3.Text + parola3dx.Text;
            }










        }

        private void gioca()
        {

            button1.Visibility = Visibility.Collapsed;


            // UTENTE HA ABILITATO IL GPS
            if (SaveLoadObj.LoadFromIsoStore(strDataFileEnablePos) == 0)
            {

                SaveLoadObj.SaveToIsoStore(strDataFileEnablePos, 1);

            }


            string posizione = SaveLoadObj.LoadFromIsoStore(strDataFileEnablePos).ToString();

            txtnumparola.Text = posizione;



            XDocument page = XDocument.Load(inputMessages.xmlDatiDir + "/" + posizione + ".xml");
            string xmlString = page.ToString();


            XDocument loaded = XDocument.Parse(xmlString);
            RemoveNamespace(loaded);

            var items = from x in loaded.Descendants("dati")
                        select new NewsItem
                        {
                            parola1_SX = x.Element("parola1_SX").Value,
                            parola1_DX = x.Element("parola1_DX").Value,
                            parola2_SX = x.Element("parola2_SX").Value,
                            parola2_DX = x.Element("parola2_DX").Value,
                            parola3_SX = x.Element("parola3_SX").Value,
                            parola3_DX = x.Element("parola3_DX").Value,
                            soluzione = x.Element("soluzione").Value
                        };

            string trattini = "";

            foreach (var item in items)
            {

                parola1sx.Text = item.parola1_SX;
                parola2sx.Text = item.parola2_SX;
                parola3sx.Text = item.parola3_SX;
                parola1dx.Text = item.parola1_DX;
                parola2dx.Text = item.parola2_DX;
                parola3dx.Text = item.parola3_DX;

                soluzione.Text = item.soluzione;
                txtnumlettere.Text = "Parola di " + soluzione.Text.Length.ToString() + " lettere";


                if (soluzione.Text.Length == 3)
                    trattini = "_ _ _";
                else if (soluzione.Text.Length == 4)
                    trattini = "_ _ _ _";
                else if (soluzione.Text.Length == 5)
                    trattini = "_ _ _ _ _";

                txttrattini1.Text = trattini;
                txttrattini2.Text = trattini;
                txttrattini3.Text = trattini;

                string sparola1 = "";
                string sparola2 = "";
                string sparola3 = "";

                sparola1 = parola1sx.Text + txttrattini1.Text + parola1dx.Text;
                sparola2 = parola2sx.Text + txttrattini2.Text + parola2dx.Text;
                sparola3 = parola3sx.Text + txttrattini3.Text + parola3dx.Text;
                parola1.Text = sparola1;
                parola2.Text = sparola2;
                parola3.Text = sparola3;

            }





        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int posizione = SaveLoadObj.LoadFromIsoStore(strDataFileEnablePos);
            if (!license.IsTrial())
            {

                posizione++;

                if (posizione == 106)
                    posizione = 1;

                SaveLoadObj.SaveToIsoStore(strDataFileEnablePos, posizione);

                int punti = 1;
                if (nAiuto == soluzione.Text.Length)
                    punti = 0;

                nPunteggio = SaveLoadObj.LoadFromIsoStore("punteggio") - nAiuto + punti;
                SaveLoadObj.SaveToIsoStore("punteggio", nPunteggio);
                punteggio.Text = "Punteggio: " + nPunteggio;

                txtindovina.Text = "";

                nAiuto = 0;

                gioca();
            }
            else
            {

                if (posizione < 10)
                {

                    posizione++;
                    SaveLoadObj.SaveToIsoStore(strDataFileEnablePos, posizione);
                    txtindovina.Text = "";
                    nAiuto = 0;
              
                    gioca();
                } 
                else 
                detailTask.Show();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {


            if (txtindovina.Text.ToUpper().Trim() == soluzione.Text.ToUpper())
            {
                bIndovinato = true;
                MessageBoxResult result = MessageBox.Show("Hai indovinato", "Congratulazioni", MessageBoxButton.OK);



                button1.Visibility = Visibility.Visible;


            }
            else
            {
                bIndovinato = false;
                MessageBoxResult result = MessageBox.Show("Non hai indovinato... ritenta.", "Peccato", MessageBoxButton.OK);



            }

        }

        private void aiuto_Click(object sender, RoutedEventArgs e)
        {

            nAiuto++;
            if (nAiuto <= soluzione.Text.ToString().Length)
            {
                MessageBoxResult result = MessageBox.Show(soluzione.Text.ToString().Substring(0, nAiuto), "Aiuto", MessageBoxButton.OK);

            }
        }









    }
}