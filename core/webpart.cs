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
using System.Threading;
using System.Reflection;

namespace netretis.core
{
    public class webpart
    {
        public string xmlOutput;
        public PhoneApplicationPage myPageInstance;

        public string webparts_list_viewstate(string viewstate, string applicazione)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_webpart_list_viewstate);

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



      


        public string getWebPartbyViewState_STATIC(string viewstate, string applicazione, PhoneApplicationPage pageInstance)
        {

            myPageInstance = pageInstance;
           
            string xmlString = "";

            if (viewstate == "ANNOUNCE_FINDCAR_SELECTSLOT")
            {
                XDocument page = XDocument.Load(inputMessages.xmlOutputDIR + "/" + "template.social.webpart.FINDCAR_selectSlot.xml");
                xmlString = page.ToString();
                               
            }


            if (viewstate == "ANNOUNCE_FINDCAR")
            {
                XDocument page = XDocument.Load(inputMessages.xmlOutputDIR + "/" + "template.social.webpart.FINDCAR.xml");
                xmlString = page.ToString();

            }





            XDocument loaded = XDocument.Parse(xmlString);
            RemoveNamespace(loaded);

            var items = from x in loaded.Descendants("dati")
                        select new NewsItem
                        {
                            PlaceHolder = x.Element("PlaceHolder").Value,
                            webPart = x.Element("webPart").Value,
                            component = x.Element("page").Value
                        };

            foreach (var item in items)
            {


                loadControl(item.component, item.PlaceHolder);


            }


            return "";
           


        }


      

        public class NewsItem
        {
            public string PlaceHolder { get; set; }
            public string webPart { get; set; }
            public string component { get; set; }


        }


        public void loadControl(string nomeControllo, string placeHolder)
        {
            Type controlRef = Assembly.GetExecutingAssembly().GetType(nomeControllo);
            UIElement control = (UIElement)Activator.CreateInstance(controlRef);

            StackPanel stackPNL = (StackPanel)myPageInstance.FindName(placeHolder);
            stackPNL.Children.Add(control);

        }

    }
}
