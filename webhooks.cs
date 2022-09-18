using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;

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
    }
}
//thats it.