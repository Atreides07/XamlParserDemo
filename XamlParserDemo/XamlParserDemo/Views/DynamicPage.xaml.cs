using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlParserDemo.Views
{
    public partial class DynamicPage : ContentPage
    {
        public DynamicPage()
        {
            InitializeComponent();

            xamlParser=new DynamicXamlBindXmlParser(MainPage.Xml,
                (message) =>
                {
                    DisplayAlert("Ошибка", message, "OK");
                });

            var rootView = xamlParser.Parse(MainPage.Xaml);
            Content = rootView;
            
        }

        private readonly DynamicXamlBindXmlParser xamlParser;
        
        protected override bool OnBackButtonPressed()
        {
            MainPage.Xml = xamlParser.GetXml();
            MessagingCenter.Send(new XmlMessage(MainPage.Xml),"test" );
            
            return base.OnBackButtonPressed();
        }

        protected override void OnDisappearing()
        {
            MainPage.Xml = xamlParser.GetXml();
            var xmlMessage = new XmlMessage(MainPage.Xml);
            MessagingCenter.Send(xmlMessage,"test");
            base.OnDisappearing();
        }
    }

    public class XmlMessage
    {
        public XmlMessage(string xml)
        {
            Xml = xml;
        }

        public string Xml { get; set; }
    }
}
