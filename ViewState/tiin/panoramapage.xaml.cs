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
using Microsoft.Phone.Controls;
using netretis.Resources;
using Microsoft.Phone.Shell;
using netretis;
using System.Globalization;
using Microsoft.Phone.Tasks;
using System.IO;

namespace netretis
{
    public partial class panoramapage : PhoneApplicationPage
    {
        bool bloaded;
        

        const string strDataFileEnablePos = "data.gps";

        public panoramapage()
        {
            InitializeComponent();
           
            App.GB.ViewState = "ANNOUNCE_FINDCAR";
         
            this.SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

          

        }



        void impostazioniGPS_Click(object sender, EventArgs e)
        {

            this.NavigationService.Navigate(new Uri("/ViewState/tiin/GPS_Settings.xaml", UriKind.Relative));


        }

        
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);


            netretis.core.webpart objwebPart = new netretis.core.webpart();
            objwebPart.getWebPartbyViewState_STATIC(App.GB.ViewState, inputMessages.applicazione, this);


     

        
        }


        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;

            //AlmavivASocial_WP7.core.viewState objViewsState = new AlmavivASocial_WP7.core.viewState();
            //string strViewState = objViewsState.getViewState("ANNOUNCE_TYPE_LIST", "SocialWP", "vs=ANNOUNCE_TYPE_LIST");

            App.GB.exit = true;

        }


        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
           
            // Se l'utente ha autorizzato l'uso della posizione 
            netretis.core.SaveLoadLocal SaveLoadObj;
            SaveLoadObj = new netretis.core.SaveLoadLocal();
            bloaded = true;


            //Home page
            TextReader tr = new StreamReader(Application.GetResourceStream(new Uri("html" + "/" + "tab1.html", UriKind.Relative)).Stream);

            string htmlText1 = tr.ReadToEnd();
            tab1.NavigateToString(htmlText1);


            

        }

        private void PhoneApplicationPage_GotFocus(object sender, RoutedEventArgs e)
        {

          

        }

        private void pivot1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //if (App.GB.NameSlot != "")
            //    Slot.Header = App.GB.NameSlot;
            //Slot.UpdateLayout();


        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = "information@netretis.com";
            emailComposeTask.Body = "Richiesta di informazioni (YourPlaces)";

            emailComposeTask.Subject = "Richiesta di informazioni (YourPlaces)";
            emailComposeTask.Show();

        }

        private void tab2_Loaded(object sender, RoutedEventArgs e)
        {
            //Home page
            TextReader tr = new StreamReader(Application.GetResourceStream(new Uri("html" + "/" + "tab2.html", UriKind.Relative)).Stream);

            string htmlText2 = tr.ReadToEnd();
            tab2.NavigateToString(htmlText2);


        }





    }
}