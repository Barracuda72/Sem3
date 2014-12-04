using System;
using Gtk;

namespace Draw {
	public partial class MainWindow: Gtk.Window
	{
		Draw.Point [] points;
		int Num;

		int n {
			get { return Num; }
			set {
				Num = value;
				labelNum.LabelProp = Num.ToString();
			}
		}

		public MainWindow () : base (Gtk.WindowType.Toplevel)
		{
			Build ();

			canvas.AddEvents ((int) Gdk.EventMask.AllEventsMask);

			ClearPoints ();
		}

		protected void ClearPoints()
		{
			int i;

			points = new Point[100];

			for (i = 0; i < points.Length; i++) 
			{
				points [i] = null;
			}

			n = 0;
		}

		void OnDrawingAreaExposed (object o, ExposeEventArgs args)
		{
			int i;
			DrawingArea area = (DrawingArea) o;
			using (Cairo.Context context = Gdk.CairoHelper.Create (area.GdkWindow)) {

				// Perform some drawing
				for (i = 0; i < n; i++) 
				{
					points[i].Print (context);
				}

				((IDisposable) context.GetTarget()).Dispose ();
			}
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		protected void OnDrawingAreaRelease (object o, ButtonReleaseEventArgs args)
		{
			int x,y,i;
			Gdk.ModifierType s;

			args.Event.Window.GetPointer (out x, out y, out s);

			if (n < points.Length) 
			{
				Cairo.Color c = new Cairo.Color (
					                scaleRed.Value / scaleRed.Adjustment.Upper,
					                scaleGreen.Value / scaleGreen.Adjustment.Upper,
					                scaleBlue.Value / scaleBlue.Adjustment.Upper
				                );

				if (radioRandom.Active) 
				{
					points [n] = PointFactory.getRandomPoint (
									x, y, ((int)scaleSize.Value), c
								);
				} else {
					if (radioPoint.Active)
						i = PointFactory.DPoint;
					else if (radioTriangle.Active)
						i = PointFactory.DTriangle;
					else if (radioCircle.Active)
						i = PointFactory.DCircle;
					else if (radioSquare.Active)
						i = PointFactory.DSquare;
					else // Something wrong with this world
						i = -1;

					points [n] = PointFactory.getPoint (
						i, x, y, ((int)scaleSize.Value), c
					);
				}
				n++;
				canvas.QueueDraw ();
			}
		}

		protected void OnClearButtonClicked (object sender, EventArgs e)
		{
			ClearPoints ();
			canvas.QueueDraw ();
		}
	}
}