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

            xamlParser=new DynamicXamlBindXmlParser(MainPage.Xml);

            var rootView = xamlParser.Parse(MainPage.Xaml);
            Content = rootView;
        }

        private readonly DynamicXamlBindXmlParser xamlParser;

        protected override bool OnBackButtonPressed()
        {
            MainPage.Xml = xamlParser.GetXml();
            return base.OnBackButtonPressed();
        }

        protected override void OnDisappearing()
        {
            MainPage.Xml = xamlParser.GetXml();
            base.OnDisappearing();
        }
    }
}
