using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace Xilium.CefGlue.Client
{
    class MySchemeHandlerFactory : CefSchemeHandlerFactory
    {
        public MySchemeHandlerFactory()
        {

        }

        protected override CefResourceHandler Create(CefBrowser browser, CefFrame frame, string schemeName, CefRequest request)
        {
            return new MySchemeHandler();
        }
    }
}
