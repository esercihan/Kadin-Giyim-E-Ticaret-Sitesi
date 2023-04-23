using System.Text;

namespace eserProje.Helpers
{
    public static class Emaill
    {
        public static void SendMaill(string receiver)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(receiver);
            mail.From = new System.Net.Mail.MailAddress("giysininiyisi@hotmail.com");
            mail.Subject = "Giysininiyisi Aktivasyon";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            string linkk = "https://localhost:7096/Hesap/EPostaAktivasyon?eee=";

            var HtmlBody = new StringBuilder();
            HtmlBody.AppendFormat("Hoşgeldiniz, Sevgili Kullanıcımız. ");
            HtmlBody.AppendLine(@" Hesabınızı aktive etmek için aşağıdaki bağlantıya tıklayın. ");
            HtmlBody.AppendLine("<a href=\"" + linkk + "\">AKTİVASYON</a>");
            mail.Body = HtmlBody.ToString();
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.Normal;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            client.Credentials = new System.Net.NetworkCredential("giysininiyisi@hotmail.com", "giysinin2022");
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2!=null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
            }



        }
    }
}
