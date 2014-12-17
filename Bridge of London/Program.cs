using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge_of_London.Core;
using LeagueSharp.Common;

namespace Bridge_of_London
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += GameOnOnGameLoad;
        }

        private static void GameOnOnGameLoad(EventArgs args)
        {
            // Load all the scripts
            ScriptLoader.Init();
        }
    }
}
