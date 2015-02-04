#region

using System;
using Bridge_of_London.Core.API.Drawing;
using Bridge_of_London.Core.API.Unit;
using Bridge_of_London.Core.API.Util;
using LeagueSharp;
using MoonSharp.Interpreter;

#endregion

namespace Bridge_of_London.Core.API
{
    internal class ApiHandler
    {
        public static void AddApi(Script script)
        {
            script.Globals["PrintChat"] = (Action<string>) Game.PrintChat;

            //Add API's
            DrawingApi.AddApi(script);
            UtilApi.AddApi(script);
            UnitApi.AddApi(script);
        }

        private static void CallFunc(string funcName)
        {
            foreach (var script in ScriptLoader.Scripts)
            {
                script.Call(script.Globals[funcName]);
            }
        }

        #region Events

        public static void OnGameUpdate(EventArgs eventArgs)
        {
            CallFunc("OnTick");
        }

        public static void OnGameLoad(EventArgs eventArgs)
        {
            CallFunc("OnLoad");
        }

        public static void OnDraw(EventArgs args)
        {
            CallFunc("OnDraw");
        }

        public static void OnCreateObj(GameObject sender, EventArgs args)
        {
            foreach (var script in ScriptLoader.Scripts)
            {
                script.Call(script.Globals["OnCreateObj"], sender);
            }
        }

        public static void OnDeleteObj(GameObject sender, EventArgs args)
        {
            foreach (var script in ScriptLoader.Scripts)
            {
                script.Call(script.Globals["OnDeleteObj"], sender);
            }
        }

        public static void OnWndMsg(WndEventArgs args)
        {
            foreach (var script in ScriptLoader.Scripts)
            {
                script.Call(script.Globals["OnWndMsg"], args.Msg, args.WParam);
            }
        }

        public static void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            foreach (var script in ScriptLoader.Scripts)
            {
                script.Call(script.Globals["OnProcessSpell"], sender, args);
            }
        }

        public static void OnSendChat(GameInputEventArgs args)
        {
            foreach (var script in ScriptLoader.Scripts)
            {
                script.Call(script.Globals["OnSendChat"], args.Input);
            }
        }

        public static void OnSendPacket(GamePacketEventArgs args)
        {
            foreach (var script in ScriptLoader.Scripts)
            {
                //Disabled until CLoLPacket is implemented
                //script.Call(script.Globals["OnSendPacket"], args.)
            }
        }

        #endregion
    }
}