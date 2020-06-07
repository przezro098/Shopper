using Shopper;
using Shopper.Data;
using Shopper.Models;
using System;

using Xamarin.Forms;

namespace Shopper.Views
{
	public class LoginPageCS : ContentPage
	{
		UserDatabase userDB;
		Entry emailEntry, passwordEntry;
		Label messageLabel;

		public LoginPageCS ()
		{
			var toolbarItem = new ToolbarItem {
				Text = "Sign Up"
			};
			toolbarItem.Clicked += OnSignUpButtonClicked;
			ToolbarItems.Add (toolbarItem);

			var logo = new Image { Aspect = Aspect.AspectFit };
			logo.Source = ImageSource.FromUri(new Uri("https://i.ibb.co/BVQGgHZ/logo.jpg"));

			messageLabel = new Label ();
			emailEntry = new Entry {
				Placeholder = "email"	
			};
			passwordEntry = new Entry {
				IsPassword = true
			};
			var loginButton = new Button {
				Text = "Login"
			};
			loginButton.Clicked += OnLoginButtonClicked;

			Title = "Login";
			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					logo,
					new Label { Text = "Email" },
					emailEntry,
					new Label { Text = "Password" },
					passwordEntry,
					loginButton,
					messageLabel
				}
			};
		}

		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new SignUpPageCS ());
		}

		async void OnLoginButtonClicked (object sender, EventArgs e)
		{
			var user = new User {
				Email = emailEntry.Text,
				Password = passwordEntry.Text
			};
			userDB = new UserDatabase();

			if (userDB.AreCredentialsValid(user))
			{
				Navigation.InsertPageBefore(new HomePageCS(), this);
				await Navigation.PopAsync();
			}
			else
			{
				messageLabel.Text = "Login failed";
				passwordEntry.Text = string.Empty;
			}
		}

	}
}


