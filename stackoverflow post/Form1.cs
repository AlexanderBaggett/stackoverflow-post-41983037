using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//http://stackoverflow.com/questions/41983037/screen-scraping-web-page-containing-button-with-ajax
namespace stackoverflow_post
{
    public partial class Form1 : Form
    {
        Timer t;
        public Form1()
        {
            InitializeComponent();
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            //will not complete until this method exists due to threading model
            webBrowser1.Navigate("www.google.com");
            //System.Threading.Thread.Sleep(3000);
        }
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = sender as WebBrowser;

            //check to make sure we are on the TOP-level page.
            if (wb.Document.Window.Parent == null)
            {
                t = new Timer();
                t.Tick += (Timersender, eventargs) =>
                {
                    //do whatever else you need to here
                    t.Stop();
                };
                t.Interval = 2000; //wait 2 seconds for the document to complete
                t.Start();
            }
        }

    }
}
