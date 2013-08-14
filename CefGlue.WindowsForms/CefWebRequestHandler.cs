namespace Xilium.CefGlue.WindowsForms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    internal sealed class CefWebRequestHandler : CefRequestHandler
    {
        string internalUrl = "http://elnos.ru/";
        int    internalUrlLen;

        private readonly CefWebBrowser _core;

        public CefWebRequestHandler(CefWebBrowser core)
        {
            _core = core;
            this.internalUrlLen = this.internalUrl.Length;
        }

        protected override bool OnQuotaRequest(CefBrowser browser, string originUrl, long newSize, CefQuotaCallback callback)
        {
            throw new NotImplementedException();
        }

        protected override bool OnBeforeResourceLoad(CefBrowser browser, CefFrame frame, CefRequest request)
        {
            if (request.Url.Substring(0, this.internalUrlLen) == this.internalUrl)
            {
                return true;
            }

            return base.OnBeforeResourceLoad(browser, frame, request);
        }
    }
}
