using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Sinoptic.ua
{
    public partial class Form1 : Form
    {
       
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (WebClient web = new WebClient())
            {
                web.DownloadFile("https://sinoptik.ua", "file.html");
                web.DownloadFile("https://sinst.fwdcdn.com/img/newImg/sinoptic-logo.png", "sinoptic-logo.png");
                pbIconTitle.Image = Image.FromFile("sinoptic-logo.png");
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
             
                doc.Load("file.html",Encoding.UTF8);
                lbTitle.Text = doc.DocumentNode.SelectNodes("//h1[@class= 'isMain']").First().InnerText;
                label2.Text = doc.DocumentNode.SelectNodes("//div[@class= 'currentRegion']").First().InnerText;
                label1.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1']/p[1]").First().InnerText;
                label3.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1']/p[2]").First().InnerText;
                label4.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1']/p[3]").First().InnerText;
            }

          
        }
        //public void DataTitle()
        //{
        //    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        //    doc.Load("file.html");
        //    //var MainImageString = MainImageNode.Attributes.Where(i => i.Name == "src").FirstOrDefault();
           
        //    pbIconTitle.Image = Image.FromFile.Attributes.Where(i => i.Name == "src").FirstOrDefault();
        //    var title = doc.DocumentNode.SelectNodes("//a[@class= 'sLogo']").First().InnerText;
        //} 

    }


}


