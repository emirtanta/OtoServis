﻿using OtoServis.Entities;
using System.Net;
using System.Net.Mail;

namespace OtoServis.WebUI.Utils
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Musteri musteri)
        {
            SmtpClient smtpClient= new SmtpClient("mailAdresiniz",587);
            smtpClient.Credentials = new NetworkCredential("emailKullancıAdınız", "emailSifreniz");
            smtpClient.EnableSsl = false;

            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@siteadi.com");
            message.To.Add("info@siteadi.com");
            message.To.Add("bilgi@siteadi.com");
            message.Subject = "Siteden mesaj geldi";
            message.Body = $"Mail Bilgileri <hr/> Ad Soyad : {musteri.Adi} {musteri.Soyadi} <hr/> İlgilendiği Araç Id : {musteri.AracId} <hr/> Email : {musteri.Email} <hr/> Telefon : {musteri.Telefon} <hr/> Notlar : {musteri.Notlar}";
            message.IsBodyHtml = true;

            await smtpClient.SendMailAsync(message);

            smtpClient.Dispose();
        }
    }
}
