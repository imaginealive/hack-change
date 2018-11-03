using HackChange;
using System;
using Xunit;

namespace HackChangeTest
{
    public class HackChangeUnitTesta
    {
        //จำนวนเงิน/จำนวนเงินที่จ่ายมา/เงินถอน/1000/500/100/50/20/5/1
        [Theory]
        [InlineData(250, 250, 0, 0, 0, 0, 0, 0, 0, 0)]
        [InlineData(2000, 3000, 1000, 1, 0, 0, 0, 0, 0, 0)]
        [InlineData(2000, 2500, 500, 0, 1, 0, 0, 0, 0, 0)]
        [InlineData(900, 2500, 1600, 1, 1, 1, 0, 0, 0, 0)]
        [InlineData(50, 100, 50, 0, 0, 0, 1, 0, 0, 0)]
        [InlineData(360, 500, 140, 0, 0, 1, 0, 2, 0, 0)]
        [InlineData(30, 300, 270, 0, 0, 2, 1, 1, 0, 0)]
        [InlineData(94, 100, 6, 0, 0, 0, 0, 0, 1, 1)]
        [InlineData(23, 100, 77, 0, 0, 0, 1, 1, 1, 2)]
        [InlineData(1, 2, 1, 0, 0, 0, 0, 0, 0, 1)]

        public void ChangeAble(int Amout, int Payment, int Change, int Bill1000, int Bill500, int Bill100, int Bill50, int Bill20, int Bill5, int Bill1)
        {
            var HackChange = new HackChangeCode();
            var result = HackChange.Change(Amout, Payment);
            result.TryGetValue("Change", out var value);
            Assert.Equal(Change.ToString(), value);
            result.TryGetValue("Bill1000", out value);
            Assert.Equal(Bill1000.ToString(), value);
            result.TryGetValue("Bill500", out value);
            Assert.Equal(Bill500.ToString(), value);
            result.TryGetValue("Bill100", out value);
            Assert.Equal(Bill100.ToString(), value);
            result.TryGetValue("Bill50", out value);
            Assert.Equal(Bill50.ToString(), value);
            result.TryGetValue("Bill20", out value);
            Assert.Equal(Bill20.ToString(), value);
            result.TryGetValue("Bill5", out value);
            Assert.Equal(Bill5.ToString(), value);
            result.TryGetValue("Bill1", out value);
            Assert.Equal(Bill1.ToString(), value);
        }

        [Theory]
        [InlineData(1000, 900, "เงินไม่พอ")]
        public void FailEdPayment(int Amout, int Payment, string expected)
        {
            var HackChange = new HackChangeCode();
            var result = HackChange.Change(Amout, Payment);
            result.TryGetValue("Note", out var value);
            Assert.Equal(expected, value);
        }
    }
}
