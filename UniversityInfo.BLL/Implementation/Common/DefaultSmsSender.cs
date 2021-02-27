using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Web;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.BLL.DTO;
using MentorAbiturienta.Shared.Options;

namespace MentorAbiturienta.BLL.Implementation.Common
{
  public class DefaultSmsSender : ISmsSender
  {
    private readonly SmsSenderOptions _smsSenderOptions;
    private readonly ILogger<DefaultSmsSender> _logger;

    public DefaultSmsSender
      (
      IOptions<SmsSenderOptions> options,
      ILogger<DefaultSmsSender> logger
      )
    {
      _smsSenderOptions = options?.Value;
      _logger = logger;
    }

    public SendSmsResult SendSms(string to, string body)
    {
      try
      {
        String message = HttpUtility.UrlEncode("This is your message");

        //var bot = new Telegram.Bot.TelegramBotClient("1038439403:AAF_4k-7oulLCMAaXQpJQxqx3p1K6Jl7hYs");
        //bot.SendTextMessageAsync(to, "Hello").Wait();

        //Message message1 = bot.SendTextMessageAsync(
        //  chatId: e.Message.Chat, // or a chat id: 123456789
        //  text: "Trying *all the parameters* of `sendMessage` method",
        //  parseMode: ParseMode.Markdown,
        //  disableNotification: true,
        //  replyToMessageId: e.Message.MessageId,
        //  replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
        //    "Check sendMessage method",
        //    "https://core.telegram.org/bots/api#sendmessage"
        //  ))
        //);
        //using (var wb = new WebClient())
        //{
        //  byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
        //        {
        //        {"apikey" , "5f1ZbP3ncfA-DRgnDViW3F0vNbaRlZegYolugBfNsk"},
        //        {"numbers" , "+380960820991"},
        //        {"message" , message},
        //        {"sender" , "Jims Autos"},
        //        {"test", "true"}
        //        });



        //  string result = System.Text.Encoding.UTF8.GetString(response);
        //  //return result;
        //}


        //String result;
        //string apiKey = "5f1ZbP3ncfA-DRgnDViW3F0vNbaRlZegYolugBfNsk";
        //string numbers = "0960820991,0505653888"; // in a comma seperated list
        //string message = "This is your message";
        //string sender = "Jims Autos";

        //String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
        ////refer to parameters to complete correct url string

        //StreamWriter myWriter = null;
        //HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

        //objRequest.Method = "POST";
        //objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
        //objRequest.ContentType = "application/x-www-form-urlencoded";
        //try
        //{
        //  myWriter = new StreamWriter(objRequest.GetRequestStream());
        //  myWriter.Write(url);
        //}
        //catch (Exception e)
        //{
        // // return e.Message;
        //}
        //finally
        //{
        //  myWriter.Close();
        //}

        //HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        //using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        //{
        //  result = sr.ReadToEnd();
        //  // Close and clean up the StreamReader
        //  sr.Close();
        //}


        //var a = message.Sid;
        return new SendSmsResult(true);
      }
      catch (Exception ex)
      {
        return new SendSmsResult(false);
      }
    }
  }
}