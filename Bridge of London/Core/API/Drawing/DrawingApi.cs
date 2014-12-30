using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;
using SharpDX;
using SharpDX.Direct3D9;
using Color = System.Drawing.Color;

namespace Bridge_of_London.Core.API.Drawing
{
    class DrawingApi
    {
        class RGBA
        {
            private int R;
            private int G;
            private int B;
            private int A;

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
                return Color.FromArgb(R, G, B, A);
            }
        }

        public static void AddApi(Script script)
        {
            UserData.RegisterType<RGBA>();
            script.Globals["RGBA"] = (Func<int, int, int ,int, RGBA>) MakeRGBA;
            script.Globals["DrawText"] = (Action<string, int, float, float, RGBA>) DrawText;
            script.Globals["DrawLine"] = (Action<float, float, float, float, int, RGBA>) DrawLine;
            script.Globals["DrawCircle"] = (Action<float, float, float, int, RGBA>)  DrawCircle;
        }

        private static RGBA MakeRGBA(int r, int g, int b, int a)
        {
            return new RGBA(r, g, b, a);
        }


        private static void DrawCircle(float x, float y, float z, int size, RGBA color)
        {
            LeagueSharp.Drawing.DrawCircle(new Vector3(x, y, z), size, color.ToSystemColor());
        }

        private static void DrawLine(float x1, float x2, float y1, float y2, int size, RGBA color)
        {
            LeagueSharp.Drawing.DrawLine(x1, y1, x1, x2, size, color.ToSystemColor());
        }

        private static void DrawText(string text, int size, float x, float y, RGBA color)
        {
            LeagueSharp.Drawing.DrawText(x, y, color.ToSystemColor(), text);
        }
    }
}
