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


                //first
                var first = doc.DocumentNode.SelectNodes("//*[@id='bd1']/p[1]").First().InnerText;
                if (first != null)
                {
                    lbName1.Text = first;
                    if (lbName1.Text == "Суббота" || lbName1.Text == "Воскресенье")
                    {
                        lbCount1.ForeColor = Color.Red;

                    }
                }
                lbCount1.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1']/p[2]").First().InnerText;
                label4.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1']/p[3]").First().InnerText;
                web.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/m/d000.gif", "d000.gif");
            
                pictureBox1.Image = Image.FromFile("d000.gif");
                //if (link == "d000.gif")
                //{
                //    pictureBox1.Image = Image.FromFile("d000.gif");
                //}
                //if (weather == "Облачно с прояснениями")
                //{
                //    pictureBox1.Image = Image.FromFile("d300.gif");
                //}

                string temp = doc.DocumentNode.SelectNodes("//div[@class= 'min']").First().InnerText;
                temp = temp.Replace("&deg;", "°C");
                label5.Text = temp;
                string temp1 = doc.DocumentNode.SelectNodes("//div[@class= 'max']").First().InnerText;
                temp1 = temp1.Replace("&deg;", "°C");
                label6.Text = temp1;


                //second
                var second = doc.DocumentNode.SelectNodes("//*[@id='bd2']/p[1]").First().InnerText;
                if (second != null)
                {
                    lbName2.Text = second;
                    if (lbName2.Text == "Суббота" || lbName2.Text == "Воскресенье")
                    {
                        lbCount2.ForeColor = Color.Red;

                    }
                }
                lbCount2.Text = doc.DocumentNode.SelectNodes("//*[@id='bd2']/p[2]").First().InnerText;
                label9.Text = doc.DocumentNode.SelectNodes("//*[@id='bd2']/p[3]").First().InnerText;
                web.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/m/d300.gif", "d300.gif");
                pictureBox2.Image = Image.FromFile("d300.gif");

                string temp2 = doc.DocumentNode.SelectNodes("//*[@id='bd2']/div[2]/div[1]").First().InnerText;
                temp2 = temp2.Replace("&deg;", "°C");
                label8.Text = temp2;
                string temp3 = doc.DocumentNode.SelectNodes("//*[@id='bd2']/div[2]/div[2]").First().InnerText;
                temp3 = temp3.Replace("&deg;", "°C");
                label7.Text = temp3;


                //third
                var three = doc.DocumentNode.SelectNodes("//*[@id='bd3']/p[1]").First().InnerText;
                if (three != null)
                {
                lbName3.Text = three;
                    if (lbName3.Text == "Суббота" || lbName3.Text == "Воскресенье")
                    {
                        lbCount3.ForeColor = Color.Red;
                      
                    }
                }
                lbCount3.Text = doc.DocumentNode.SelectNodes("//*[@id='bd3']/p[2]").First().InnerText;
                label14.Text = doc.DocumentNode.SelectNodes("//*[@id='bd3']/p[3]").First().InnerText;
                web.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/m/d430.gif", "d430.gif");
                pictureBox3.Image = Image.FromFile("d430.gif");

                string temp4 = doc.DocumentNode.SelectNodes("//*[@id='bd3']/div[2]/div[1]").First().InnerText;
                temp4 = temp4.Replace("&deg;", "°C");
                label13.Text = temp4;
                string temp5 = doc.DocumentNode.SelectNodes("//*[@id='bd3']/div[2]/div[2]").First().InnerText;
                temp5 = temp5.Replace("&deg;", "°C");
                label12.Text = temp5;


                //four
                var four = doc.DocumentNode.SelectNodes("//*[@id='bd4']/p[1]").First().InnerText;
                if (four != null)
                {
                    lbName4.Text = four;
                    if (lbName4.Text == "Суббота" || lbName4.Text == "Воскресенье")
                    {
                        lbCount4.ForeColor = Color.Red;

                    }
                }
                lbCount4.Text = doc.DocumentNode.SelectNodes("//*[@id='bd4']/p[2]").First().InnerText;
                label19.Text = doc.DocumentNode.SelectNodes("//*[@id='bd4']/p[3]").First().InnerText;
                //web.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/m/d430.gif", "d430.gif");
                pictureBox4.Image = Image.FromFile("d430.gif");

                string temp6 = doc.DocumentNode.SelectNodes("//*[@id='bd4']/div[2]/div[1]").First().InnerText;
                temp6 = temp6.Replace("&deg;", "°C");
                label18.Text = temp6;
                string temp7 = doc.DocumentNode.SelectNodes("//*[@id='bd4']/div[2]/div[2]").First().InnerText;
                temp7 = temp7.Replace("&deg;", "°C");
                label17.Text = temp7;


                //five
                var five = doc.DocumentNode.SelectNodes("//*[@id='bd5']/p[1]").First().InnerText;
                if (five != null)
                {
                    lbName5.Text = five;
                    if (lbName5.Text == "Суббота" || lbName5.Text == "Воскресенье")
                    {
                        lbCount5.ForeColor = Color.Red;

                    }
                }
                lbCount5.Text = doc.DocumentNode.SelectNodes("//*[@id='bd5']/p[2]").First().InnerText;
                label24.Text = doc.DocumentNode.SelectNodes("//*[@id='bd5']/p[3]").First().InnerText;
                web.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/m/d410.gif", "d410.gif");
                pictureBox5.Image = Image.FromFile("d410.gif");

                string temp8 = doc.DocumentNode.SelectNodes("//*[@id='bd5']/div[2]/div[1]").First().InnerText;
                temp8 = temp8.Replace("&deg;", "°C");
                label23.Text = temp8;
                string temp9 = doc.DocumentNode.SelectNodes("//*[@id='bd5']/div[2]/div[2]").First().InnerText;
                temp9 = temp9.Replace("&deg;", "°C");
                label22.Text = temp9;


                //six
                var six = doc.DocumentNode.SelectNodes("//*[@id='bd6']/p[1]").First().InnerText;
                if (six != null)
                {
                    lbName6.Text = six;
                    if (lbName6.Text == "Суббота" || lbName6.Text == "Воскресенье")
                    {
                        lbCount6.ForeColor = Color.Red;

                    }
                }
                lbCount6.Text = doc.DocumentNode.SelectNodes("//*[@id='bd6']/p[2]").First().InnerText;
                label29.Text = doc.DocumentNode.SelectNodes("//*[@id='bd6']/p[3]").First().InnerText;
                web.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/m/d400.gif", "d400.gif");
                pictureBox6.Image = Image.FromFile("d400.gif");

                string temp10 = doc.DocumentNode.SelectNodes("//*[@id='bd6']/div[2]/div[1]").First().InnerText;
                temp10 = temp10.Replace("&deg;", "°C");
                label28.Text = temp8;
                string temp11 = doc.DocumentNode.SelectNodes("//*[@id='bd6']/div[2]/div[2]").First().InnerText;
                temp11 = temp11.Replace("&deg;", "°C");
                label27.Text = temp11;


                //seven
                var seven = doc.DocumentNode.SelectNodes("//*[@id='bd7']/p[1]").First().InnerText;
                if (seven != null)
                {
                    lbName7.Text = seven;
                    if (lbName7.Text == "Суббота" || lbName7.Text == "Воскресенье")
                    {
                        lbCount7.ForeColor = Color.Red;

                    }
                }
                lbCount7.Text = doc.DocumentNode.SelectNodes("//*[@id='bd7']/p[2]").First().InnerText;
                label34.Text = doc.DocumentNode.SelectNodes("//*[@id='bd7']/p[3]").First().InnerText;
                web.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/m/d310.gif", "d310.gif");
                pictureBox7.Image = Image.FromFile("d310.gif");

                string temp12 = doc.DocumentNode.SelectNodes("//*[@id='bd7']/div[2]/div[1]").First().InnerText;
                temp12 = temp12.Replace("&deg;", "°C");
                label33.Text = temp12;
                string temp13 = doc.DocumentNode.SelectNodes("//*[@id='bd7']/div[2]/div[2]").First().InnerText;
                temp13 = temp13.Replace("&deg;", "°C");
                label32.Text = temp11;


            }


        }
           


       
    }


}


