using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var document = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!document.IsValid);
    }
    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsvalid()
    {
        var document = new Document("12345678912345", EDocumentType.CNPJ);
        Assert.IsTrue(document.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var document = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!document.IsValid);
    }
    [TestMethod]
    public void ShouldReturnSuccessWhenCPFIsvalid()
    {
        var document = new Document("12345678912", EDocumentType.CPF);
        Assert.IsTrue(document.IsValid);
    }
}