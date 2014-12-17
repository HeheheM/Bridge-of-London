using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge_of_London.Core.API;
using LeagueSharp.Common;
using MoonSharp.Interpreter;

namespace Bridge_of_London.Core
{
    class ScriptLoader
    {
        public static string RootScriptDir = Path.Combine(Config.LeagueSharpDirectory, "Lua");
        public static string RootLibScriptDir = Path.Combine(RootScriptDir, "Lib");

        public static List<Script> Scripts;
        public static List<Script> Libraries;

        public static void Init()
        {
            // Create directories
            if (!Directory.Exists(RootScriptDir))
                Directory.CreateDirectory(RootScriptDir);

            if (!Directory.Exists(RootLibScriptDir))
                Directory.CreateDirectory(RootLibScriptDir);

            // Initialize lists
            Scripts = new List<Script>();
            Libraries = new List<Script>();

            foreach (var libScript in Directory.GetFiles(RootLibScriptDir).Where(x => x.EndsWith(".lua")))
            {
                var script = new Script();
                ApiHandler.AddApi(script);
                script.LoadFile(libScript);

                // Add script to the list
                Libraries.Add(script);
            }

            foreach (var scriptFile in Directory.GetFiles(RootScriptDir).Where(x => x.EndsWith(".lua")))
            {
                var script = new Script();
                ApiHandler.AddApi(script);
                script.DoFile(scriptFile);

                // Add script to the list
                Scripts.Add(script);
            }
        }
    }
}
