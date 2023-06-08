using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DiscordMessenger;

namespace CSCord
{
    public class webhooks
    {
        public void message(string webhookUrl, string webhookMessage)
        {
            try
            {


                string webhook = webhookUrl;

                var wbc = new WebClient();
                var data = new NameValueCollection();
                data["content"] = webhookMessage;
                wbc.UploadValues(webhook, data);

            }
            catch
            {

            }
        }
        public void Spam(string webhookUrl, string webhookMessage)
        {
            try
            {
                while (true)
                {
                    string webhook = webhookUrl;

                    var wbc = new WebClient();
                    var data = new NameValueCollection();
                    data["content"] = webhookMessage;
                    wbc.UploadValues(webhook, data);
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch
            {

            }
        }
        public void testWebhook(string webhookUrl)
        {
            string webhook = webhookUrl;

            new DiscordMessage()
                .SetUsername("123")
                .SetAvatar("https://tr.rbxcdn.com/2c3f9715160594787e5a0b9d7d0a1b9f/150/150/AvatarHeadshot/Png")
                .AddEmbed()
                  .SetTimestamp(DateTime.Now)
                  .SetTitle("CSCord")
                  .SetDescription("Your webhook is working completely fine!")
                  .SetFooter("Thanks For Using CSCord!")
                  .SetColor(1242520)
                  .Build()
                  .SendMessage(webhookUrl);


        }
        public void wait(int time)

        {
            try
            {
                System.Threading.Thread.Sleep(Convert.ToInt32(time));
            }
            catch
            {

            }

        }
        public void timeRightNow(string webhookUrl)
        {
            var timeString = DateTime.Now.ToString("hh:mm:ss");
            string webhook = webhookUrl;

            var wbc = new WebClient();
            var data = new NameValueCollection();
            data["content"] = timeString;
            wbc.UploadValues(webhook, data);
        }
        public void embed(string webhookUrl, string avatarPhotoUrl, string username, string title, string description, string footer, int color)
        {
            try
            { 
                new DiscordMessage()
                      .SetUsername(username)
                      .SetAvatar(avatarPhotoUrl)
                      .AddEmbed()
                        .SetTimestamp(DateTime.Now)
                        .SetTitle(title)
                        .SetDescription(description)
                        .SetFooter(footer + " | Made with https://bit.ly/official-cscord")
                        .SetColor(color)
                        .Build()
                        .SendMessage(webhookUrl);
                
            }
            catch
            {

            }
        }
        void embedSpam(string webhookUrl, string avatarPhotoUrl,string username, string title, string description, string footer, int color)
        {
            try
            {
                while (true)
                {
                    embed(webhookUrl, avatarPhotoUrl, username, title, description, footer, color);

                }
            }
            catch
            {

            }
        }
        public void SpamMAX(string webhookUrl, string webhookMessage)
        {
            try
            {
                while (true)
                {
                    string webhook = webhookUrl;

                    var wbc = new WebClient();
                    var data = new NameValueCollection();
                    data["content"] = webhookMessage;
                    wbc.UploadValues(webhook, data);
                    System.Threading.Thread.Sleep(500);
                }
            }
            catch
            {

            }
        }
        public void SendComputerScreenShot(string webhookUrl)
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                bitmap.Save(Path.GetTempPath() + "ss.png", ImageFormat.Png);
            }

            string Webhook_link = webhookUrl;
            string FilePath = Path.GetTempPath() + "ss.png";

            using (HttpClient httpClient = new HttpClient())
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                var file_bytes = System.IO.File.ReadAllBytes(FilePath);
                form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "png", Path.GetTempPath() + "ss.png");
                httpClient.PostAsync(Webhook_link, form).Wait();
                httpClient.Dispose();
            }
        }
        //public void sendFile(string webhookUrl)
        //{
            //
            //
        //}
    }
    public class templates
    {
        public void rulesEmbed(string webhookUrl)
        {
            WebRequest wr = (HttpWebRequest)WebRequest.Create(webhookUrl);
            wr.ContentType = "application/json";
            wr.Method = "POST";

            using (var sw = new StreamWriter(wr.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    username = "Rules",
                    embeds = new[]
                    {
                        new
                        {
                            description = "Please follow discord's terms of service.",
                            title = "Rules",
                            color = "008000",

                            footer = new {
                                icon_url = "https://www.pngmart.com/files/17/Wrong-Cross-PNG-Clipart.png",
                                text = "Rules of the server!" + " | Made with CSCord"
                            }
                        }
                    }
                });

                sw.Write(json);
            }
            var response = (HttpWebResponse)wr.GetResponse();
        }
        public void helloworldMessage(string webhookUrl)
        {
            string webhook = webhookUrl;

            var wbc = new WebClient();
            var data = new NameValueCollection();
            data["content"] = "Hello, world!";
            wbc.UploadValues(webhook, data);
        }
        public void fancyHelloWorld(string webhookUrl)
        {
            WebRequest wr = (HttpWebRequest)WebRequest.Create(webhookUrl);
            wr.ContentType = "application/json";
            wr.Method = "POST";

            using (var sw = new StreamWriter(wr.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    username = "Cool Webhook",
                    embeds = new[]
                    {
                        new
                        {
                            description = "Hello world!",
                            title = "Hello!",
                            color = "1242520",

                            footer = new {
                                icon_url = "",
                                text = "Hello, World!" + " | Made with CSCord"
                            }
                        }
                    }
                });

                sw.Write(json);
            }
            var response = (HttpWebResponse)wr.GetResponse();
        }
        public void informationEmbed(string webhookUrl, string information)
        {
            WebRequest wr = (HttpWebRequest)WebRequest.Create(webhookUrl);
            wr.ContentType = "application/json";
            wr.Method = "POST";

            using (var sw = new StreamWriter(wr.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    username = "New Information!",
                    embeds = new[]
                    {
                        new
                        {
                            description = information,
                            title = "New Information!",
                            color = "008000",

                            footer = new {
                                icon_url = "https://www.pngmart.com/files/22/Notification-Bell-PNG.png",
                                text = "Thats all!" + " | Made with CSCord"
                            }
                        }
                    }
                });

                sw.Write(json);
            }
            var response = (HttpWebResponse)wr.GetResponse();
        }
        
    }
    public class advanced
    {
        public void advancedEmbeds(string webhookUrl,string username, string avatarUrl, string title, string description, string footer, bool doTimestamp , string imageUrl, string thumbnailUrl, string authorUrl, int color)
        {
            if (doTimestamp == true)
            {
                new DiscordMessage()
                           .SetUsername(username)
                           .SetAvatar(avatarUrl)
                           .AddEmbed()
                             .SetTimestamp(DateTime.Now)
                             .SetTitle(title)
                             .SetDescription(description)
                             .SetFooter(footer + " | Made with https://bit.ly/official-cscord")
                             .SetImage(imageUrl)
                             .SetThumbnail(thumbnailUrl)
                             .SetAuthor(authorUrl)
                             .SetColor(color)
                             .Build()
                             .SendMessage(webhookUrl);
            }
            if(doTimestamp == false)
            {
                new DiscordMessage()
                           .SetUsername(username)
                           .SetAvatar(avatarUrl)
                           .AddEmbed()
                             .SetTimestamp(DateTime.Now)
                             .SetTitle(title)
                             .SetDescription(description)
                             .SetFooter(footer + " | Made with https://bit.ly/official-cscord")
                             .SetImage(imageUrl)
                             .SetThumbnail(thumbnailUrl)
                             .SetAuthor(authorUrl)
                             .SetColor(color)
                             .Build()
                             .SendMessage(webhookUrl);
            }
        }
      }
    
}

//thats it.