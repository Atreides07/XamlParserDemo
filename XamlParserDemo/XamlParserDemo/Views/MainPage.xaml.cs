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
            if (Xaml == null)
            {
                Xaml = @"
  <ScrollView>
    <StackLayout>
      <Image Source=""{Binding /Student/AvatarUrl}"" WidthRequest=""300"" HeightRequest=""200"" Aspect=""AspectFill"" HorizontalOptions=""Center"" />
      <Entry Text=""{Binding /Student/Id}""></Entry>
      <Entry Text=""{Binding /Student/FirstName}""></Entry>
      <Slider Value=""{Binding /Student/Weight}"" Maximum =""200""></Slider>
    </StackLayout>
  </ScrollView>";

                Xml = @"
<Student>
    <Id>2</Id>
    <FirstName>Иван</FirstName>
    <Weight>50</Weight>
    <AvatarUrl>http://7oom.ru/wp-content/uploads/foto-priroda-9.jpg</AvatarUrl>
</Student>";

                XamlEditer.Text = Xaml;
                XmlEditer.Text = Xml;
            }
        }

        protected override void OnAppearing()
        {
            XamlEditer.Text = Xaml;
            XmlEditer.Text = Xml;
            base.OnAppearing();
            
        }

        

        public static string Xaml { get;  set; }
        public static string Xml { get;  set; }
        private void Button_OnClicked(object sender, EventArgs e)
        {
            Xaml = XamlEditer.Text;
            Xml = XmlEditer.Text;
            Navigation.PushAsync(new DynamicPage());
        }
    }
}
