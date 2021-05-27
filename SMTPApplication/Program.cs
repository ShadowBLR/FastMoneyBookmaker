using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Linq;
using SMTPApplication.Models;
using System.Threading;

namespace SMTPApplication
{
    class Program
    {
        static string Email = @"name.men@mail.ru";
   
        static void Main(string[] args)
        {
            BookmakerContext context = new BookmakerContext();
            Random rand = new Random();
            while (true)
            {
                var matches = context.Matches.Where(m => m.MatchResult == MatchResult.Undefined).ToList();
                foreach (var match in matches)
                {

                    match.MatchResult = (MatchResult)rand.Next(1, 3);
                    var bets = from b in context.Bets
                               where b.MatchId ==match.Id
                               join u in context.Users
                               on b.UserId equals u.Id
                               join c in context.Contacts
                               on u.Contact.Id equals c.Id
                               select new
                               {
                                   Bet = b,
                                   User = u,
                                   Contact = c
                               };

                    /*var bets = context.Bets
                        .Where(b  =>  b.MatchId == match.Id)
                        .Join(context.Users,
                        bet=>bet.UserId,
                        user=>user.Id,
                        (b,u)=>new
                        {
                            Bet = b,
                            User=u
                        });*/
                    foreach(var bet in bets)
                    {
                        if(match.MatchResult==bet.Bet.BetOn)
                        {
                            bet.Bet.State = BetState.Win;
                            
                        }
                        else if(match.MatchResult == MatchResult.Cancel)
                        {
                            bet.Bet.State = BetState.Cancelled;
                        }
                        else
                        {
                            bet.Bet.State = BetState.Defeat;
                        }
                        string message = CreateMessage(bet.Bet, bet.User);
                        MailMessage mailMessage = CreateMailMessage("name.men@mail.ru", bet.Contact.Email, "Результат ставки", message);
                        SendMessage(mailMessage);
                    }
                    var result = from u in context.Users
                                 join b in bets on u.Id equals
                                 b.Bet.UserId
                                 join c in context.Contacts
                                 on u.Contact.Id equals c.Id
                                 select c.Email;
                    foreach(var r in result )
                    {
                        Console.WriteLine(r);
                    }
                    Thread.Sleep(3000);
                }
            }

        }
        private static string CreateMessage(Bet bet, User user)
        {
            string message = "Здравствуйте," + user.Nickname + "</br>" +
                 "Результат ставки на" + bet.BetOn + " - " + bet.State;
            switch (bet.State)
            {
                case BetState.Win:
                    {
                        message += " успех";
                        message += "</br>";
                        message += "Выйгрыш составил...";
                        break;
                    }
                case BetState.Defeat:
                    {
                        message += " провал";
                        break;
                    }
                case BetState.Cancelled:
                    {
                        message += " отменена, средства возвращены на счет";
                        break;
                    }
                default: break;
            }
            return message;
        }
        private static MailMessage CreateMailMessage(string from,string to,string header,string message)
        {
            return  new MailMessage(from,to,header,message);
        }
        private static bool SendMessage(MailMessage mailMessage)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
                smtp.Credentials = new NetworkCredential("name.men@mail.ru", "123456TyRoN_KAA2810");
                smtp.EnableSsl = true;
                smtp.Send(mailMessage);
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
    
}
