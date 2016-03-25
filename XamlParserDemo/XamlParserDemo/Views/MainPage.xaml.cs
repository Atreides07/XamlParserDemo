using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamlParserDemo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            XamlEditer.Text = @"
  <ScrollView>
    <StackLayout>
      <Image Source=""http://7oom.ru/wp-content/uploads/foto-priroda-9.jpg"" WidthRequest=""300"" HeightRequest=""200"" Aspect=""AspectFill"" HorizontalOptions=""Center"" />
      <Label Text=""XAML:""></Label>
      <Editor HeightRequest=""300""></Editor>
      <Label Text=""xml""></Label>
      <Editor  HeightRequest=""300""></Editor>
      <Button Text=""Показать"" HorizontalOptions=""Center"" Clicked=""Button_OnClicked""></Button>
      <Entry></Entry>
    </StackLayout>
  </ScrollView>";
        }

        public static string Xaml { get; private set; }
        public static string Xml { get; private set; }
        private void Button_OnClicked(object sender, EventArgs e)
        {
            Xaml = XamlEditer.Text;
            Xml = XmlEditer.Text;
            Navigation.PushAsync(new DynamicPage());
        }
    }
}
