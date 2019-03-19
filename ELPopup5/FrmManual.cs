using ELPopup5.Classes;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ELPopup5
{
    public partial class FrmManual : Form
    {

        private string ManualFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CallerID.com\ELPopup5\Local";

        public FrmManual(int page = 1)
        {
            InitializeComponent();

            if (!Directory.Exists(ManualFile))
            {
                Directory.CreateDirectory(ManualFile);
            }

            FrmTimerMsgBox fDownloading;
            if (!File.Exists(ManualFile))
            {
                fDownloading = new FrmTimerMsgBox("Updating Manual", "Downloading Manual from CallerID.com.", 100000);
                fDownloading.Show();

                try
                {
                    using(WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri("https://secure.callerid.com/downloads/files/ELPopup5_Manual.pdf"), ManualFile + @"\ELPopup5_Manual.pdf");
                    }
                }
                catch(Exception ex)
                {
                    if (fDownloading.Visible) fDownloading.Close();
                    Console.Write("Failed download: " + ex.ToString());
                    Common.MessageBox("Manual Download Failed", "Local Manual not found and Remote Manual download failed. Please check Internet Connection.",
                        true, DialogResult.OK, false, DialogResult.None, false, DialogResult.None, "Ok", "", "", 1);
                }

                if (fDownloading.Visible) fDownloading.Close();
            }
            else
            {
                fDownloading = new FrmTimerMsgBox("Updating Manual", "Downloading Manual from CallerID.com.", 100000);
                fDownloading.Show();

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri("https://secure.callerid.com/downloads/files/ELPopup5_Manual.pdf"), ManualFile + @"\ELPopup5_Manual.pdf");
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Failed download: " + ex.ToString());
                }

                if (fDownloading.Visible) fDownloading.Close();
            }

            GotoPage(page);
        }

        public void GotoPage(int page)
        {
            wbManual.Navigate(ManualFile + @"\ELPopup5_Manual.pdf" + String.Format("#page={0}", page));
        }
    }
}
