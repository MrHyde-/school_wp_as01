using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Assigment01.Resources;
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

        /// <summary>
        /// After load show and hide necessary components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="routedEventArgs"></param>
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //make preselect for the user
            RadioButtonPublicPhone.IsChecked = true;
            
            //Attach events to radiobuttons and checkbox
            RadioButtonPrivatePhone.Checked += RadioButtonPrivatePhoneOnChecked;
            RadioButtonPublicPhone.Checked += RadioButtonPublicPhoneOnChecked;

            CheckBoxUseLightVersion.Checked += CheckBoxUseLightVersion_onChange;
            CheckBoxUseLightVersion.Unchecked += CheckBoxUseLightVersion_onChange;

            //hide components that are not visible when user opens the application
            hyperlinkButtonSupportedBrowsers.Visibility = Visibility.Collapsed;
            TextBlockPublicProtectedInfo.Visibility = Visibility.Collapsed;
            TextBlockPrivateProtectedInfo.Visibility = Visibility.Collapsed;
            TextBlockLightVersionInfo.Visibility = Visibility.Collapsed;
            TextBlockSecurityWarning.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Event for selecting the public phone radiobutton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="routedEventArgs"></param>
        private void RadioButtonPublicPhoneOnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            TextBlockSecurityWarning.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Event for selecting the private phone radiobutton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="routedEventArgs"></param>
        private void RadioButtonPrivatePhoneOnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            TextBlockSecurityWarning.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Event for viewing the security explanation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlockShowPublicPrivateInfo_OnTap(object sender, GestureEventArgs e)
        {
            TextBlockPublicProtectedInfo.Visibility = TextBlockPublicProtectedInfo.Visibility == Visibility.Collapsed
                                                          ? Visibility.Visible
                                                          : Visibility.Collapsed;

            //we define text from above textbox visibility ^^
            TextBlockShowPublicPrivateInfo.Text = TextBlockPublicProtectedInfo.Visibility == Visibility.Collapsed
                                                      ? AppResources.ShowExplanation
                                                      : AppResources.HideExplanation;

            TextBlockPrivateProtectedInfo.Visibility = TextBlockPrivateProtectedInfo.Visibility == Visibility.Collapsed
                                                          ? Visibility.Visible
                                                          : Visibility.Collapsed;
        }

        /// <summary>
        /// Event for changing the checkbox status at the mainpage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="routedEventArgs"></param>
        private void CheckBoxUseLightVersion_onChange(object sender, RoutedEventArgs routedEventArgs)
        {
            CheckBox appLight = (CheckBox) sender;

            if (appLight.IsChecked.HasValue)
            {
                TextBlockLightVersionInfo.Visibility = appLight.IsChecked.Value ? Visibility.Visible : Visibility.Collapsed;
                hyperlinkButtonSupportedBrowsers.Visibility = appLight.IsChecked.Value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Event for pressing the login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            
            String messageToUser = AppResources.LoginDone;
            
            if (String.IsNullOrEmpty(TextBoxUserName.Text) && String.IsNullOrEmpty(passwordBox1.Password))
            {
                messageToUser = AppResources.LoginFailure;
            }

            MessageBox.Show(messageToUser);
        }
    }
}