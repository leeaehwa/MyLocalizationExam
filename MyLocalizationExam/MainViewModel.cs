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

                //이렇게 해놓고 프로그램을 다시켜야 설정이 적용된다고 팝업을 띄우자 비쥬얼스튜디오도 언어 변경할때 그렇게 처리하고있당.
                //프로그램이 다시 켜지면 setting에 저장된걸 가지고와서 적용시키니까 문제가 없음!

//                SelectCulture(Properties.Settings.Default.Locale);
            }
        }
    }
}
