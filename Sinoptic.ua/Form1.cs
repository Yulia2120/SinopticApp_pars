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
using System.Net.Http;

namespace Sinoptic.ua
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }


        public static Image GetImageFromPicPath(string strUrl)
        {
            using (WebResponse wrFileResponse = WebRequest.Create(strUrl).GetResponse())
            using (Stream objWebStream = wrFileResponse.GetResponseStream())
            {
                MemoryStream ms = new MemoryStream();
                objWebStream.CopyTo(ms, 8192);
                return System.Drawing.Image.FromStream(ms);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var url = "https://sinoptik.ua";
          
                using (HttpClientHandler hdl = new HttpClientHandler())
                {
                    using (var clnt = new HttpClient(hdl))
                    {
                        using (HttpResponseMessage resp = clnt.GetAsync(url).Result)
                        {
                            if (resp.IsSuccessStatusCode)
                            {
                                var html = resp.Content.ReadAsStringAsync().Result;
                                if (!string.IsNullOrEmpty(html))
                                {
                                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                    doc.LoadHtml(html);
                            
                                    var node = doc.DocumentNode.SelectNodes("//*[@id= 'header']/div[1]/img");
                                    string linc = "https:" + node[0].GetAttributeValue("src", "");
                                    Image image = GetImageFromPicPath(linc);
                                    pbIconTitle.Image = image;
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
                                    var node1 = doc.DocumentNode.SelectNodes("//*[@id='bd1']/div[1]/img");

                                    string linc1 = "https:" + node1[0].GetAttributeValue("src", "");
                                    Image image1 = GetImageFromPicPath(linc1);
                                    pictureBox1.Image = image1;

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
                                    var node2 = doc.DocumentNode.SelectNodes("//*[@id='bd2']/div[1]/img");

                                    string linc2 = "https:" + node2[0].GetAttributeValue("src", "");
                                    Image image2 = GetImageFromPicPath(linc2);
                                    pictureBox2.Image = image2;

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

                                    var node3 = doc.DocumentNode.SelectNodes("//*[@id='bd3']/div[1]/img");

                                    string linc3 = "https:" + node3[0].GetAttributeValue("src", "");
                                    Image image3 = GetImageFromPicPath(linc3);
                                    pictureBox3.Image = image3;

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
                                var node4 = doc.DocumentNode.SelectNodes("//*[@id='bd4']/div[1]/img");
                                string linc4 = "https:" + node4[0].GetAttributeValue("src", "");
                                Image image4 = GetImageFromPicPath(linc4);
                                pictureBox4.Image = image4;
                            
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
                                var node5 = doc.DocumentNode.SelectNodes("//*[@id='bd5']/div[1]/img");
                                string linc5 = "https:" + node5[0].GetAttributeValue("src", "");
                                Image image5 = GetImageFromPicPath(linc5);
                                pictureBox5.Image = image5;

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
                                var node6 = doc.DocumentNode.SelectNodes("//*[@id='bd6']/div[1]/img");
                                string linc6 = "https:" + node6[0].GetAttributeValue("src", "");
                                Image image6 = GetImageFromPicPath(linc6);
                                pictureBox6.Image = image6;

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
                                var node7 = doc.DocumentNode.SelectNodes("//*[@id='bd7']/div[1]/img");
                                string linc7 = "https:" + node7[0].GetAttributeValue("src", "");
                                Image image7 = GetImageFromPicPath(linc7);
                                pictureBox7.Image = image7;
                                string temp12 = doc.DocumentNode.SelectNodes("//*[@id='bd7']/div[2]/div[1]").First().InnerText;
                                temp12 = temp12.Replace("&deg;", "°C");
                                label33.Text = temp12;
                                string temp13 = doc.DocumentNode.SelectNodes("//*[@id='bd7']/div[2]/div[2]").First().InnerText;
                                temp13 = temp13.Replace("&deg;", "°C");
                                label32.Text = temp11;


                                //today
                                label1.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[1]/div[1]/p[1]").First().InnerText;
                                var node8 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[1]/div[1]/div[1]/img");
                                string linc8 = "https:" + node8[0].GetAttributeValue("src", "");
                                Image image8 = GetImageFromPicPath(linc8);
                                pictureBox8.Image = image8;
                                pbTerm.Image = Image.FromFile("term1.png");
                                string temp14 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[1]/div[1]/p[2]").First().InnerText;
                                lbtemptooday.Text = temp14.Replace("&deg;", "°");
                                lbinfoDaylight.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[1]/div[2]").First().InnerText;
                                lbTemp.Text = doc.DocumentNode.SelectNodes(" //*[@id='bd1c']/div[1]/div[1]/div[3]/p[1]").First().InnerText;
                                lbTooltip.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[1]/div[3]/p[2]/span").First().InnerText;
                                lbPressure.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[1]/div[3]/p[3]").First().InnerText;
                                lbHumidity.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[1]/div[3]/p[4]").First().InnerText;
                                lbWind.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[1]/div[3]/p[5]").First().InnerText;
                                lbPrecipitation.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[1]/div[3]/p[6]").First().InnerText;
                                //night
                                lbnight.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/thead/tr/td[1]").First().InnerText;
                                lbtime1.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[1]/td[1]").First().InnerText;
                                lbtime2.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[1]/td[2]").First().InnerText;
                                var node9 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[2]/td[1]/div/img");
                                string linc9 = "https:" + node9[0].GetAttributeValue("src", "");
                                Image image9 = GetImageFromPicPath(linc9);
                                pbnight1.Image = image9;
                                var node10 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[2]/td[2]/div/img");
                                string linc10 = "https:" + node10[0].GetAttributeValue("src", "");
                                Image image10 = GetImageFromPicPath(linc10);
                                pbnight2.Image = image10;
                                string temp15 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[3]/td[1]").First().InnerText;
                                temp15 = temp15.Replace("&deg;", "°");
                                lbtempnight1.Text = temp15;
                                string temp16 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[3]/td[2]").First().InnerText;
                                temp16 = temp16.Replace("&deg;", "°");
                                lbtempnight2.Text = temp16;
                                string temp17 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[4]/td[1]").First().InnerText;
                                temp17 = temp17.Replace("&deg;", "°");
                                lbtooltipnight1.Text = temp17;
                                string temp18 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[4]/td[2]").First().InnerText;
                                temp18 = temp18.Replace("&deg;", "°");
                                lbtooltipnight2.Text = temp18;
                                lbPrnight1.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[5]/td[1]").First().InnerText;
                                lbPrnight2.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[5]/td[2]").First().InnerText;
                                lbhumnight1.Text= doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[6]/td[1]").First().InnerText;
                                lbhumnight2.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[6]/td[2]").First().InnerText;
                                lbWnight1.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[7]/td[1]/div").First().InnerText;
                                lbWnight2.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[7]/td[2]/div").First().InnerText;
                                lbPrenight1.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[8]/td[1]").First().InnerText;
                                lbPrenight2.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[8]/td[2]").First().InnerText;
                                //morning
                                label38.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/thead/tr/td[2]").First().InnerText;
                                label37.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[1]/td[3]").First().InnerText;
                                label3.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[1]/td[4]").First().InnerText;
                                var node11 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[2]/td[3]/div/img");
                                string linc11 = "https:" + node11[0].GetAttributeValue("src", "");
                                Image image11 = GetImageFromPicPath(linc11);
                                pictureBox10.Image = image11;
                                var node12 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[2]/td[4]/div/img");
                                string linc12 = "https:" + node12[0].GetAttributeValue("src", "");
                                Image image12 = GetImageFromPicPath(linc12);
                                pictureBox9.Image = image12;
                                string temp19 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[3]/td[3]").First().InnerText;
                                temp19 = temp19.Replace("&deg;", "°");
                                label36.Text = temp19;
                                string temp20 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[3]/td[4]").First().InnerText;
                                temp20 = temp20.Replace("&deg;", "°");
                                label35.Text = temp20;
                                string temp21 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[4]/td[3]").First().InnerText;
                                temp21 = temp21.Replace("&deg;", "°");
                                label31.Text = temp21;
                                string temp22 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[4]/td[4]").First().InnerText;
                                temp22 = temp22.Replace("&deg;", "°");
                                label30.Text = temp22;
                                label26.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[5]/td[3]").First().InnerText;
                                label25.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[5]/td[4]").First().InnerText;
                                label21.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[6]/td[3]").First().InnerText;
                                label20.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[6]/td[4]").First().InnerText;
                                label16.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[7]/td[3]/div").First().InnerText;
                                label15.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[7]/td[4]/div").First().InnerText;
                                label11.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[8]/td[3]").First().InnerText;
                                label10.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[8]/td[4]").First().InnerText;
                                label10.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[8]/td[4]").First().InnerText;
                                //day
                                label53.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/thead/tr/td[3]").First().InnerText;
                                label52.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[1]/td[5]").First().InnerText;
                                label39.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[1]/td[6]").First().InnerText;
                                var node13 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[2]/td[5]/div/img");
                                string linc13 = "https:" + node13[0].GetAttributeValue("src", "");
                                Image image13 = GetImageFromPicPath(linc13);
                                pictureBox12.Image = image13;
                                var node14 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[2]/td[6]/div/img");
                                string linc14 = "https:" + node14[0].GetAttributeValue("src", "");
                                Image image14 = GetImageFromPicPath(linc14);
                                pictureBox11.Image = image14;
                                string temp23 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[3]/td[5]").First().InnerText;
                                temp23 = temp23.Replace("&deg;", "°");
                                label51.Text = temp23;
                                string temp24 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[3]/td[6]").First().InnerText;
                                temp24 = temp24.Replace("&deg;", "°");
                                label50.Text = temp24;
                                string temp25 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[4]/td[5]").First().InnerText;
                                temp25 = temp25.Replace("&deg;", "°");
                                label49.Text = temp25;
                                string temp26 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[4]/td[6]").First().InnerText;
                                temp26 = temp26.Replace("&deg;", "°");
                                label48.Text = temp26;
                                label47.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[5]/td[5]").First().InnerText;
                                label46.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[5]/td[6]").First().InnerText;
                                label45.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[6]/td[5]").First().InnerText;
                                label44.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[6]/td[6]").First().InnerText;
                                label43.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[7]/td[5]/div").First().InnerText;
                                label42.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[7]/td[6]/div").First().InnerText;
                                label41.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[8]/td[5]").First().InnerText;
                                label40.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[8]/td[6]").First().InnerText;
                                //evening
                                label68.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/thead/tr/td[4]").First().InnerText;
                                label67.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[1]/td[7]").First().InnerText;
                                label54.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[1]/td[8]").First().InnerText;
                                var node15 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[2]/td[7]/div/img");
                                string linc15 = "https:" + node15[0].GetAttributeValue("src", "");
                                Image image15 = GetImageFromPicPath(linc15);
                                pictureBox14.Image = image15;
                                var node16 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[2]/td[8]/div/img");
                                string linc16 = "https:" + node16[0].GetAttributeValue("src", "");
                                Image image16 = GetImageFromPicPath(linc16);
                                pictureBox13.Image = image16;
                                string temp27 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[3]/td[7]").First().InnerText;
                                temp27 = temp27.Replace("&deg;", "°");
                                label66.Text = temp27;
                                string temp28 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[3]/td[8]").First().InnerText;
                                temp28 = temp28.Replace("&deg;", "°");
                                label65.Text = temp28;
                                string temp29 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[4]/td[7]").First().InnerText;
                                temp29 = temp29.Replace("&deg;", "°");
                                label64.Text = temp29;
                                string temp30 = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[4]/td[8]").First().InnerText;
                                temp30 = temp30.Replace("&deg;", "°");
                                label63.Text = temp30;
                                label62.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[5]/td[7]").First().InnerText;
                                label61.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[5]/td[8]").First().InnerText;
                                label60.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[6]/td[7]").First().InnerText;
                                label59.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[6]/td[8]").First().InnerText;
                                label58.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[7]/td[7]/div").First().InnerText;
                                label57.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[7]/td[8]/div").First().InnerText;
                                label56.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[8]/td[7]").First().InnerText;
                                label55.Text = doc.DocumentNode.SelectNodes("//*[@id='bd1c']/div[1]/div[2]/table/tbody/tr[8]/td[8]").First().InnerText;

                            }




                        }
                        }
                    }
                }
         

        }

       
    }
}

            





