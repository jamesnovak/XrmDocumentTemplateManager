using System;
using System.Collections.Generic;

namespace Futurez.Xrm.Tools.AppCode
{
    public class ActionEventArgs : EventArgs
    {
        public string Action { get; set; }
        public List<string> Files { get; set; } = new List<string>();
    }
}