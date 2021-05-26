using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace SMTPApplication
{
    class Program
    {
        static string Email = @"name.men@mail.ru";
        static void Main(string[] args)
        {

            while (true)
            {
                Mathces matches = from i in context.Mathes where
                                  context.Mathes.Result == MatchResult.Undefined;
                foreach(var m in matches)
                {
                    var bets = from i in context.Bets where
                               context.Bets.MatchId == m.id;

                }
            }

        }
    }

    private bool SendMessage(MailAddress from,MailAddress to)
    {
        MailMessage message = new MailMessage(from, to);
        message.Subject = "Ставка";
        message.Body = "Здравствуйте," + user.Nickname + "</br>" +
            "Результат ставки на" + bet.beton + bet.result;
        switch (bet.result)
        {
            case BetState.Win:
                {
                    message.Body += " успех";
                    message.Body += "</br>";
                    message.Body += "Выйгрыш составил...";
                }
            case BetState.Defeat:
                {
                    message.Body += " провал";
                }
            case BetState.Cancelled:
                {
                    message.Body += " отменена";
                    message.Body += ", средства возвращены на счет";
                }
            default:break;
        }
        SmtpClient smtp = new SmtpClient("smtp.mail.ru",2525);
        smtp.Credentials = new NetworkCredential("name.men@mail.ru", "ShadowBLR2810");
        smtp.EnableSsl = true;
        smtp.Send(message);
    }
}
