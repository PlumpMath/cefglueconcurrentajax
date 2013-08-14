namespace Xilium.CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using Xilium.CefGlue;

    internal sealed class DemoApp : CefApp
    {
        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
            ;
        }

        protected override CefBrowserProcessHandler GetBrowserProcessHandler()
        {
            return base.GetBrowserProcessHandler();
        }

        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
            return base.GetRenderProcessHandler();
        }
    }
}
