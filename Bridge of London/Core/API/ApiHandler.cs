using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using MoonSharp.Interpreter;

namespace Bridge_of_London.Core.API
{
    class ApiHandler
    {

        public static void AddApi(Script script)
        {
            script.Globals["PrintChat"] = (Action<string>) PrintChat;
        }


        #region Events

        public static void OnGameUpdate(EventArgs eventArgs)
        {
            foreach (var script in ScriptLoader.Scripts)
            {
                script.Call("OnTick");
            }
        }

        public static void OnGameLoad(EventArgs eventArgs)
        {
            foreach (var script in ScriptLoader.Scripts)
            {
                script.Call("OnLoad");
            }
        }
        #endregion

        #region Game Class
        private static void PrintChat(string text)
        {
            Game.PrintChat(text);
        }
        #endregion
    }
}
