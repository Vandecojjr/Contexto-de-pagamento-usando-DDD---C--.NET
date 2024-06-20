using Flunt.Notifications;
using Flunt.Validations;
using PaymenteContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscripition : Entity
    {
        private IList<Payment> _Payments;
        public Subscripition(DateTime? expireDate)
        {
            CreatDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _Payments = new List<Payment>();
        }

        public DateTime CreatDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _Payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {

            _Payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}