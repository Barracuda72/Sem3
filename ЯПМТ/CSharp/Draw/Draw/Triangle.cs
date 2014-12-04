using System;
using Cairo;

namespace Draw
{
	public class Triangle : Draw.Figure
	{
		public Triangle (int x, int y, int a) : base(x,y,a)
		{
		}

		public Triangle () : base()
		{
			SetDim (10);
		}

		public Triangle(int x, int y, int a, Color color) : base(x,y,a,color)
		{
		}

		protected override void Draw(Cairo.Context g)
		{
			int _x;

			for (_x = x-a/2; _x <= x+a/2; _x++) 
			{
				g.MoveTo (x, y-a/2);
				g.LineTo (_x, y+a/2);
			}
		}
	}
}

