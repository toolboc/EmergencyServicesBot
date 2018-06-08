using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using System.Web;

namespace EmergencyServicesBot.Dialogs
{
    [Serializable]
    public class SetLanguage : IDialog<object>
    {
        static ResourceManager translateDialog = new ResourceManager("EmergencyServicesBot.Resources.Resources", Assembly.GetExecutingAssembly());

        //Set the language to be used; you can change this on-demand to change the langauage across the app
        //You will pass this everytime you request a value from the resx file
        static CultureInfo ciEnglish = new CultureInfo("en-US");
        static CultureInfo ciSpanish = new CultureInfo("es-US");
        static CultureInfo ciChinese = new CultureInfo("zh-CN");

        public async Task StartAsync(IDialogContext context)
        {
            // offer user languages currently supported
            string[] choices = new[] { @"English", @"Español", @"中文" };
            if (context.Activity.ChannelId == ChannelIds.Sms)
            {   // on SMS, communicate they can choose by replying with "1" or "2"
                choices = new[] { @"1 - English", @"2 - Español", @"3 - 中文" };
            }

            PromptDialog.Choice(
                context,
                this.onLanguageSelect,
                choices,
                translateDialog.GetString("SetLanguage", context.UserData.GetValue<CultureInfo>("cultureInfo")));
        }

        private async Task onLanguageSelect(IDialogContext context, IAwaitable<string> result)
        {
            // set the language preference in userData
            var selectedLanguage = await result;
            var choice = await result;
            CultureInfo culture;

            if (choice.IndexOf(@"english", 0, StringComparison.OrdinalIgnoreCase) != -1)
            {
                choice = "en";
                selectedLanguage = "English";
                culture = ciEnglish;
            }
            else if (choice.IndexOf(@"español", 0, StringComparison.OrdinalIgnoreCase) != -1)
            {
                choice = "es";
                selectedLanguage = "Español";
                culture = ciSpanish;
            }
            else if (choice.IndexOf(@"中文", 0, StringComparison.OrdinalIgnoreCase) != -1)
            {
                choice = "zh-CN";
                selectedLanguage = "中文";
                culture = ciChinese;
            }
            else
            {
                choice = "en";
                selectedLanguage = "English";
                culture = ciEnglish;
            }

            context.UserData.SetValue(@"userLanguage", choice);
            context.UserData.SetValue(@"cultureInfo", culture);

            var message = translateDialog.GetString("SetLanguageConfirmation", culture);

            await context.PostAsync(message + " " + selectedLanguage);

            context.Done(context);
        }
    }
}