using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SteamSharp;
using SteamSharp.Authenticators;
using Newtonsoft;
using Windows.UI.Popups;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SteamMetro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        public async Task getInfo()
        {
            SteamClient client = new SteamClient();
            //PlayerRelationshipType s = new PlayerRelationshipType();
            //s = PlayerRelationshipType.All;
            //string build = "";
            //int count = 0;
            string user = txtUser.Text;
            string password = txtPassword.PlaceholderText;
            

            SteamUser swag = new SteamUser();
            UserAuthenticator.SteamGuardAnswer s = new UserAuthenticator.SteamGuardAnswer();
            UserAuthenticator.CaptchaAnswer c = new UserAuthenticator.CaptchaAnswer();
            
           // List<SteamUserInterface.Friend> friendList = await SteamUserInterface.GetFriendListAsync(client, "STEAM_0:1:67749", s);

            UserAuthenticator.SteamAccessRequestResult result = await Task.Run(() => UserAuthenticator.GetAccessTokenForUserAsync(user, "blacktiger1"));
            if(result.IsCaptchaNeeded = true)
            {
                webView.NavigateToString(result.CaptchaURL.ToString());
            }

            if(result.IsSteamGuardNeeded = true)
            {
                inputtext.Text = result.SteamGuardEmailDomain.ToString(); 
            }


            //List<SteamUserStats.GlobalAchievement> list = new List<SteamUserStats.GlobalAchievement>();
            //List<SteamUserStats.GlobalAchievement> lister = await SteamUserStats.GetGlobalAchievementPercentagesForAppAsync(client, 440);

            //List<SteamUserInterface.Friend> ggg = SteamUserInterface.GetFriendList(client, "76561198035450677", s);

            //SteamNews.AppNews news = await SteamNews.GetNewsForAppAsync(client, 740, 6, 100);


            //var s = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SteamUserStats.GlobalAchievement>>(list, null);
            //MessageDialog message = new MessageDialog(d.SteamID.ToString());

            //foreach (SteamUserInterface.Friend j in friendList)
            //{
            //   build = build + " " + j.SteamID.ToString() + " friend since " + j.FriendSinceDateTime.ToString() + "\n";
            //   count++;
            //}

            MessageDialog message = new MessageDialog(result.CaptchaURL.ToString() + " en dit ook");
            message.ShowAsync();
            
        }

        //public async void getInfo()
        //{
        //    SteamClient client = new SteamClient();
        //    string build = "";
        //    int count = 0;
        //    List<SteamUserStats.GlobalAchievement> list = new List<SteamUserStats.GlobalAchievement>();
        //    List<SteamUserStats.GlobalAchievement> lister = await SteamUserStats.GetGlobalAchievementPercentagesForAppAsync(client, 440);

        //    PlayerRelationshipType s = new PlayerRelationshipType();
        //    List<SteamUserInterface.Friend> ggg = SteamUserInterface.GetFriendList(client, "76561198035450677", s);

        //    SteamNews.AppNews news = await SteamNews.GetNewsForAppAsync(client, 740, 6, 100);


        //    var s = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SteamUserStats.GlobalAchievement>>(list, null);
        //    MessageDialog message = new MessageDialog(d.SteamID.ToString());

        //    foreach (SteamUserStats.GlobalAchievement s in lister)
        //    {
        //        build = build + " " + s.APIName.ToString() + " en ook nog: " + s.Percent.ToString() + "\n";
        //        count++;
        //    }

        //    MessageDialog message = new MessageDialog(build);
        //    message.ShowAsync();

        //}

        private void Title_Copy1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getInfo();
        }
    }
}
