namespace ZbaBotApi.Models.Mappers
{
    public class OwnerMapper
    {
        public static Owner MapToOwner(ZbaBotService.Owner zbaOwner)
        {
            var owner = new Owner
                {
                    MailingAddress1 = zbaOwner.MailingAddress1,
                    MailingAddress2 = zbaOwner.MailingAddress2,
                    MailingCity = zbaOwner.MailingCity,
                    MailingState = zbaOwner.MailingState,
                    MailingZipCode = zbaOwner.MailingZip,
                    Name = zbaOwner.Name
                };

            return owner;
        }
    }   
}