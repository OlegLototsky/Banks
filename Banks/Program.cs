using System;
using System.Xml;
using System.Net;


namespace Banks
{
   public class Program
    {
        public static void Main()
        {
            DateTime timebank = new DateTime(2002, 03, 02);

            string url = $"http://www.cbr.ru/scripts/XML_daily.asp?date_req={timebank.ToString("dd/MM/yyyy")}";
            
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;

            string BankString = wc.DownloadString(url);

            XmlDocument urlbank = new XmlDocument();
            urlbank.LoadXml(BankString);

            XmlNodeList XmlBankList = urlbank.GetElementsByTagName("Valute");

            foreach (XmlNode node in XmlBankList)
            {
                if (node["CharCode"].InnerText == "USD")
                {
                    Console.WriteLine("Стоимость валюты " + node["Name"].InnerText);
                }

              
              }
           
        }
    }
}
