using MyMasjid.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Text.Json.Serialization;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        salahTimings salahTimings = new salahTimings();
        String strDate = string.Empty;
        DateTime date = DateTime.MinValue;
        var client = new HttpClient();
        var response = client.GetAsync("https://time.my-masjid.com/api/TimingsInfoScreen/GetMasjidTimings?GuidId=e725aae5-eebc-4729-b648-6f2f2486031e").Result;
        var resObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);


        var streamQuery = resObject.SelectTokens("model.salahTimings["+(DateTime.Now.DayOfYear - 1)+"]").FirstOrDefault();
        salahTimings = streamQuery.ToObject<salahTimings>();

        strDate = DateTime.Now.ToString("dd/MM/yyyy")+" "+salahTimings.asr+":00";
        date = DateTime.ParseExact(strDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        ExecuteAsr(date.AddMinutes(-10)).Wait();
        strDate = DateTime.Now.ToString("dd/MM/yyyy") + " " + salahTimings.fajr+ ":00";
        date = DateTime.ParseExact(strDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        ExecuteFajr(date.AddMinutes(-10)).Wait();
        strDate = DateTime.Now.ToString("dd/MM/yyyy") + " " + salahTimings.isha+ ":00";
        date = DateTime.ParseExact(strDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        ExecuteIsha(date.AddMinutes(-10)).Wait();
        strDate = DateTime.Now.ToString("dd/MM/yyyy") + " " + salahTimings.maghrib+ ":00";
        date = DateTime.ParseExact(strDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        ExecuteMaghrib(date.AddMinutes(-10)).Wait();
        strDate = DateTime.Now.ToString("dd/MM/yyyy") + " " + salahTimings.zuhr+ ":00";
        date = DateTime.ParseExact(strDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        ExecuteZuhr(date.AddMinutes(-10)).Wait();
    }

    static async Task ExecuteAsr(DateTime sendTime)
    {
        string APIKey = "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";
        Environment.SetEnvironmentVariable("SENDGRID_API_KEY", APIKey);
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("zuhaibmtmamz@gmail.com");
        var subject = "10 min more to Asr";
        var to = new EmailAddress("zuhaibmtm@gmail.com", "Zuhaib Mohamed");
        var plainTextContent = "Pray quickly if you didnt pray";
        var htmlContent = "<strong>Allah watching you</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        long sendAtUnixTime = new DateTimeOffset(sendTime).ToUnixTimeSeconds();
        msg.SendAt = sendAtUnixTime;
        var response = await client.SendEmailAsync(msg);
    }

    static async Task ExecuteFajr(DateTime sendTime)
    {
        string APIKey = "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";
        Environment.SetEnvironmentVariable("SENDGRID_API_KEY", APIKey);
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("zuhaibmtmamz@gmail.com");
        var subject = "10 min more to Fajr";
        var to = new EmailAddress("zuhaibmtm@gmail.com", "Zuhaib Mohamed");
        var plainTextContent = "Pray quickly if you didnt pray";
        var htmlContent = "<strong>Allah watching you</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        long sendAtUnixTime = new DateTimeOffset(sendTime).ToUnixTimeSeconds();
        msg.SendAt = sendAtUnixTime;
        var response = await client.SendEmailAsync(msg);
    }

    static async Task ExecuteIsha(DateTime sendTime)
    {
        string APIKey = "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";
        Environment.SetEnvironmentVariable("SENDGRID_API_KEY", APIKey);
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("zuhaibmtmamz@gmail.com");
        var subject = "10 min more to Isha";
        var to = new EmailAddress("zuhaibmtm@gmail.com", "Zuhaib Mohamed");
        var plainTextContent = "Pray quickly if you didnt pray";
        var htmlContent = "<strong>Allah watching you</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        long sendAtUnixTime = new DateTimeOffset(sendTime).ToUnixTimeSeconds();
        msg.SendAt = sendAtUnixTime;
        var response = await client.SendEmailAsync(msg);
    }

    static async Task ExecuteMaghrib(DateTime sendTime)
    {
        string APIKey = "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";
        Environment.SetEnvironmentVariable("SENDGRID_API_KEY", APIKey);
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("zuhaibmtmamz@gmail.com");
        var subject = "10 min more to Maghrib";
        var to = new EmailAddress("zuhaibmtm@gmail.com", "Zuhaib Mohamed");
        var plainTextContent = "Pray quickly if you didnt pray";
        var htmlContent = "<strong>Allah watching you</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        long sendAtUnixTime = new DateTimeOffset(sendTime).ToUnixTimeSeconds();
        msg.SendAt = sendAtUnixTime;
        var response = await client.SendEmailAsync(msg);
    }

    static async Task ExecuteZuhr(DateTime sendTime)
    {
        string APIKey = "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";
        Environment.SetEnvironmentVariable("SENDGRID_API_KEY", APIKey);
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("zuhaibmtmamz@gmail.com");
        var subject = "10 min more to Zuhr";
        var to = new EmailAddress("zuhaibmtm@gmail.com", "Zuhaib Mohamed");
        var plainTextContent = "Pray quickly if you didnt pray";
        var htmlContent = "<strong>Allah watching you</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        long sendAtUnixTime = new DateTimeOffset(sendTime).ToUnixTimeSeconds();
        msg.SendAt = sendAtUnixTime;
        var response = await client.SendEmailAsync(msg);
    }
}