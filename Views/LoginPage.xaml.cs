using System;
using FileDefender_MAUI.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace FileDefender_MAUI.Views
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			BindingContext = new LoginPageModel();
		}

	}
}
