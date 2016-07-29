using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace MyLocalizationExam
{
    class MainViewModel
    {
        private int _language;
        public int Language 
        {
            get { return _language; }
            set
            {
                //언어 설정 적용시키는 작업을 해야한다.
                _language = value;
                if (value == 0)
                    Properties.Settings.Default.Locale = "ko-KR";
                else
                    Properties.Settings.Default.Locale = "en-US";
                Properties.Settings.Default.Save();

                SelectCulture(Properties.Settings.Default.Locale);
            }
        }

        public static void SelectCulture(string culture)
        {
            // List all our resources       
            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            foreach (ResourceDictionary dictionary in Application.Current.Resources.MergedDictionaries)
            {
                dictionaryList.Add(dictionary);
            }
            // We want our specific culture       
            string requestedCulture = string.Format("/Assets/StringResources.{0}.xaml", culture);
            ResourceDictionary resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString == requestedCulture);
            if (resourceDictionary == null)
            {
                //리소스를 찾을수 없다면 기본 리소스로 지정      
                requestedCulture = "/Assets/StringResources.ko-KR.xaml";
                resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString == requestedCulture);
            }
            if (resourceDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }

            //지역화 설정
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);





            //윈도우 새로고침같은걸 어캐하지

        
        
        }
    }
}
