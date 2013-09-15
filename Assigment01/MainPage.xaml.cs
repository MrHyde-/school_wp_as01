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
            RadioButtonPrivatePhone.Checked += RadioButtonPrivatePhoneOnChecked;

            TextBlockPublicProtectedInfo.Text = "Valitse tämä vaihtoehto, jos käytät Outlook Web Appiä julkisessa tietokoneessa. Kun olet lopettanut, muista kirjautua ulos ja sulkea kaikki ikkunat istuntosi päätteeksi.";
            TextBlockPublicProtectedInfo.Visibility = Visibility.Collapsed;

            TextBlockPrivateProtectedInfo.Text = "Valitse tämä asetus, jos olet tämän tietokoneen ainoa käyttäjä. Palvelimesi sallii tavallista pidemmän käyttämättömyysajan, ennen kuin sinut kirjataan ulos.";
            TextBlockPrivateProtectedInfo.Visibility = Visibility.Collapsed;

            TextBlockLightVersionInfo.Text = "Outlook Web Appin kevytversio sisältää vähemmän toimintoja. Käytä sitä, jos yhteytesi on hidas tai jos käytät tietokonetta, jonka selaimen suojausasetukset ovat tavallista rajoittavammat. Outlook-verkkosovelluksen täyttä versiota tuetaan myös joissakin Windows- ja Mac-tietokoneiden selaimissa. Jos haluat tarkistaa kaikki tuetut selaimet ja käyttöjärjestelmät, ";
            TextBlockLightVersionInfo.Visibility = Visibility.Collapsed;

            TextBlockSecurityWarning.Text = "Varoitus: Valitsemalla tämän asetuksen vahvistat, että tämä tietokone on organisaatiosi tietoturvakäytännön mukainen.";
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

            TextBlockPrivateProtectedInfo.Visibility = TextBlockPrivateProtectedInfo.Visibility == Visibility.Collapsed
                                                          ? Visibility.Visible
                                                          : Visibility.Collapsed;
        }
    }
}