using System;
using System.Collections.Specialized;
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
    }
}
//thats it.