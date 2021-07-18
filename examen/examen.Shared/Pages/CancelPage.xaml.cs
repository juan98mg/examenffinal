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
    public sealed partial class CancelPage : Page
    {
        public CancelPage()
        {
            this.InitializeComponent();
        }

        private async void CancelVote(object sender, RoutedEventArgs e)
        {

            ContentDialog confirm = new ContentDialog()
            {
                Title = "Confirmación",
                Content = "¿Estás seguro de querer cancelar su voto?",
                PrimaryButtonText = "Sí",
                CloseButtonText = "No"
            };

            ContentDialogResult result = await confirm.ShowAsync();

            if (result != ContentDialogResult.Primary)
                return;

            Loader loader = new Loader("Por favor espere...");
            loader.Show();
            Response response = await ApiService.DeleteAsync("Answers", MainPage.GetInstance().LoginResponse.Token);
            loader.Close();

            MessageDialog messageDialog;

            if (!response.IsSuccess)
            {
                messageDialog = new MessageDialog("Su voto no ha sido cancelado con éxito", "Error ");
                await messageDialog.ShowAsync();
                return;
            }

            Frame navigationFrame = Window.Current.Content as Frame;
            navigationFrame.Navigate(typeof(Login));

            messageDialog = new MessageDialog("Su voto  ha sido cancelado con éxito", "Error ");
            await messageDialog.ShowAsync();

          


        }
    }
}
