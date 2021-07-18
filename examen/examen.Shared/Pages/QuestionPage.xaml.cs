using examen.Componentes;
using examen.Models;
using examen.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using uno.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace examen.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage : Page
    {
        public QuestionPage()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<Option> Options { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            loadOptions();
            QuestionTextBox.Text = MainPage.GetInstance().question.Description;
        }

        private void loadOptions()
        {
            List<Option> options = MainPage.GetInstance().question.Options;
            Options = new ObservableCollection<Option>(options);
        }

        private async void Option1Click(object sender, RoutedEventArgs e)
        {
             sendVote(1);

        }

        private async void Option2Click(object sender, RoutedEventArgs e)
        {
              sendVote(2);
        }

        private async void Option3Click(object sender, RoutedEventArgs e)
        {
             sendVote(3);
        }


        private async void Option4Click(object sender, RoutedEventArgs e)
        {
             sendVote(4);
        }


        private async void sendVote(int id)
        {
            Loader loader = new Loader("Por favor espere...");
            loader.Show();
            Response response = await ApiService.PostAsync<object>("Questions", new QuestionResponse() { OptionId = id, QuestionId = MainPage.GetInstance().question.Id }, MainPage.GetInstance().LoginResponse.Token);
            loader.Close();

            MessageDialog messageDialog;

            if (!response.IsSuccess)
            {
                messageDialog = new MessageDialog("Su voto no ha sido registrado con éxito", "Error ");
                await messageDialog.ShowAsync();
                return;
            }

            messageDialog = new MessageDialog("Su voto  ha sido registrado con éxito", "Error ");
            await messageDialog.ShowAsync();

            MainPage.GetInstance().signout();

        }

    }
}
