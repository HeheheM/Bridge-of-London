using System;
using LeagueSharp;
using MoonSharp.Interpreter;
using SharpDX;

namespace Bridge_of_London.Core.API.Util
{
    class UtilApi
    {
        public static void AddApi(Script script)
        {
            script.Globals["GetTickCount"] = (Func<int>) GetTickCount;
            script.Globals["GetLatency"] = (Func<int>) GetPing;
            script.Globals["GetCursorPos"] = (Func<Vector3>) GetCursorPosition;
            script.Globals["GetGameTimer"] = (Func<float>) GetGameTime;
        }

        private static float GetGameTime()
        {
            return Game.Time;
        }

        private static Vector3 GetCursorPosition()
        {
            return Game.CursorPos;
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
