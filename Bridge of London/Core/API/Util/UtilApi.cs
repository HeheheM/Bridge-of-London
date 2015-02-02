using System;
using Bridge_of_London.Classes;
using LeagueSharp;
using MoonSharp.Interpreter;

namespace Bridge_of_London.Core.API.Util
{
    class UtilApi
    {
        public static void AddApi(Script script)
        {
            UserData.RegisterType<Position>();

            script.Globals["GetTickCount"] = (Func<int>) GetTickCount;
            script.Globals["GetLatency"] = (Func<int>) GetPing;
            script.Globals["GetCursorPos"] = (Func<Position>) GetCursorPosition;
            script.Globals["GetGameTimer"] = (Func<float>) GetGameTime;
        }

        private static float GetGameTime()
        {
            return Game.Time;
        }

        private static Position GetCursorPosition()
        {
            return new Position(Game.CursorPos.X, Game.CursorPos.Y, Game.CursorPos.Z);
        }

        private static int GetPing()
        {
            return Game.Ping;
        }

        private static int GetTickCount()
        {
            return Environment.TickCount;
        }
    }
}
