using SharpAlertPluginBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SharpAlert.ProgramWorker
{
    public static class PluginManager
    {
        private static readonly List<IPlugHandler> _plugins = [];

        public static IReadOnlyList<IPlugHandler> Plugins => _plugins;

        public static void LoadPlugins(string PluginDirectory)
        {
            if (_plugins.Count > 0)
            {
                Console.WriteLine("[Plugin Manager] Cannot load plugins if there are plugins already loaded.");
                return;
            }

            try
            {
                if (!Directory.Exists(PluginDirectory)) return;

                foreach (string dll in Directory.GetFiles(PluginDirectory, "*.dll", SearchOption.TopDirectoryOnly))
                {
                    try
                    {
                        //var assembly = Assembly.LoadFrom(dll, byte[]?, System.Configuration.Assemblies.AssemblyHashAlgorithm.MD5);
                        Assembly assembly = Assembly.LoadFrom(dll);

                        IEnumerable<Type> pluginTypes = assembly
                            .GetTypes()
                            .Where(t =>
                                typeof(IPlugHandler).IsAssignableFrom(t) &&
                                !t.IsInterface &&
                                !t.IsAbstract);

                        foreach (Type type in pluginTypes)
                        {
                            if (Activator.CreateInstance(type) is IPlugHandler plugin)
                            {
                                Directory.CreateDirectory(PluginDirectory + $"\\{plugin.PluginUUID}");

                                if (plugin.Initialize(VersionInfo.MajorVersion, VersionInfo.MinorVersion, VersionInfo.IsBetaVersion, PluginDirectory + $"\\{plugin.PluginUUID}"))
                                {
                                    _plugins.Add(plugin);
                                    Console.WriteLine($"[Plugin Manager] Successfully loaded: {plugin.FriendlyName} ({dll})");
                                }
                                else
                                {
                                    MessageBox.Show($"The plugin \"{plugin.FriendlyName}\" did not load correctly.", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"[Plugin Manager] Unsuccessful load: ({dll}) | The file doesn't appear to be a valid plugin for this version.");
                                MessageBox.Show($"The plugin at \"{dll}\" seems to be invalid or out of date. Check for an update from the plugin author.", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Plugin Manager] Unsuccessful load: {dll} | {ex.Message}");
                        MessageBox.Show($"The plugin at \"{dll}\" seems to be invalid or out of date. Check for an update from the plugin author. {ex.Message}", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Plugin Manager] There was a problem loading plugins: {ex.Message}");
                MessageBox.Show($"There was a problem while attempting to load plugins. Check for an update from the plugin author. {ex.Message}", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
