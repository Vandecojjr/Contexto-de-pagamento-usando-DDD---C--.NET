
using Flunt.Notifications;
using Flunt.Validations;
using PaymenteContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract<Email>()
            .Requires()
            .IsEmail(address, "Email.Address", "Email invalido"));

        }

        public string Address { get; private set; }
    }
}