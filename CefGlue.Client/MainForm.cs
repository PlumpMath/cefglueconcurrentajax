namespace Xilium.CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using Xilium.CefGlue.WindowsForms;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InitWebPage(Directory.GetCurrentDirectory() + @"\www\index.html");
        }

        private void InitWebPage(string url)
        {
            var webbrowser = new CefWebBrowser();

            webbrowser.StartUrl = url;
            webbrowser.Dock     = DockStyle.Fill;
            webbrowser.TitleChanged += (s, e) =>
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (webbrowser.Title == null || webbrowser.Title == "" || webbrowser.Title == "index.html")
                            return;

                        string title = webbrowser.Title;
                        this.Text = title;

                        CefBrowser browser = webbrowser.Browser;
                        CefFrame   frame   = webbrowser.Browser.GetMainFrame();
                        //CefV8Value obj     = 

                        // Execute JS code without result
                        // CefBrowser browser = webbrowser.Browser;
                        // CefFrame   frame   = webbrowser.Browser.GetMainFrame();
                        // frame.ExecuteJavaScript("alert('Hi!');", frame.Url, 0);
                    }));
                };

            this.Controls.Add(webbrowser);
        }
    }
}
