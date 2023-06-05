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

            var wbc = new WebClient();
            var data = new NameValueCollection();
            data["content"] = "Webhook is working!";
            wbc.UploadValues(webhook, data);

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
        public void embed(string webhookUrl, string username, string title, string description, string footer, string color)
        {
            WebRequest wr = (HttpWebRequest)WebRequest.Create(webhookUrl);
            wr.ContentType = "application/json";
            wr.Method = "POST";

            using (var sw = new StreamWriter(wr.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    username = username,
                    embeds = new[]
                    {
                        new
                        {
                            description = description,
                            title = title,
                            color = color,

                            footer = new {
                                icon_url = "",
                                text = footer + " | Made with CSCord"
                            }
                        }
                    }
                });

                sw.Write(json);
            }
            var response = (HttpWebResponse)wr.GetResponse();
        }
        void embedSpam(string webhookUrl, string username, string title, string description, string footer, string color)
        {
            try
            {
                while (true)
                {
                    WebRequest wr = (HttpWebRequest)WebRequest.Create(webhookUrl);
                    wr.ContentType = "application/json";
                    wr.Method = "POST";

                    using (var sw = new StreamWriter(wr.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(new
                        {
                            username = username,
                            embeds = new[]
                            {
                        new
                        {
                            description = description,
                            title = title,
                            color = color,

                            footer = new {
                                icon_url = "",
                                text = footer + " | Made with CSCord"
                            }
                        }
                    }
                        });

                        sw.Write(json);
                    }
                    var response = (HttpWebResponse)wr.GetResponse();
                    System.Threading.Thread.Sleep(1000);

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
    
}

//thats it.