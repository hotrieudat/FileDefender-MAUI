using System;
using FileDefender_MAUI.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace FileDefender_MAUI.Views
{
	public partial class LoginPage : ContentPage
	{
		public LoginPageModel loginModel;
		public LoginPage()
		{
			InitializeComponent();
			//BindingContext = new LoginPageModel();
			loginModel = new LoginPageModel();
            MessagingCenter.Subscribe<LoginPageModel, string>(this, "Login information", (sender, message) =>
            {
                DisplayAlert("Login information", message, "Oke");
                Navigation.PushAsync(new FileDenfenderPage());
            });

            MessagingCenter.Subscribe<LoginPageModel, string>(this, "Login failed", (sender, message) =>
            {
                DisplayAlert("Login failed", message, "Oke");
            });

            MessagingCenter.Subscribe<LoginPageModel, string>(this, "Network", (sender, message) =>
            {
                DisplayAlert("Network", message, "Oke");
            });

            this.BindingContext = loginModel;

            usernameEntry.Completed += (object sender, EventArgs e) =>
            {
                passwordEntry.Focus();
            };

            passwordEntry.Completed += (object sender, EventArgs e) =>
            {
                loginModel.SubmitCommand.Execute(null);
            };
        }
    }
}
