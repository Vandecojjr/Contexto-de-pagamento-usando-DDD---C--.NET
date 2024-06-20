using Flunt.Validations;
using PaymenteContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
            .Requires()
            .IsGreaterThan(firstName, 3, "Name.firstName", "O primero tem menos que 3 caracteres")
            .IsGreaterThan(lastName, 3, "Name.lastName", "O Sobrenome tem menos que 3 caracteres")
            .IsLowerThan(lastName, 30, "Name.lastName", "O Sobrenome tem mais que 3 caracteres")
            .IsLowerThan(lastName, 30, "Name.lastName", "O Sobrenome tem mais que 3 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

    }
}