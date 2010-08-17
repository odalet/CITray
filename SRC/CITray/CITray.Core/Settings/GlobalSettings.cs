using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace CITray.Settings
{
    public class GlobalSettings
    {
        public GlobalSettings()
        {
            Clear();
        }

        public string PluginsFolder { get; internal set; }

        public string[] EnabledPlugins { get; internal set; }

        internal void Load(XElement root)
        {
            PluginsFolder = root.Element("pluginsFolder").Value;
            EnabledPlugins = root.Element("enabledPlugins").Elements("assembly").Select(x => x.Value).ToArray();
        }

        internal IEnumerable<XElement> Save()
        {
            return new XElement[]
            {
                new XElement("pluginsFolder", PluginsFolder),
                new XElement("enabledPlugins",
                    EnabledPlugins.Select(s =>
                        new XElement("assembly", s)
                    )
                )
            };
        }

        internal void Clear()
        {
            PluginsFolder = string.Empty;
            EnabledPlugins = new string[0];
        }
    }
}
