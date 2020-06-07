using Shopper.Data;
using Shopper.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Shopper.Views
{
	public class SignUpPageCS : ContentPage
	{
		UserDatabase userDB;
		Entry usernameEntry, passwordEntry, emailEntry;
		Label messageLabel;

		public SignUpPageCS ()
		{
			messageLabel = new Label ();
			usernameEntry = new Entry {
				Placeholder = "username"	
			};
			passwordEntry = new Entry {
				IsPassword = true
			};
			emailEntry = new Entry ();
			var signUpButton = new Button {
				Text = "Sign Up"
			};
			signUpButton.Clicked += OnSignUpButtonClicked;

			Title = "Sign Up";
			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label { Text = "Username" },
					usernameEntry,
					new Label { Text = "Password" },
					passwordEntry,
					new Label { Text = "Email address" },
					emailEntry,
					signUpButton,
					messageLabel
				}
			};
		}

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text,
                Email = emailEntry.Text
            };

			userDB = new UserDatabase();
			if (userDB.AddUser(user))
            {
				await DisplayAlert("user added", "OK", "OK");
            }
			else
            {
				await DisplayAlert("user not added", "OK", "OK");

			}

		}

        bool AreDetailsValid (User user)
		{
			return (!string.IsNullOrWhiteSpace (user.Username) && !string.IsNullOrWhiteSpace (user.Password) && !string.IsNullOrWhiteSpace (user.Email) && user.Email.Contains ("@"));
		}
	}
}
