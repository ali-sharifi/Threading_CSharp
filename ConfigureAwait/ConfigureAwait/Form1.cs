using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigureAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();
            //string content = await client.GetStringAsync("http://www.bing.com");
            //    //.ConfigureAwait(false);
            //Task<string> t=Task.Run(async()=> { return await client.GetStringAsync("http://www.bing.com"); });
            //label1.Text = t.Result;

            var te = await DownloadContent();
            label1.Text = te;



            //HttpClient client = new HttpClient();
            //string content = await client.GetStringAsync("http://www.bing.com").ConfigureAwait(false);

            //using (FileStream stream=new FileStream("temp.html", FileMode.Create,FileAccess.Write,FileShare.None,4096, useAsync:true))
            //{
            //    byte[] encodedText = Encoding.Unicode.GetBytes(content);
            //    await stream.WriteAsync(encodedText, 0, encodedText.Length).ConfigureAwait(false);
            //}
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://www.bing.com").ConfigureAwait(true);
                return result;
            }
        }
    }
}
