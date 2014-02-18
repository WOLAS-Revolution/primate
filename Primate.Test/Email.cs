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
        public void SendMethods()
        {
            List<Primate.Model.Attachment> files = new List<Primate.Model.Attachment>();
            files.Add(new Primate.Model.Attachment { data = Convert.FromBase64String("cmloYW5uYSBtaWxsZXIgbm90IGNvbXAgdW5pdD8NCkJTQndvcjMwMWIgY29tcA0Kc2lnbnVwIHVwbG9hZGVkIGEgdmVyc2lvbiAtIHRwYXIgc2F5cyBiIHZlcnNpb24="), name = "file.txt" });

            List<String> cc = new List<string>();
            cc.Add("mjrbrennan@gmail.com");

            List<String> tags = new List<string>();
            cc.Add("test");

            Primate.Email.Send("db@filmskills.com.au", "test", "test");
            //Primate.Email.Send("db@filmskills.com.au", "test", "test", files);
            //Primate.Email.Send("db@filmskills.com.au", "test", "test", cc);

            //Thread.Sleep(1000);

            //Primate.Email.Send("db@filmskills.com.au", "test", "test", cc, files);

            //Thread.Sleep(1000);

            //Primate.Email.Send("db@filmskills.com.au", "test", "test", cc, tags);

            //Thread.Sleep(1000);

            //Primate.Email.Send("db@filmskills.com.au", "test", "test", cc, files, tags);

            //Thread.Sleep(1000);

            //Primate.Email.Send("db@filmskills.com.au", "test", "test", cc, files, tags, true, "mbrennan@filmskills.com", "Testing plain");
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
