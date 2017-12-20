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



using System.IO.IsolatedStorage;

using System.Windows.Navigation;
using System.Windows.Controls.Primitives;
using Microsoft.Phone.Tasks;

namespace netretis
{
    public partial class inviaemail : UserControl
    {


        EmailAddressChooserTask emailAddressChooserTask;

        // Constructor
        public inviaemail()
        {
            InitializeComponent();

            emailAddressChooserTask = new EmailAddressChooserTask();
            emailAddressChooserTask.Completed += new EventHandler<EmailResult>(emailAddressChooserTask_Completed);
                     

        }



        void emailAddressChooserTask_Completed(object sender, EmailResult e)
        {
           string sBody; 

            if (e.TaskResult == TaskResult.OK)
            {
              
                EmailComposeTask emailComposeTask = new EmailComposeTask();
                sBody = "";
                emailComposeTask.Body = sBody;
      
                
                emailComposeTask.To = e.Email;
                emailComposeTask.Subject = "Lettere ad Ennio Peres"  ;
                emailComposeTask.Show();
            }
            else if (e.TaskResult == TaskResult.Cancel)
                MessageBox.Show("Cannot send email without the email address", "Email address not selected", MessageBoxButton.OK);
            else
                MessageBox.Show("Error getting email address:\n" + e.Error.Message, "Fail", MessageBoxButton.OK);
        }





        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {

            emailAddressChooserTask.Show();

            

        }

       

    }
}