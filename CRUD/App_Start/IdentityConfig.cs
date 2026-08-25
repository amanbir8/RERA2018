using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using CRUD.Models;
using System.Net;
using System.IO;
using System.Net.Mail;
using CRUD.Models.HelpdeskComplaint;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace CRUD
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            // return client.SendMailAsync(mail);

            string retfeedback = string.Empty;
            retfeedback = SendmailConfig(message.Destination, message.Body, message.Subject);

            return Task.FromResult(0);
        }

        public Task SendComplaintMEmailAsync(IdentityMessage message, Int64 ComplaintID, string FormDiaryNumber, string sourceIP, string userName)
        {
            // Plug in your email service here to send an email.
            // return client.SendMailAsync(mail);            

            string retfeedback = string.Empty;
            retfeedback = SendmailConfig(message.Destination, message.Body, message.Subject);

            ClsMethod_AuthDesk_FormM_SMTPsentlog obj = new ClsMethod_AuthDesk_FormM_SMTPsentlog();
            ClsPrp_AuthDesk_FormM_SMTPsentlog m = new ClsPrp_AuthDesk_FormM_SMTPsentlog();

            m.SentemailUserLogID = 0;
            m.ComplaintDiaryNumber = FormDiaryNumber;
            m.ComplaintID = ComplaintID;
            m.SignInDate = DateTime.Now;
            m.UserName = userName;
            m.DestinationEmailAddress = message.Destination;
            m.SourceHostName = string.Empty;
            m.SourceIP = sourceIP;
            m.Activity = retfeedback;
            m.IsActive = 1;
            m.CreatedOn = DateTime.Now;
            m.ModifyOn = DateTime.Now;
            bool retOutpu = obj.Add_ComplaintFormM_SMTPsentlog(m, userName);

            return Task.FromResult(0);
        }

        public Task SendComplaintExeEmailAsync(IdentityMessage message, Int64 ComplaintID, string FormDiaryNumber, string sourceIP, string userName)
        {
            // Plug in your email service here to send an email.
            // return client.SendMailAsync(mail);            

            string retfeedback = string.Empty;
            retfeedback = SendmailConfig(message.Destination, message.Body, message.Subject);

            ClsMethod_AuthDesk_FormM_SMTPsentlog obj = new ClsMethod_AuthDesk_FormM_SMTPsentlog();
            ClsPrp_AuthDesk_FormM_SMTPsentlog m = new ClsPrp_AuthDesk_FormM_SMTPsentlog();

            m.SentemailUserLogID = 0;
            m.ComplaintDiaryNumber = FormDiaryNumber;
            m.ComplaintID = ComplaintID;
            m.SignInDate = DateTime.Now;
            m.UserName = userName;
            m.DestinationEmailAddress = message.Destination;
            m.SourceHostName = string.Empty;
            m.SourceIP = sourceIP;
            m.Activity = retfeedback;
            m.IsActive = 1;
            m.CreatedOn = DateTime.Now;
            m.ModifyOn = DateTime.Now;
            bool retOutpu = obj.Add_ComplaintFormExe_SMTPsentlog(m, userName);

            return Task.FromResult(0);
        }

        public Task SendComplaintNEmailAsync(IdentityMessage message, Int64 ComplaintID, string FormDiaryNumber, string sourceIP, string userName)
        {
            // Plug in your email service here to send an email.
            // return client.SendMailAsync(mail);
            string retfeedback = string.Empty;
            retfeedback = SendmailConfig(message.Destination, message.Body, message.Subject);

            ClsMethod_AuthDesk_FormN_SMTPsentlog obj = new ClsMethod_AuthDesk_FormN_SMTPsentlog();
            ClsPrp_AuthDesk_FormN_SMTPsentlog n = new ClsPrp_AuthDesk_FormN_SMTPsentlog();

            n.SentemailUserLogID = 0;
            n.ComplaintDiaryNumber = FormDiaryNumber;
            n.ComplaintID = ComplaintID;
            n.SignInDate = DateTime.Now;
            n.UserName = userName;
            n.DestinationEmailAddress = message.Destination;
            n.SourceHostName = string.Empty;
            n.SourceIP = sourceIP;
            n.Activity = retfeedback;
            n.IsActive = 1;
            n.CreatedOn = DateTime.Now;
            n.ModifyOn = DateTime.Now;
            bool retOutpu = obj.Add_ComplaintFormN_SMTPsentlog(n, userName);

            return Task.FromResult(0);
        }

        public string SendmailConfig(string toemail, string bodyContent, string bodySub)
        {
            string feedback = "";
            var sentFromConfig = "donotreply.rerapunjab@gmail.com";//"tech.cdac@gmail.com"; //"recruitment-portal@cdac.in";//"tech.cdac@gmail.com"; //"portaladminrera@punjab.gov.in";//
            //var passwordConfig = "Munish#123"; //"Munish@cdac"; //"Munish#123"; //"Plsu55rE";//"Munish@cdac"; //"Pawan@123";//
            var passwordConfig = "ixeezbsyxjhptntt";

            MailMessage msgMail = new MailMessage();

            MailMessage myMessage = new MailMessage();
            myMessage.From = new MailAddress(sentFromConfig, "Punjab RERA web portal");
            myMessage.To.Add(toemail);
            myMessage.Subject = bodySub;
            myMessage.IsBodyHtml = true;          
            myMessage.Body = bodyContent.Trim();

            SmtpClient mySmtpClient = new SmtpClient();
            System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential(sentFromConfig, passwordConfig);
            mySmtpClient.Host = "smtp.gmail.com";//"smtp.cdac.in"; //"smtp.gmail.com";//"mail.punjab.gov.in";//
            mySmtpClient.Port = 587;//587; //465; // 587;// 25; //587;//25;//
            mySmtpClient.EnableSsl = true;
            mySmtpClient.UseDefaultCredentials = false;
            mySmtpClient.Credentials = myCredential;
            mySmtpClient.ServicePoint.MaxIdleTime = 1;           
            
            try
            {
                mySmtpClient.Send(myMessage);
                feedback = "Delivered";
            }
            catch (Exception e)
            {
                feedback = "Failure (" + e.Message + ")";
            }

            myMessage.Dispose();

            return feedback;
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.

            //var twilio = new TwilioRestClient(TwilioSettings.AccountSID, TwilioSettings.AuthToken);
            //var result = twilio.SendMessage(TwilioSettings.PhoneNumber, message.Destination, message.Body);
            //Trace.TraceInformation(result.Status);

            string senderusername = "cdacrec";
            string senderpassword = "cdacmohali";
            string senderid = "RECDAC";

            string Mobile = message.Destination; //"9888489937"; //ds.Tables[0].Rows[0]["PTelePhone"].ToString();

            //string post = ds.Tables[0].Rows[0]["post"].ToString();
            //string regno = ds.Tables[0].Rows[0]["Regno"].ToString();
            //string password = ds.Tables[0].Rows[0]["password"].ToString();

            StreamReader objReader;
            string sURL = "http://bhashsms.com/api/sendmsg.php?user="
                + senderusername
                + "&pass=" + senderpassword
                + "&sender=" + senderid
                + "&phone=" + Mobile
                + "&text=" + message.Body //"nitin"
               
                + "&priority=ndnd&stype=normal";

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            try
            {
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                objReader = new StreamReader(objStream);
                objReader.Close();                
            }
            catch
            {
                
            }
            return Task.FromResult(0);
        }
        
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
        /////////////    var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames


            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>( context.Get<ApplicationDbContext>() as MySQLDatabase));
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = false;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Welcome RERA Punjab. Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Welcome RERA Punjab. Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}   


