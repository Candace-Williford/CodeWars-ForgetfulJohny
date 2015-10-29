using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForgetfulJohny_CodeWars.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testempty() {
            Assert.AreEqual(null,Mailbox.Pass(""));
        }

        [TestMethod]
        public void test() {
            Assert.AreEqual("12JOHNY",Mailbox.Pass("1johny2@mail.ru"));
        }
    }
}