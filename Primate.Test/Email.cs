using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;

namespace Primate.Test
{
    [TestClass]
    public class Email
    {
        [TestMethod]
        public void SendEmail()
        {
            Primate.CONFIG.SetConfig("**", "**", "Primate");
            Primate.Email.Send("mbrennan@filmskills.com.au", "Test", "This is a test.");
        }

        [TestMethod]
        public void TemplateMethods()
        {
            string template = Primate.Template.Get("test-template");
            string templateNoWrap = Primate.Template.Get("test-template", 1, 2, 3);
            string templateWrap = Primate.Template.Get("test-template", "dev-outer", 1, 2, 3);
            Assert.IsNotNull(template);
            Assert.IsNotNull(templateNoWrap);
            Assert.IsNotNull(templateWrap);
        }
    }
}
