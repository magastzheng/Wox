﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Wox.Plugin.System
{
    [global::System.ComponentModel.Browsable(false)]
    public class CommonStartMenuProgramSource : FileSystemProgramSource
    {
        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);
        const int CSIDL_COMMON_STARTMENU = 0x16;  // \Windows\Start Menu\Programs
        const int CSIDL_COMMON_PROGRAMS = 0x17;

        private static string getPath()
        {
            StringBuilder commonStartMenuPath = new StringBuilder(560);
            SHGetSpecialFolderPath(IntPtr.Zero, commonStartMenuPath, CSIDL_COMMON_PROGRAMS, false);

            return commonStartMenuPath.ToString();
        }

        public CommonStartMenuProgramSource()
            : base(getPath())
        {
        }

        public CommonStartMenuProgramSource(Wox.Infrastructure.UserSettings.ProgramSource source)
            : this()
        {
            this.BonusPoints = source.BounsPoints;
        }

    }
}
