using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace Assigment01
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            RadioButtonPublicPhone.IsChecked = true;
            hyperlinkButtonSupportedBrowsers.Visibility = Visibility.Collapsed;

            RadioButtonPrivatePhone.Checked += RadioButtonPrivatePhoneOnChecked;
            RadioButtonPublicPhone.Checked += RadioButtonPublicPhoneOnChecked;
            CheckBoxUseLightVersion.Unchecked += CheckBoxUseLightVersionOnUnchecked;

            TextBlockPublicProtectedInfo.Text = "Valitse tämä vaihtoehto, jos käytät Outlook Web Appiä julkisessa tietokoneessa. Kun olet lopettanut, muista kirjautua ulos ja sulkea kaikki ikkunat istuntosi päätteeksi.";
            TextBlockPublicProtectedInfo.Visibility = Visibility.Collapsed;

            TextBlockPrivateProtectedInfo.Text = "Valitse tämä asetus, jos olet tämän tietokoneen ainoa käyttäjä. Palvelimesi sallii tavallista pidemmän käyttämättömyysajan, ennen kuin sinut kirjataan ulos.";
            TextBlockPrivateProtectedInfo.Visibility = Visibility.Collapsed;

            TextBlockLightVersionInfo.Text = "Outlook Web Appin kevytversio sisältää vähemmän toimintoja. Käytä sitä, jos yhteytesi on hidas tai jos käytät tietokonetta, jonka selaimen suojausasetukset ovat tavallista rajoittavammat. Outlook-verkkosovelluksen täyttä versiota tuetaan myös joissakin Windows- ja Mac-tietokoneiden selaimissa. Jos haluat tarkistaa kaikki tuetut selaimet ja käyttöjärjestelmät, ";
            TextBlockLightVersionInfo.Visibility = Visibility.Collapsed;

            TextBlockSecurityWarning.Text = "Varoitus: Valitsemalla tämän asetuksen vahvistat, että tämä tietokone on organisaatiosi tietoturvakäytännön mukainen.";
            TextBlockSecurityWarning.Visibility = Visibility.Collapsed;
        }

        private void CheckBoxUseLightVersionOnUnchecked(object sender, RoutedEventArgs routedEventArgs)
        {
            TextBlockLightVersionInfo.Visibility = Visibility.Collapsed;
            hyperlinkButtonSupportedBrowsers.Visibility = Visibility.Collapsed;
        }

        private void RadioButtonPublicPhoneOnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            TextBlockSecurityWarning.Visibility = Visibility.Collapsed;
        }

        private void RadioButtonPrivatePhoneOnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            TextBlockSecurityWarning.Visibility = Visibility.Visible;
        }

        private void TextBlockShowPublicPrivateInfo_OnTap(object sender, GestureEventArgs e)
        {
            TextBlockPublicProtectedInfo.Visibility = TextBlockPublicProtectedInfo.Visibility == Visibility.Collapsed
                                                          ? Visibility.Visible
                                                          : Visibility.Collapsed;

            //we define text from above textbox visibility ^^
            TextBlockShowPublicPrivateInfo.Text = TextBlockPublicProtectedInfo.Visibility == Visibility.Collapsed
                                                      ? "näytä selitys"
                                                      : "piilota selitys";

            TextBlockPrivateProtectedInfo.Visibility = TextBlockPrivateProtectedInfo.Visibility == Visibility.Collapsed
                                                          ? Visibility.Visible
                                                          : Visibility.Collapsed;
        }

        private void CheckBoxUseLightVersion_Checked(object sender, RoutedEventArgs e)
        {
            TextBlockLightVersionInfo.Visibility = Visibility.Visible;
            hyperlinkButtonSupportedBrowsers.Visibility = Visibility.Visible;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            String messageToUser = "login done";
            if (String.IsNullOrEmpty(TextBoxUserName.Text) && String.IsNullOrEmpty(passwordBox1.Password))
            {
                 messageToUser = "invalid username and password";
            }

            MessageBox.Show(messageToUser);
        }
    }
}