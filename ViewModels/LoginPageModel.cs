using FileDefender_MAUI.Mvvm.Commands;
using Microsoft.Maui.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileDefender_MAUI.ViewModels
{
    public class LoginPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Port { get; set; }
        public string Address { get; set; }


        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }


        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _password;
        public string Password 
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        //public Command ChangeTitleCommand { get; set; }
        //public LoginPageModel()
        //{
        //    ChangeTitleCommand = new Command(() =>
        //    {
        //        TitleValue = EntryValue;
        //        OnPropertyChanged(nameof(TitleValue));
        //    });
        //}

        public ICommand SubmitCommand { get; set; }
        public LoginPageModel()
        {
            SubmitCommand = new Command(Login);
            //SubmitCommand = new DelegateCommand(Login, CanLogin);
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        public async void Login()
        {
            if (!String.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                IsBusy = true;
                //await Task.Delay(2000);
                //MessagingCenter.Send(this, "LoginAlert", Username);
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "File Defender Client");
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    httpClient.BaseAddress = new Uri("http://" + Address + ":" + 80);
                    var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("login_code", Username),
                        new KeyValuePair<string, string>("password", Password),
                        new KeyValuePair<string, string>("ldap_id", "0"),
                        new KeyValuePair<string, string>("client", "true"),
                        new KeyValuePair<string, string>("client_version", "1.4.6"),
                        new KeyValuePair<string, string>("os_version", "Windows 10 Pro x64"),
                        new KeyValuePair<string, string>("host_name", "DESKTOP-6MEEKQG"),
                        new KeyValuePair<string, string>("os_user", "v-huy"),
                        new KeyValuePair<string, string>("mac_addr", "3C:58:C2:65:D7:AE"),
                        new KeyValuePair<string, string>("language_id", "01"),
                    });
                    HttpResponseMessage result = httpClient.PostAsync("/user/execlogin-json", formContent).Result;
                    string apiResponse = result.Content.ReadAsStringAsync().Result;
                    JObject json = JObject.Parse(apiResponse);
                    if (bool.Parse(json["status"].ToString()))
                    {
                        // okie
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            //DisplayAlert("Login information", "Server accepted your credential", "OK");
                            MessagingCenter.Send(this, "Login information", "Server accepted your credential");
                        });
                    }
                    else
                    {
                        List<string> messages = json["messages"].ToObject<List<string>>();
                        // login failed
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            //DisplayAlert("Login failed", $"{string.Join(",", messages)}", "OK");
                            MessagingCenter.Send(this, "Login failed", $"{string.Join(",", messages)}");
                        });
                    }
                }
                IsBusy = false;
            }
        
        }

    }
}
