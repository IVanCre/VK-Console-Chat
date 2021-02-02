using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Flud_VK_Bot
{
    class Bot
    {
        ChromeDriver Chrome = new ChromeDriver();
        private string StartUrl= "https://vk.com/id174691259";


        internal void Start()
        {
            Chrome.Navigate().GoToUrl(StartUrl);

            RegestrationData MyReg = new RegestrationData(Chrome);
            MyReg.Regestrating();


            IWebElement SelectFriends = Chrome.FindElementByXPath("/html/body/div[11]/div/div/div[2]/div[2]/div[2]/div/div/div/div/div/div[1]/div/div[4]/aside[1]/div/a[2]");
            SelectFriends.Click();//выбор вкладки
            Thread.Sleep(1000);

            string Mariya = "/html/body/div[11]/div/div/div[2]/div[2]/div[2]/div/div/div/div/div[2]/div/div[2]/div[4]/div[1]/div/div[1]/div[3]/div[3]/a";
            IWebElement SelectFriend = Chrome.FindElementByXPath(Mariya);
            SelectFriend.Click();
            Thread.Sleep(1000);

            string b = "/html/body/div[6]/div/div[2]/div/div[2]/div/div[4]/div[3]";
            IWebElement Message = Chrome.FindElementByXPath(b);
            Message.SendKeys("//");
            IWebElement SendButton = Chrome.FindElementById("mail_box_send");
            SendButton.Click();
        }

        internal void EnterChat(string FriendName)
        {
            Chrome.Navigate().GoToUrl(StartUrl);

            RegestrationData MyReg = new RegestrationData(Chrome);
            MyReg.Regestrating();


            string MessageLeftSide = "/html/body/div[11]/div/div/div[2]/div[1]/div/nav/ol/li[3]/a/span[2]";
            IWebElement Message = Chrome.FindElementByXPath(MessageLeftSide);
            Message.Click();
            Thread.Sleep(1000);

            string StrokaPoisk = "im_dialogs_search";
            IWebElement Poisk = Chrome.FindElement(By.Id(StrokaPoisk));
            Poisk.SendKeys(FriendName);
            Poisk.SendKeys(Keys.Enter);


        }


        internal void SendMessage(string message)
        {
            string MessageBox = "im_editable0" ;
            IWebElement Box = Chrome.FindElementById(MessageBox);
            Box.SendKeys(message);

            IWebElement SendButton = Chrome.FindElementByCssSelector(".im-chat-input--send");
            SendButton.Click();
            

        }


        internal void Close()
        {
            Chrome.Quit();
        }
    }
}
