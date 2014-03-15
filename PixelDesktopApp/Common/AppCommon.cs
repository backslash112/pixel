using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Common
{
    public class AppCommon
    {
        private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        private static AppCommon instance;
        public static AppCommon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppCommon();
                }
                return AppCommon.instance;
            }
        }

        private const string LAUNCHED = "Launched";
        private bool? _launched;

        /// <summary>
        /// 启动过
        /// </summary>
        public bool? Launched
        {
            get
            {
                if (settings.Contains(LAUNCHED))
                {
                    _launched = (bool)settings[LAUNCHED];
                }
                return _launched;
            }
            set
            {
                _launched = value;
                settings[LAUNCHED] = value;
            }
        }
    }
}
