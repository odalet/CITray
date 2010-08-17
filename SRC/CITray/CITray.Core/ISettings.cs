using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CITray.Settings;

namespace CITray
{
    public interface ISettings
    {
        GlobalSettings Global { get; }
    }
}
