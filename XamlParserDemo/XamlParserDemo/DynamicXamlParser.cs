using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace XamlParserDemo
{
    public class DynamicXamlParser
    {
        public DynamicXamlParser()
        {
            Init();
        }

        private void Init()
        {
            parseRootElements.Add("ScrollView",()=>new ScrollView());
            parseRootElements.Add("StackLayout", ()=>new StackLayout());
            parseRootElements.Add("Label", ()=>new Label());
            parseRootElements.Add("Editor", ()=>new Editor());
            parseRootElements.Add("Entry", ()=>new Entry());
            parseRootElements.Add("Image", ()=>new Image());
            parseRootElements.Add("Button", ()=>new Button());
        }

        private Dictionary<string, Func<View>> parseRootElements=new Dictionary<string, Func<View>>();

        public View Parse(string xaml)
        {
            var xdoc = XDocument.Parse(xaml);
            var rootElement = xdoc.Root;
            return ParseChield(rootElement);
        }

        private View ParseChield(XElement rootElement)
        {
            var result=parseRootElements[rootElement.Name.LocalName]();
            ParseAttributes(result, rootElement.Attributes());
            foreach (var xNode in rootElement.Elements())
            {
                var childElement=ParseChield(xNode);
                AddToElement(result, childElement);
            }
            return result;
        }

        private void ParseAttributes(View result, IEnumerable<XAttribute> attributes)
        {
            foreach (var xAttribute in attributes)
            {
                if (xAttribute.Name.LocalName == "HeightRequest")
                {
                    result.HeightRequest = double.Parse(xAttribute.Value);
                }
                if (xAttribute.Name.LocalName == "WidthRequest")
                {
                    result.WidthRequest = double.Parse(xAttribute.Value);
                }


                if (xAttribute.Name.LocalName == "HorizontalOptions")
                {
                    result.HorizontalOptions = ParseLayoutOption(xAttribute.Value);
                }
                if (xAttribute.Name.LocalName == "VerticalOptions")
                {
                    result.VerticalOptions = ParseLayoutOption(xAttribute.Value);
                }


                if (xAttribute.Name.LocalName == "Text")
                {
                    AddText(result, xAttribute.Value);
                }
                if (xAttribute.Name.LocalName == "Source")
                {
                    AddSource(result, xAttribute.Value);
                }
                if (xAttribute.Name.LocalName == "Aspect")
                {
                    AddAspect(result, xAttribute.Value);
                }
            }
        }

        private LayoutOptions ParseLayoutOption(string value)
        {
            bool expand = false;
            if (value.EndsWith("AndExpand"))
            {
                expand = true;
                value = value.Substring(0, value.Length - "AndExpand".Length);
            }
            LayoutAlignment result;
            Enum.TryParse(value, out result);
            return new LayoutOptions(result, expand);
        }

        private void AddAspect(View result, string value)
        {
            if (result is Image)
            {
                Aspect aspect;
                if (Enum.TryParse(value, out aspect))
                {
                    (result as Image).Aspect = aspect;
                }

            }
        }

        private void AddSource(View result, string value)
        {
            if (result is Image)
            {
                (result as Image).Source = ImageSource.FromUri(new Uri(value));
            }
        }

        private void AddText(View result, string value)
        {
            if (result is Label) (result as Label).Text = value;
            if (result is Entry) (result as Entry).Text = value;
            if (result is Editor) (result as Editor).Text = value;
            if (result is Button) (result as Button).Text = value;
            
        }

        private void AddToElement(View parent, View childElement)
        {
            if (parent is StackLayout )
            {
                (parent as StackLayout).Children.Add(childElement);
            }
            if (parent is Grid)
            {
                (parent as Grid).Children.Add(childElement);
            }

            if (parent is ScrollView)
            {
                (parent as ScrollView).Content = childElement;
            }
            
        }
    }
}
