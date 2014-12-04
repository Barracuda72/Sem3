using System;
using Cairo;

namespace Draw
{
	public class PointFactory
	{
		static Random rand = null;

		public const int DPoint = 0;
		public const int DTriangle = 1;
		public const int DCircle = 2;
		public const int DSquare = 3;

		static PointFactory()
		{
			rand = new Random ();
		}

		public PointFactory ()
		{
		}

		public static Draw.Point getRandomPoint(int x, int y, int a, Color color)
		{
			int r = rand.Next (0, 4);

			return getPoint(r, x, y, a, color);
		}

		public static Draw.Point getPoint(int t, int x, int y, int a, Color color)
		{
			switch (t) 
			{
			    case DPoint: 
					return new Draw.Point (x, y, color);

				case DTriangle: 
					return new Draw.Triangle (x, y, a, color);

				case DCircle: 
					return new Draw.Circle (x, y, a, color);

				case DSquare: 
					return new Draw.Square(x, y, a, color);

				default:
					return null;  // Shut up, damn compilier
			}
		}
	}
}

