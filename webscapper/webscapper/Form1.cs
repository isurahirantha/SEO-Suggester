using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Bunifu;


namespace webscapper
{
    public partial class WebScrapper : Form
    {
        public WebScrapper()
        {
            InitializeComponent();
            
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void scrapBtn_Click(object sender, EventArgs e)
        {
            

            label4.Text = "";

            Grabber progressCircle = new Grabber();
            progressCircle.progressCircle(bunifuCircleProgressbar1);
            this.Controls.Add(bunifuCircleProgressbar1);

            string @url = urlTextBox.Text;
            

            //HtmlWeb web = new HtmlWeb();
           // HtmlAgilityPack.HtmlDocument doc = web.Load(url);

            string[] meta = new string[3] { "KEYWORDS", "keywords", "Keywords" };
            string[] metaDescription = new string[3] {"description","Description","DESCRIPTION" };
            //string[] metaAuthers = new string[3] {"AUTHER","Author","author" };
         

                
        //var node1= doc.DocumentNode.SelectSingleNode("//head/meta[@name='Keywords']");

                try
                {
                        
                        if (@url != "" && @url != null)
                        {
                            Grabber titleGrabber = new Grabber();
                            var title = titleGrabber.titleOptimize(url);
                            label4.Text = "--TITLE--\nTitle is : " + title;
                            label4.Text += "\nTitle is OK\n";

                            Grabber keywordGrabber = new Grabber();
                            var keywordOptimizeResult = keywordGrabber.keywordOptimize(url, meta);
                            label4.Text += keywordOptimizeResult;
                            
                        

                            Grabber descriptionGrabber = new Grabber();
                            var des = descriptionGrabber.metaGrabToString(url, metaDescription);
                            label4.Text += descriptionGrabber.descriptionOptimize(des);

                            //ProgressCircle
                            bunifuCircleProgressbar1.Value += 50;
                        }
                        else {
                            MessageBox.Show("URL must be provided.","Hello!");
                        }
                }
                catch(Exception ex){
                    MessageBox.Show(ex.StackTrace, "Oppz, Sorry");
                }

                
            
            }
                     

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void WebScrapper_Load(object sender, EventArgs e)
        {

        }

        private void scrapBtn_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void scrapBtn_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void scrapBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            scrapBtn.BackColor = Color.Azure;
        }

        private void urlTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            urlTextBox.Text = "";
            urlTextBox.BackColor = Color.Azure;
        }
    }
}
