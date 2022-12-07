using Service.Interface;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Service.Services
{
    public class SendingSms : ISendingSms
    {
        public bool SendMessage(double phone, string Message)
        {
            var accountSid = "ACecc917f0826093e44d8afae64d657514";
            var authToken = "4e1e09d11178bdc93a0be1303f4ddc61";
            TwilioClient.Init(accountSid, authToken);
            string phone1 = Convert.ToString(phone);
            string countryid = "+91";
            string concat = countryid + phone1;
            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(concat));
            messageOptions.MessagingServiceSid = "MG5d765562fba3973a9904c865bba00fe7";
            messageOptions.Body = Message;
            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
            return true;
        }
    }
}
