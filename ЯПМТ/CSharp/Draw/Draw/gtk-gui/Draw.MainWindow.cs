
// This file has been generated by the GUI designer. Do not modify.
namespace Draw
{
	public partial class MainWindow
	{
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.DrawingArea canvas;
		
		private global::Gtk.VSeparator vseparator1;
		
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.RadioButton radioPoint;
		
		private global::Gtk.RadioButton radioSquare;
		
		private global::Gtk.RadioButton radioTriangle;
		
		private global::Gtk.RadioButton radioCircle;
		
		private global::Gtk.RadioButton radioRandom;
		
		private global::Gtk.HBox hbox4;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.Label label7;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.VBox vbox4;
		
		private global::Gtk.HScale scaleSize;
		
		private global::Gtk.HScale scaleRed;
		
		private global::Gtk.HScale scaleGreen;
		
		private global::Gtk.HScale scaleBlue;
		
		private global::Gtk.HButtonBox hbuttonbox1;
		
		private global::Gtk.HBox hbox6;
		
		private global::Gtk.Alignment alignment1;
		
		private global::Gtk.HBox hbox7;
		
		private global::Gtk.Label label8;
		
		private global::Gtk.Label labelNum;
		
		private global::Gtk.Button buttonClear;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Draw.MainWindow
			this.Name = "Draw.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Рисовалка");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Draw.MainWindow.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.canvas = new global::Gtk.DrawingArea ();
			this.canvas.Name = "canvas";
			this.hbox1.Add (this.canvas);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.canvas]));
			w1.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator ();
			this.vseparator1.Name = "vseparator1";
			this.hbox1.Add (this.vseparator1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vseparator1]));
			w2.Position = 2;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 0F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Что рисуем:");
			this.vbox2.Add (this.label1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.label1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioPoint = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Точки"));
			this.radioPoint.CanFocus = true;
			this.radioPoint.Name = "radioPoint";
			this.radioPoint.DrawIndicator = true;
			this.radioPoint.UseUnderline = true;
			this.radioPoint.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.vbox2.Add (this.radioPoint);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.radioPoint]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioSquare = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Квадраты"));
			this.radioSquare.CanFocus = true;
			this.radioSquare.Name = "radioSquare";
			this.radioSquare.DrawIndicator = true;
			this.radioSquare.UseUnderline = true;
			this.radioSquare.Group = this.radioPoint.Group;
			this.vbox2.Add (this.radioSquare);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.radioSquare]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioTriangle = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Треугольники"));
			this.radioTriangle.CanFocus = true;
			this.radioTriangle.Name = "radioTriangle";
			this.radioTriangle.DrawIndicator = true;
			this.radioTriangle.UseUnderline = true;
			this.radioTriangle.Group = this.radioPoint.Group;
			this.vbox2.Add (this.radioTriangle);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.radioTriangle]));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioCircle = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Круги"));
			this.radioCircle.CanFocus = true;
			this.radioCircle.Name = "radioCircle";
			this.radioCircle.DrawIndicator = true;
			this.radioCircle.UseUnderline = true;
			this.radioCircle.Group = this.radioPoint.Group;
			this.vbox2.Add (this.radioCircle);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.radioCircle]));
			w7.Position = 4;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioRandom = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Случайно"));
			this.radioRandom.CanFocus = true;
			this.radioRandom.Name = "radioRandom";
			this.radioRandom.DrawIndicator = true;
			this.radioRandom.UseUnderline = true;
			this.radioRandom.Group = this.radioPoint.Group;
			this.vbox2.Add (this.radioRandom);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.radioRandom]));
			w8.Position = 5;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.vbox2]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Размер");
			this.vbox3.Add (this.label7);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label7]));
			w10.Position = 0;
			w10.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Красный");
			this.vbox3.Add (this.label4);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label4]));
			w11.Position = 1;
			w11.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Зеленый");
			this.vbox3.Add (this.label5);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label5]));
			w12.Position = 2;
			w12.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Синий");
			this.vbox3.Add (this.label6);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label6]));
			w13.Position = 3;
			w13.Fill = false;
			this.hbox4.Add (this.vbox3);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.vbox3]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.scaleSize = new global::Gtk.HScale (null);
			this.scaleSize.CanFocus = true;
			this.scaleSize.Name = "scaleSize";
			this.scaleSize.Adjustment.Lower = 10;
			this.scaleSize.Adjustment.Upper = 50;
			this.scaleSize.Adjustment.PageIncrement = 10;
			this.scaleSize.Adjustment.StepIncrement = 1;
			this.scaleSize.Adjustment.Value = 10;
			this.scaleSize.DrawValue = true;
			this.scaleSize.Digits = 0;
			this.scaleSize.ValuePos = ((global::Gtk.PositionType)(2));
			this.vbox4.Add (this.scaleSize);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.scaleSize]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.scaleRed = new global::Gtk.HScale (null);
			this.scaleRed.CanFocus = true;
			this.scaleRed.Name = "scaleRed";
			this.scaleRed.Adjustment.Upper = 100;
			this.scaleRed.Adjustment.PageIncrement = 10;
			this.scaleRed.Adjustment.StepIncrement = 1;
			this.scaleRed.DrawValue = true;
			this.scaleRed.Digits = 0;
			this.scaleRed.ValuePos = ((global::Gtk.PositionType)(2));
			this.vbox4.Add (this.scaleRed);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.scaleRed]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.scaleGreen = new global::Gtk.HScale (null);
			this.scaleGreen.CanFocus = true;
			this.scaleGreen.Name = "scaleGreen";
			this.scaleGreen.Adjustment.Upper = 100;
			this.scaleGreen.Adjustment.PageIncrement = 10;
			this.scaleGreen.Adjustment.StepIncrement = 1;
			this.scaleGreen.DrawValue = true;
			this.scaleGreen.Digits = 0;
			this.scaleGreen.ValuePos = ((global::Gtk.PositionType)(2));
			this.vbox4.Add (this.scaleGreen);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.scaleGreen]));
			w17.Position = 2;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.scaleBlue = new global::Gtk.HScale (null);
			this.scaleBlue.CanFocus = true;
			this.scaleBlue.Name = "scaleBlue";
			this.scaleBlue.Adjustment.Upper = 100;
			this.scaleBlue.Adjustment.PageIncrement = 10;
			this.scaleBlue.Adjustment.StepIncrement = 1;
			this.scaleBlue.DrawValue = true;
			this.scaleBlue.Digits = 0;
			this.scaleBlue.ValuePos = ((global::Gtk.PositionType)(2));
			this.vbox4.Add (this.scaleBlue);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.scaleBlue]));
			w18.Position = 3;
			w18.Expand = false;
			w18.Fill = false;
			this.hbox4.Add (this.vbox4);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.vbox4]));
			w19.Position = 1;
			this.vbox1.Add (this.hbox4);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox4]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbuttonbox1 = new global::Gtk.HButtonBox ();
			this.hbuttonbox1.Name = "hbuttonbox1";
			this.vbox1.Add (this.hbuttonbox1);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbuttonbox1]));
			w21.Position = 2;
			w21.Expand = false;
			w21.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			// Container child alignment1.Gtk.Container+ContainerChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.Xalign = 0F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Объектов в программе:");
			this.hbox7.Add (this.label8);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.label8]));
			w22.Position = 0;
			w22.Expand = false;
			w22.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.labelNum = new global::Gtk.Label ();
			this.labelNum.WidthRequest = 20;
			this.labelNum.Name = "labelNum";
			this.labelNum.Xalign = 1F;
			this.labelNum.LabelProp = global::Mono.Unix.Catalog.GetString ("0");
			this.hbox7.Add (this.labelNum);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.labelNum]));
			w23.Position = 1;
			this.alignment1.Add (this.hbox7);
			this.hbox6.Add (this.alignment1);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.alignment1]));
			w25.Position = 0;
			w25.Expand = false;
			w25.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.buttonClear = new global::Gtk.Button ();
			this.buttonClear.CanFocus = true;
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.UseUnderline = true;
			this.buttonClear.Label = global::Mono.Unix.Catalog.GetString ("Сброс");
			this.hbox6.Add (this.buttonClear);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.buttonClear]));
			w26.Position = 1;
			w26.Expand = false;
			w26.Fill = false;
			this.vbox1.Add (this.hbox6);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox6]));
			w27.PackType = ((global::Gtk.PackType)(1));
			w27.Position = 3;
			w27.Expand = false;
			w27.Fill = false;
			this.hbox1.Add (this.vbox1);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox1]));
			w28.Position = 3;
			w28.Expand = false;
			w28.Fill = false;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 852;
			this.DefaultHeight = 356;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.canvas.ExposeEvent += new global::Gtk.ExposeEventHandler (this.OnDrawingAreaExposed);
			this.canvas.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnDrawingAreaRelease);
			this.buttonClear.Clicked += new global::System.EventHandler (this.OnClearButtonClicked);
		}
	}
}
