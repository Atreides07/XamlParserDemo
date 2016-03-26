using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace XamlParserDemo.Views
{
    public partial class TestView : ContentPage
    {
        public TestView()
        {
            InitializeComponent();
            
            //BindingContext = new TestViewViewModel();
        }

        string xml = @"
<Student Id=""100"">
    <Name>Arul</Name>
    <Mark>90</Mark>
</Student>
";
    }

    public class TestViewViewModel
    {
        private dynamic xmlRoot;

        public TestViewViewModel(dynamic obj)
        {
            XmlRoot = obj;
        }

        public dynamic XmlRoot
        {
            get { return xmlRoot; }
            set { xmlRoot = value; }
        }

        public string MyValue { get; } = "250";
    }
}
