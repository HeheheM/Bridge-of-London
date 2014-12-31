#region

using System;
using LeagueSharp;
using MoonSharp.Interpreter;
using SharpDX;
using Color = System.Drawing.Color;

#endregion

namespace Bridge_of_London.Core.API.Drawing
{
    internal class DrawingApi
    {
        public static void AddApi(Script script)
        {
            UserData.RegisterType<RGBA>();
            script.Globals["RGBA"] = (Func<int, int, int, int, RGBA>) MakeRGBA;
            script.Globals["DrawCircle"] = (Action<float, float, float, float, RGBA>) DrawCircle;
            script.Globals["DrawText"] = (Action<string, int, float, float, RGBA>) DrawText;
            script.Globals["DrawLine"] = (Action<float, float, float, float, float, RGBA>) DrawLine;
        }

        private static RGBA MakeRGBA(int r, int g, int b, int a)
        {
            return new RGBA(r, g, b, a);
        }

        private static void DrawCircle(float x, float y, float z, float size, RGBA color)
        {
            Game.PrintChat("DrawCircle was called {0}:{1}:{2} {3}", x, y, z, size);
            LeagueSharp.Drawing.DrawCircle(new Vector3(x, y, z), size, color.ToSystemColor());
        }

        private static void DrawLine(float x1, float x2, float y1, float y2, float size, RGBA color)
        {
            LeagueSharp.Drawing.DrawLine(x1, y1, x1, x2, size, color.ToSystemColor());
        }

        private static void DrawText(string text, int size, float x, float y, RGBA color)
        {
            LeagueSharp.Drawing.DrawText(x, y, color.ToSystemColor(), text);
        }

        private class RGBA
        {
            private readonly int A;
            private readonly int B;
            private readonly int G;
            private readonly int R;

            public RGBA(int r, int g, int b, int a)
            {
                R = r;
                G = g;
                B = b;
                A = a;
            }

            public RGBA()
            {
                R = 0;
                G = 0;
                B = 0;
                A = 0;
            }

            public Color ToSystemColor()
            {
                return Color.FromArgb(A, R, G, B);
            }
        }
    }
}