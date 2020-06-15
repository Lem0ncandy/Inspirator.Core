using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.UnitTest1
{
    [TestClass]
    public class CommonTest
    {
        [TestMethod]
        public void MD5EncryptTest()
        {
            string source = "123123werwer";
            string cipher = Common.EncryptUtil.Encrypt(source);
            Assert.IsTrue(Common.EncryptUtil.Verify(source, cipher));
        }
    }
}
