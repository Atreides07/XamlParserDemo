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

            
            var rootView = Parse(MainPage.Xaml);
            Content = rootView;
        }

        static DynamicXamlParser xamlParser=new DynamicXamlParser();

        private View Parse(string xaml)
        {
            return xamlParser.Parse(xaml);
        }
        
        
    }
}
