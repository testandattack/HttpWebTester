using System;
using System.Collections.Generic;
using System.Text;

namespace GTC.HttpWebTester.Settings
{
    public interface ISettings
    {
        void LoadSettings(string fileName);

        Settings ReadSettingsFromFile(string fileName);
    }
}
