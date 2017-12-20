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
using netretis.core;

using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Threading;
using PanoramaApp1;

namespace netretis
{
    public partial class MainPage : PhoneApplicationPage
    {

        private Popup popup;
        private BackgroundWorker backroungWorker;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
         
         //   if (App.GB.startup) 
                ShowPopup();

            
        }

        private void ShowPopup()
        {
            
            this.popup = new Popup();
            this.popup.Child = new PopupSplash();
            this.popup.IsOpen = true;
            StartLoadingData();
        }

        private void StartLoadingData()
        {
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();

        
        }

        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;

            }
            );
        }

        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do some data loading on a background
            // We'll just sleep for the demo
            Thread.Sleep(3000);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

       //     if (App.GB.exit != true)
      //      {
                netretis.core.viewState objViewsState = new netretis.core.viewState();
                           string strViewState = objViewsState.getViewState_STATIC("ANNOUNCE_FINDCAR", "SocialWP", "vs=ANNOUNCE_TYPE_LIST");

                //NavigationService.Navigate(new Uri(objViewsState.getViewState("DEFAULT", "SocialWP"), UriKind.Relative));
      //      } 

        }   


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

          //   if (App.GB.exit == true)
          //             NavigationService.GoBack();

        }

    }
}
