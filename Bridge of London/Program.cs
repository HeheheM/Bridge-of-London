using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge_of_London.Core;
using Bridge_of_London.Core.API;
using LeagueSharp;
using LeagueSharp.Common;

namespace Bridge_of_London
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += GameOnOnGameLoad;
            CustomEvents.Game.OnGameLoad += ApiHandler.OnGameLoad;
        }

        private static void GameOnOnGameLoad(EventArgs args)
        {
            // Load all the scripts
            ScriptLoader.Init();

            Game.OnGameUpdate += ApiHandler.OnGameUpdate;
        }
    }
}
