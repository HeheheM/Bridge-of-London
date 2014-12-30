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

        public static void Init()
        {
            // Create directories
            if (!Directory.Exists(RootScriptDir))
                Directory.CreateDirectory(RootScriptDir);

            if (!Directory.Exists(RootLibScriptDir))
                Directory.CreateDirectory(RootLibScriptDir);

            // Initialize list
            Scripts = new List<Script>();
           
            Console.WriteLine(Directory.GetFiles(RootScriptDir).Count());
            foreach (var scriptFile in Directory.GetFiles(RootScriptDir))
            {
                var script = new Script();
                ApiHandler.AddApi(script);

                //Get each lib file, and load it to the script
                foreach (var libFile in Directory.GetFiles(RootLibScriptDir))
                {
                    script.LoadFile(libFile);
                }

                //We don't run the script, but instead load it and call it's functions.
                script.LoadFile(scriptFile);

                // Add script to the list
                Scripts.Add(script);
            }
        }
    }
}
