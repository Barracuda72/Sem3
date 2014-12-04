using System;
using Gtk;
using Cairo;

namespace Draw
{
	public class Point
	{
		protected int x, y;
		Cairo.Color color;

		public Point ()
		{
			SetPos (0, 0);
			SetColor (0, 0, 0);
		}

		public Point (int x, int y)
		{
			SetPos (x, y);
			SetColor (0, 0, 0);
		}

		public Point (int x, int y, Color color)
		{
			SetPos (x, y);
			this.color = color;
		}

		protected void SetPos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		protected void SetColor(byte r, byte g, byte b)
		{
			color = new Color (r, g, b);
		}

		protected virtual void Draw(Cairo.Context g)
		{
			g.MoveTo (x, y);
			g.LineTo (x+1, y+1);
		}

		protected void Compose (Cairo.Context g)
		{
			g.SetSourceRGBA (color.R, color.G, color.B, color.A);
			g.Stroke ();
		}

		public void Print(Cairo.Context g)
		{
			Draw (g);
			Compose (g);
		}
	}
}

