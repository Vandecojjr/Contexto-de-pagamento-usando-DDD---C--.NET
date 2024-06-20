using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    private readonly Student _student;
    private readonly Subscripition _subscription;
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;

    public StudentTests()
    {
        _name = new Name("Joâo", "Maria");
        _document = new Document("12345678912", EDocumentType.CPF);
        _email = new Email("joao@maria.com");
        _address = new Address("rua 1", "1555", "qualquer", "tanto faz", "MS", "Brazil", "1231546444");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscripition(null);

    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {

        var payment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "joao corp", _document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscriptionHasNoPayment()
    {

        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenHadNoActiveSubscription()
    {
        var payment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "joao corp", _document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }
}