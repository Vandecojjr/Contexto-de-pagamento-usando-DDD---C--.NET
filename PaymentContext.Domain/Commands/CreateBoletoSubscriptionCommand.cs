
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymenteContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }

        public string PaymentNumber { get; private set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; private set; }
        public string PayerEmail { get; set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(FirstName, 3, "Name.firstName", "O primero tem menos que 3 caracteres")
            .IsGreaterThan(LastName, 3, "Name.lastName", "O Sobrenome tem menos que 3 caracteres")
            .IsLowerThan(FirstName, 30, "Name.lastName", "O Sobrenome tem mais que 3 caracteres")
            .IsLowerThan(LastName, 30, "Name.lastName", "O Sobrenome tem mais que 3 caracteres")
            );

        }
    }
}