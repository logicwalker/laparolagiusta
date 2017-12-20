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
using netretis.Resources;

using Microsoft.Phone.Controls;

namespace netretis.core
{
    public class viewState
    {
        private string viewState_queryString;


        public string viewstate_element_viewstate(string viewstate, string applicazione)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_viewstate_element_viewstate);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("viewstate").Value = viewstate;
            page.Root.Element("parametri").Element("applicazione").Value = applicazione;


            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
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



        public string getViewState_STATIC(string viewstate, string applicazione, string queryString)
        {
              string xmlString = "";

              if (viewstate == "ANNOUNCE_FINDCAR")

             {
                 XDocument page = XDocument.Load(inputMessages.xmlOutputDIR + "/" + "template.social.viewstate.FINDCAR.xml");
                 xmlString = page.ToString();
             }

              if (viewstate == "ANNOUNCE_FINDCAR_SELECTSLOT")
              {
                  XDocument page = XDocument.Load(inputMessages.xmlOutputDIR + "/" + "template.social.viewstate.FINDCAR_selectSlot.xml");
                  xmlString = page.ToString();
              }
            
            viewState_queryString = queryString;
            //App.GB.ViewState = viewstate;
            
          

            /* mancanza di rete */
            if (xmlString != "")
            {



                XDocument loaded = XDocument.Parse(xmlString);

                RemoveNamespace(loaded);


                var items = from x in loaded.Descendants("dati")
                            select new NewsItem
                            {
                                pagina = x.Element("page").Value

                            };

                foreach (var item in items)
                {


                    PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;

                    if (frame.CurrentSource != new Uri("/" + inputMessages.viewStateDir + "/" + inputMessages.tema + "/" + item.pagina + "?" + viewState_queryString, UriKind.Relative))
                        frame.Navigate(new Uri("/" + inputMessages.viewStateDir + "/" + inputMessages.tema + "/" + item.pagina + "?" + viewState_queryString, UriKind.Relative));

                }


            }
            else
            {

                PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;

                if (frame.CurrentSource != new Uri("/" + inputMessages.viewStateDir + "/" + inputMessages.tema + "/" + "nonetwork.xaml", UriKind.Relative))
                    frame.Navigate(new Uri("/" + inputMessages.viewStateDir + "/" + inputMessages.tema + "/" + "nonetwork.xaml", UriKind.Relative));
            }


            return "";

        }





       


      

        public class NewsItem
        {
            public string pagina { get; set; }

        }


    }
}
