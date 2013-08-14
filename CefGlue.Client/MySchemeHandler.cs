using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xilium.CefGlue;
using System.IO;
using System.Threading;
using System.Collections.Specialized;
using System.Web;

namespace Xilium.CefGlue.Client
{
    class URLCallback
    {
        public string      url;
        public CefCallback callback;
    }

    class MySchemeHandler : CefResourceHandler
    {
        byte[] responseData;
        int    pos;

        void MyThread(object parameter)
        {
            var urlCallback = (parameter as URLCallback);
            var callback = urlCallback.callback;
            var url      = urlCallback.url;

            NameValueCollection queryPars = HttpUtility.ParseQueryString(url);
            string remoteCallback = queryPars[0];
            string remoteData     = queryPars[1];
            responseData = Encoding.UTF8.GetBytes(remoteCallback + "(" + remoteData + ");");

            Thread.Sleep(1000); // Wait 1 sec

            callback.Continue();
        }
        void MyThreadStart(object parameter)
        {
            var urlCallback = (parameter as URLCallback);
            var callback = urlCallback.callback;
            var url      = urlCallback.url;

            NameValueCollection queryPars = HttpUtility.ParseQueryString(url);
            string remoteCallback = queryPars[0];
            string remoteData     = queryPars[1];
            responseData = Encoding.UTF8.GetBytes(remoteCallback + "(\"Hello from scan procedure\");");

            Thread.Sleep(2000); // Wait 2 sec

            callback.Continue();
        }
        void MyThreadGet(object parameter)
        {
            var urlCallback = (parameter as URLCallback);
            var callback = urlCallback.callback;
            var url      = urlCallback.url;

            NameValueCollection queryPars = HttpUtility.ParseQueryString(url);
            string remoteCallback = queryPars[0];
            string remoteData     = queryPars[1];
            responseData = Encoding.UTF8.GetBytes(remoteCallback + "(\"Hello from get procedure\");");

            Thread.Sleep(0); // Wait 0 sec

            callback.Continue();
        }

        protected override bool ProcessRequest(CefRequest request, CefCallback callback)
        {
            var parameter = new URLCallback();
            parameter.url      = request.Url;
            parameter.callback = callback;

            var uri = new Uri(request.Url);

            if (uri.LocalPath == "/connection/scan/start")
            {
                var mythread = new Thread(new ParameterizedThreadStart(this.MyThreadStart));
                mythread.Start(parameter);
            }
            else if (uri.LocalPath == "/connection/scan/get")
            {
                var mythread = new Thread(new ParameterizedThreadStart(this.MyThreadGet));
                mythread.Start(parameter);
            }

            return true;
        }

        protected override void GetResponseHeaders(CefResponse response, out long responseLength, out string redirectUrl)
        {
            response.MimeType   = "application/javascript";
            response.Status     = 200;
            response.StatusText = "OK";

            var headers = new NameValueCollection(StringComparer.InvariantCultureIgnoreCase);
            headers.Add("Cache-Control", "private");
            response.SetHeaderMap(headers);

            responseLength = responseData.LongLength;
            redirectUrl = null;
        }

        protected override bool ReadResponse(Stream response, int bytesToRead, out int bytesRead, CefCallback callback)
        {
            if (bytesToRead == 0 || pos >= responseData.Length)
            {
                bytesRead = 0;
                return false;
            }
            else
            {
                response.Write(responseData, pos, bytesToRead);
                pos += bytesToRead;
                bytesRead = bytesToRead;
                return true;
            }
        }

        protected override bool CanGetCookie(CefCookie cookie)
        {
            return false;
        }

        protected override bool CanSetCookie(CefCookie cookie)
        {
            return false;
        }

        protected override void Cancel()
        {
        }
    }
}
