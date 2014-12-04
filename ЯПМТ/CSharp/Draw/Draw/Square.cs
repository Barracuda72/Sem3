using System;
using Cairo;

namespace Draw
{
	public class Square : Figure
	{
		public Square (int x, int y, int a) : base(x,y,a)
		{
		}

		public Square () : base()
		{
			SetDim (10);
		}

		public Square(int x, int y, int a, Color color) : base(x,y,a,color)
		{
		}


		protected override void Draw(Cairo.Context g)
		{
			int _x;

			for (_x = x-a/2; _x <= x+a/2; _x++) 
			{
				g.MoveTo (_x, y-a/2);
				g.LineTo (_x, y+a/2);
			}
		}
	}
}

