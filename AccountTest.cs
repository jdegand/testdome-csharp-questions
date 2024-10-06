using System;
using NUnit.Framework;

[TestFixture]
public class Tester
{	
    private double epsilon = 1e-6;

    [Test]
    public void AccountCannotHaveNegativeOverdraftLimit()
    {
        Account account = new Account(-20);
        Assert.AreEqual(0, account.OverdraftLimit, epsilon);
    }
    
    [Test]
    public void NoNegativeNumbers()
    {
        Account account = new Account(20);
        Assert.AreEqual(false, account.Deposit(-20));
        Assert.AreEqual(false, account.Withdraw(-20));
    }
    
    [Test]
    public void DepositWithdrawWorks()
    {
        Account account = new Account(20);
        Assert.AreEqual(true, account.Deposit(20));
        Assert.AreEqual(true, account.Withdraw(20));
    }
    
    [Test]
    public void CorrectAmount()
    {
        Account account = new Account(20);
        account.Deposit(20);
        account.Withdraw(10);
        Assert.AreEqual(10, account.Balance, epsilon);
    }
    
    [Test]
    public void AccountOverdraft()
    {
        Account account = new Account(30);
        Assert.AreEqual(false, account.Withdraw(40));
    }
}
