using System;
using System.Globalization;

namespace Futurez.Xrm.Tools.AppCode
{
    public class LanguageItem
    {
        public LanguageItem(int lcid)
        {
            Culture = CultureInfo.GetCultureInfo(lcid);
        }

        public CultureInfo Culture { get; private set; }

        public override string ToString()
        {
            return Culture.EnglishName;
        }
    }
}