using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymenteContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscripition> _Subscripitions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _Subscripitions = new List<Subscripition>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscripition> Subscripitions { get { return _Subscripitions.ToArray(); } }

        public void AddSubscription(Subscripition subscripition)
        {
            var hasSunscriptionActive = false;
            foreach (var sub in _Subscripitions)
            {
                if (sub.Active)
                    hasSunscriptionActive = true;
            }

            if (!hasSunscriptionActive)
                _Subscripitions.Add(subscripition);

            AddNotifications(new Contract<Student>()
            .Requires()
            .IsFalse(hasSunscriptionActive, "Student.Active", "Você tem uma assinatura")
            .AreNotEquals(0, subscripition.Payments.Count, "Student.Subscription,Payment", "Essa assinatura nao possui pagamentos"));

        }
    }
}