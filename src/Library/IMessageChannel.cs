namespace Library
{
    public interface IMessageChannel
    {
         void SendSMS(Message message, string[] names, string text);
         void SendEmail(Message message, string[] names, string text);
    }
}