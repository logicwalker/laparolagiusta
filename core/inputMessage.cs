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


namespace AlmavivASocial_WP7.Xml
{
    public class inputMessage
    {



        public string Announce_insert( string GuIdAnnounceType, string GuIdPlace, string GuIdUser, string annuncio, string descrizione)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;
            
            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_announce_insert);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("GuIdAnnounceType").Value = GuIdAnnounceType;
            page.Root.Element("parametri").Element("GuIdPlace").Value =GuIdPlace;
            page.Root.Element("parametri").Element("GuIdUser").Value = GuIdUser;
            page.Root.Element("parametri").Element("annuncio").Value = annuncio;
            page.Root.Element("parametri").Element("descrizione").Value = descrizione;
         
            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }



       


        public string AnnounceType_list(string numPagina, string numElementiPag)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_announcetype_list);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("num_pagina").Value = numPagina;
            page.Root.Element("parametri").Element("num_elementi").Value = numElementiPag;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string Commment_list(string GuIdStory, string numPagina, string numElementiPag)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_commenti_list);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("GuIdStory").Value = GuIdStory;
            page.Root.Element("parametri").Element("num_pagina").Value = numPagina;
            page.Root.Element("parametri").Element("num_elementi").Value = numElementiPag;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string Commment_insert(string GuIdStory, string GuIdUser, string Body)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_commenti_insert);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("GuIdStory").Value = GuIdStory;
            page.Root.Element("parametri").Element("GuIdUser").Value = GuIdUser;
            page.Root.Element("parametri").Element("Body").Value = Body;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string votiUtenti_element(string GuIdStory, string GuIdUser)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_votiutenti_im_element);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("GuIdStory").Value = GuIdStory;
            page.Root.Element("parametri").Element("GuIdUser").Value = GuIdUser;


            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }

        public string Attivita_Insert(string GuIdUser, string GuIdXActivity, string GuIdActivityType)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_utente_attivita_insert);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("GuIdUser").Value = GuIdUser;
            page.Root.Element("parametri").Element("GuIdXActivity").Value = GuIdXActivity;
            page.Root.Element("parametri").Element("GuIdActivityType").Value = GuIdActivityType;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string News_rank_add(string GuIdStory)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_news_addrank);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("GuIdStory").Value = GuIdStory;


            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string Voti_Utenti_Insert(string GuIdStory, string GuIdUser)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_votiutenti_im_insert);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("GuIdStory").Value = GuIdStory;
            page.Root.Element("parametri").Element("GuIdUser").Value = GuIdUser;


            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }

        public string News_List(string pag, string numpag)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_news_list);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("num_pagina").Value = pag;
            page.Root.Element("parametri").Element("num_elementi").Value = numpag;
            page.Root.Element("parametri").Element("validazione").Value = inputMessages.validazione;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string News_Insert(string GuIdUser, string Title, string Description, string articolo, string Url)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_news_insert);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("GuIdUser").Value = GuIdUser;
            page.Root.Element("parametri").Element("Title").Value = Title;
            page.Root.Element("parametri").Element("Description").Value = Description;
            page.Root.Element("parametri").Element("articolo").Value = articolo;
            page.Root.Element("parametri").Element("Url").Value = Url;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string News_Update(string GuIdUser, string GuIdStory, string Title, string Description, string articolo, string Url)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_news_update);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("GuIdUser").Value = GuIdUser;
            page.Root.Element("parametri").Element("GuIdStory").Value = GuIdUser;
            page.Root.Element("parametri").Element("Title").Value = Title;
            page.Root.Element("parametri").Element("Description").Value = Description;
           // page.Root.Element("parametri").Element("articolo").Value = articolo;
            page.Root.Element("parametri").Element("Url").Value = Url;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }

        public string News_Listbyuser(string pag, string numpag, string GuIdUser)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_news_list_byuser);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("num_pagina").Value = pag;
            page.Root.Element("parametri").Element("num_elementi").Value = numpag;
            page.Root.Element("parametri").Element("validazione").Value = inputMessages.validazione;
            page.Root.Element("parametri").Element("GuIdUser").Value = GuIdUser;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string News_Listbytag(string pag, string numpag, string TagName)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_news_listbytag);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("num_pagina").Value = pag;
            page.Root.Element("parametri").Element("num_elementi").Value = numpag;
            page.Root.Element("parametri").Element("validazione").Value = inputMessages.validazione;
            page.Root.Element("parametri").Element("TagName").Value = TagName;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }



        public string News_piu_letti(string pag, string numpag)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;

            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_news_list_piu_letti);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("num_pagina").Value = pag;
            page.Root.Element("parametri").Element("num_elementi").Value = numpag;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string News_top_autori(string pag, string numpag)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;

            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_utente_list_top_autori);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("num_pagina").Value = pag;
            page.Root.Element("parametri").Element("num_elementi").Value = numpag;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string News_piu_votati(string pag, string numpag)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;

            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_news_list_piu_votati);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("num_pagina").Value = pag;
            page.Root.Element("parametri").Element("num_elementi").Value = numpag;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }



        public string Utente_attivita(string pag, string numpag)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;

            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_utente_attivita_list);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("num_pagina").Value = pag;
            page.Root.Element("parametri").Element("num_elementi").Value = numpag;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }




        public string News_element_tags(string pag, string numpag, string GuIdStory)
        {

            string xmlMsg = "";

            string xmlDIR = inputMessages.xmlDIR;


            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_news_element_tags);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("num_pagina").Value = pag;
            page.Root.Element("parametri").Element("num_elementi").Value = numpag;
            page.Root.Element("parametri").Element("GuIdStory").Value = GuIdStory;

            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }

        public string News_Element(string GuIdStory)
        {

            string xmlMsg = "";
            string xmlDIR = inputMessages.xmlDIR;

            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_news_element);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("GuIdStory").Value = GuIdStory;


            XNamespace xmlns = nameSpace;
            //page.Root.Name = xmlns + page.Root.Name.LocalName;
            foreach (var node in page.Descendants()) { node.Name = xmlns + node.Name.LocalName; }


            xmlMsg = "<?xml version='1.0' encoding='iso-8859-1'?>";
            xmlMsg += page.ToString();


            return xmlMsg;
        }


        public string Utente_Username_Pass(string username, string password)
        {

            string xmlMsg = "";
            string xmlDIR = inputMessages.xmlDIR;

            XDocument page = XDocument.Load(xmlDIR + "/" + inputMessages.im_social_utente_element_username_pass);

            string nameSpace = page.Root.Name.Namespace.NamespaceName;
            RemoveNamespace(page);

            page.Root.Element("parametri").Element("username").Value = username;
            page.Root.Element("parametri").Element("password").Value = password;


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



    }
}
