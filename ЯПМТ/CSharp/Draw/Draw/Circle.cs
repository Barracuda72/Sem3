using System;
using Cairo;

namespace Draw
{
	public class Circle : Draw.Figure 
	{
		public Circle (int x, int y, int a) : base(x,y,a)
		{
		}

		public Circle () : base()
		{
			SetDim (10);
		}

		public Circle(int x, int y, int a, Color color) : base(x,y,a,color)
		{
		}

		protected override void Draw(Cairo.Context g)
		{
			double t;
			int _x, _y;

			for (t = 0; t <= 2 * Math.PI; t += Math.PI / (4*a)) 
			{
				_x = (int)(a * Math.Cos (t)/2 + x);
				_y = (int)(a * Math.Sin (t)/2 + y);
				g.MoveTo (x, y);
				g.LineTo (_x, _y);
			}
		}
	}
}

