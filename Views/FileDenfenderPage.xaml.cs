using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace FileDefender_MAUI.Views
{
	public partial class FileDenfenderPage : ContentPage
	{
		int count = 0;

		public FileDenfenderPage()
		{
			InitializeComponent();
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			count++;
			CounterLabel.Text = $"Current count: {count}";

			SemanticScreenReader.Announce(CounterLabel.Text);
		}
	}
}
