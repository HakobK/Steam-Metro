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
using Newtonsoft;
using Windows.UI.Popups;

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
        
        public async void getInfo()
        {
            SteamClient client = new SteamClient();
            string build = "";
            int count = 0;
            //List<SteamUserStats.GlobalAchievement> list = new List<SteamUserStats.GlobalAchievement>();
            //list = await SteamUserStats.GetGlobalAchievementPercentagesForAppAsync(client,740);
            
            //PlayerRelationshipType s = new PlayerRelationshipType();
            //List<SteamUserInterface.Friend> ggg = SteamUserInterface.GetFriendList(client, "76561198035450677", s);

            SteamNews.AppNews news =await SteamNews.GetNewsForAppAsync(client, 740, 6, 100);
            

            //var s = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SteamUserStats.GlobalAchievement>>(list,null);
        
                //MessageDialog message = new MessageDialog(d.SteamID.ToString());
            foreach(SteamNews.NewsItem s in news.NewsItems)
            {
                build = build + " " + (news.AppID.ToString() + " en verdere informatie: " + s.Author.ToString() + " beschrijving: " + s.Contents.ToString());
                count++;
            }

            MessageDialog message = new MessageDialog(news.AppID.ToString() + " " + count.ToString());
            message.ShowAsync();
            
        }

        private void Title_Copy1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getInfo();
        }
    }
}
