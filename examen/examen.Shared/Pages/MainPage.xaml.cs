using examen.Componentes;
using examen.Models;
using examen.service;
using System;
using System.Collections.Generic;
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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            _instance = this;
        }


        public static  MainPage _instance { get; set; }
        public Question question { get; set; }

        public static MainPage GetInstance()
        {
            return _instance;
        }

        public  void signout()
        {
            Frame.Navigate(typeof(Login));
        }


        public LoginResponse LoginResponse { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoginResponse = (LoginResponse)e.Parameter;
            WelcomeTextBlock.Text = $"Bienvenid@: {LoginResponse.User.Name}";
            getQuestions();
        }



        private async  void getQuestions()
        {
            Loader loader = new Loader("Por favor espere...");
            loader.Show();
            Response response = await ApiService.GetAsync<object>("Questions", LoginResponse.Token);
            loader.Close();


            if (!response.IsSuccess)
            {
                MessageDialog dialog = new MessageDialog(response.Message, "Error");
                await dialog.ShowAsync();
            }

            question = (Question)response.Result;

            if(question != null)
            {
                MyFrame.Navigate(typeof(QuestionPage));
            }
            else
            {
                MyFrame.Navigate(typeof(CancelPage));

            }


        }


       
    }
}
