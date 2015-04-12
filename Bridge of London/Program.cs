#region

using System;
using Bridge_of_London.Core;
using Bridge_of_London.Core.API;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace Bridge_of_London
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += GameOnOnGameLoad;

            // Setup load event for the Lua API
            CustomEvents.Game.OnGameLoad += ApiHandler.OnGameLoad;
        }

        private static void GameOnOnGameLoad(EventArgs args)
        {
            // Load all the scripts
            ScriptLoader.Init();

            // API Events
            Game.OnUpdate += ApiHandler.OnGameUpdate;
            Drawing.OnDraw += ApiHandler.OnDraw;
            GameObject.OnCreate += ApiHandler.OnCreateObj;
            GameObject.OnDelete += ApiHandler.OnDeleteObj;
            Game.OnWndProc += ApiHandler.OnWndMsg;
            Obj_AI_Base.OnProcessSpellCast += ApiHandler.OnProcessSpellCast;
            Game.OnInput += ApiHandler.OnSendChat;
            Game.OnSendPacket += ApiHandler.OnSendPacket;
        }
    }
}
