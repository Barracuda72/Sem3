using System;
using Cairo;

namespace Draw
{
	public abstract class Figure : Draw.Point 
	{
		protected int a;

		public Figure (int x, int y, int a) : base(x,y)
		{
			SetDim (a);
		}

		public Figure () : base()
		{
			SetDim (10);
		}

		public Figure(int x, int y, int a, Color color) : base(x,y,color)
		{
			SetDim (a);
		}

		protected void SetDim(int a)
		{
			this.a = a;
		}

		protected abstract override void Draw(Cairo.Context g);
	}
}

