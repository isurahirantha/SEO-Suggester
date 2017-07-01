using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace webscapper
{
    class Grabber
    {
        

        public string metaGrabToString(string url,string[] meta) {

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
                    
                        //string[] meta = new string[3] { "KEYWORDS", "keywords", "Keywords" };
                        string x=null;
                        foreach (var elements in meta)
                        {

                            HtmlNode node1 = doc.DocumentNode.SelectSingleNode("//head/meta[@name='" + elements + "']");
                            if (node1 == null)
                            {
                                continue;
                            }
                            
                            x = node1.GetAttributeValue("content", "");
                            
                        }
                        //HtmlNode node1 = doc.DocumentNode.SelectSingleNode("//head/meta[@name='keywords']");
                    
                    
                    return x;
        }
        public string titleOptimize(string url) {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("//head/title/text()");
            string titleString;
            
            // label4.Text = "\t"+node.Name.ToUpper() + ": " + node.OuterHtml;
            titleString = "\t" + "" + node.OuterHtml;
            return titleString;
        }

        //Keyword grabber method
        public string keywordOptimize(string url,string[] meta) {
            var keywordString = metaGrabToString(url, meta);

            string keywordResult;
            keywordResult = "\n\n\t--META KEYWORDS--\n";

                if (keywordString != null) {
               
                    string[] keywordsarray = keywordString.Split(',');
                    int len = keywordsarray.Length;

                        if (len < 5 && len > 0)
                        {
                            keywordResult += "\n\t" + "" + keywordString;
                            keywordResult += "\n\tTHERE SHOULD BE ATLEAST FIVE(5) KEYWORDS";
                        }
                        else
                        {
                            keywordResult += "\n\t" + "" + keywordString;
                            keywordResult += "\n\tKEYWORDS COUNT IS GOOD";
                        }

                }else{
                    //keywordResult += "\n\n\t__META KEYWORDS__\n";
                    keywordResult += "PTOVIDE KEYWORDS";
                    keywordResult += "\n<meta name='keywords' contents='keyword1,keyword2,keyword3,etc'> ";
                    keywordResult += "\nTHERE SHOULD BE ATLEAST Five(5) KEYWORDS";
                }
            return keywordResult;
        }

        public string descriptionOptimize(string des) {
            string descriptionResult;
            descriptionResult = "\n\n\t--META DESCRIPTION--";
            descriptionResult += "\n\t" + "" + des;
            if (des == null)
            {
                descriptionResult += "\n\tProvide a description to the website\n<meta name='description' content='some description here..'>";
            }
            else
            {
                descriptionResult += "\n\tMETA DESCRIPTION IS OK";
            }
            return descriptionResult;
        }

        public void progressCircle(ns1.BunifuCircleProgressbar bunifuCircleProgressbar1) {
            if (bunifuCircleProgressbar1.Value == 100)
            {
                bunifuCircleProgressbar1.Value = 0;
            }
            bunifuCircleProgressbar1.Value = 50;

            bunifuCircleProgressbar1.animated = true;
            bunifuCircleProgressbar1.LineProgressThickness = 15;
            bunifuCircleProgressbar1.LineThickness = 5;
            //bunifuCircleProgressbar1.animationIterval = 10;
            //bunifuCircleProgressbar1.animationSpeed = 10;

            
        }
    }
}
