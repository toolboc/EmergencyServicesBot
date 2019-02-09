using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EmergencyServicesBot.Dialogs
{
    internal static class LanguageConst
    {
        //Set the language to be used; you can change this on-demand to change the langauage across the app
        //You will pass this everytime you request a value from the resx file
        internal static readonly CultureInfo ciEnglish = new CultureInfo("en-US");
        internal static readonly CultureInfo ciSpanish = new CultureInfo("es-US");
        internal static readonly CultureInfo ciChinese = new CultureInfo("zh-CN");
        internal static readonly CultureInfo ciFrench = new CultureInfo("fr-FR");

        internal const string enLanguageId = "en";
        internal const string esLanguageId = "es";
        internal const string frLanguageId = "fr";
        internal const string zhLanguageId = "zh-CN";
    }
}