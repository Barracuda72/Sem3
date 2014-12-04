using System;
using Gtk;
using System.Text;

public partial class MainWindow : Gtk.Window
{
	private static String NDS = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
	protected bool needClear;
	protected String CurOp;
	protected Double Operand;
	protected Double Memory;
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		needClear = true;
		button26.Label = NDS;
		CurOp = "";
		Operand = 0;
		label1.Text = "";
		Memory = 0;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected string getNumber()
	{
		return output.Text.ToString();
	}
	
	protected void putNumber(string s)
	{
		if (s == NDS)
			s = "0" + NDS;
		output.Text = s;
	}
	
	protected void addDigit(string c)
	{
		int q = Encoding.ASCII.GetBytes(c)[0];
		// Console.WriteLine("AddDigit {0}, {1}", c, q);
		if (needClear)
		{
			putNumber(c);
			needClear = false;
		} else if (getNumber().Length <= 25) {
			if (c == NDS)
			{	
      			if (!getNumber().Contains(NDS))
        			putNumber(getNumber()+NDS);
    		} else if ((q >= 0x30) && (q <= 0x39)) {
				if ((Convert.ToDouble(getNumber()) != 0) || (getNumber().Contains(NDS)))
					putNumber(String.Concat (getNumber(), c));
      			else
        			if (c != "0")
          				putNumber(c);
    		}
		}	
	}

	protected double calculate(double a1, string op, double a2)
	{
		switch (op) 
		{
			case "+":
				return a1 + a2;

			case "-":
				return a1 - a2;

			case "*":
				return a1 * a2;

			case "/":
				return a1 / a2;

			case "%":
				return a1 % a2;
		}
		return 0;
	}

	protected void chSign()
	{
		string s = getNumber();
		double n = double.Parse(s);
		n = -n;
		putNumber(n.ToString());
		needClear = true;
	}
	
	protected void clearOutput ()
	{
		needClear = true;
		putNumber("0");
	}
	
	protected void doBackspace()
	{
		int L = getNumber().Length;
		if (needClear || (L == 1))
		{
			putNumber("0");
		} else {
			putNumber(getNumber().Substring(0,L-1));
		}	
	}

	protected void OnNumberClicked (object sender, EventArgs e)
	{
		Gtk.Button b = (Gtk.Button)sender;
		addDigit(b.Label);
	}

	protected void OnButton25Clicked (object sender, EventArgs e)
	{
		chSign ();
	}

	protected void OnClearFieldClicked (object sender, EventArgs e)
	{
		clearOutput ();
		CurOp = "";
	}

	protected void OnBackspaceClicked (object sender, EventArgs e)
	{
		doBackspace ();
	}

	protected void OnCClicked (object sender, EventArgs e)
	{
		putNumber("0");
	}
	
	private void OperationClicked(String op)
	{
		if (CurOp != "")
		{
			try {
				Operand = calculate (Operand, CurOp, Convert.ToDouble(getNumber()));
			} catch (Exception e) {
				Operand = 0;
			}	
		} else {
			Operand = Convert.ToDouble(getNumber());
		}
		
		putNumber(Operand.ToString());
		CurOp = op;
		
		if (CurOp == "=")
			CurOp = "";
		
		needClear = true;
	}
	
	
	protected void OnOperationClicked (object sender, EventArgs e)
	{
		Gtk.Button b = (Gtk.Button)sender;
		OperationClicked(b.Label);
	}

	protected void OnMemClearClicked (object sender, EventArgs e)
	{
		label1.Text = "";
		Memory = 0;
	}

	protected void OnMemReadClicked (object sender, EventArgs e)
	{
		putNumber(Memory.ToString());
	}

	protected void OnMemSetClicked (object sender, EventArgs e)
	{
		label1.Text = "M";
		Memory = Convert.ToDouble(getNumber());
	}

	protected void OnMemAddClicked (object sender, EventArgs e)
	{
		label1.Text = "M";
		Memory += Convert.ToDouble(getNumber());
	}

	protected void OnButton38Clicked (object sender, EventArgs e)
	{
		Double res;
		try {
			res = Math.Sqrt(Convert.ToDouble(getNumber()));
		} catch (Exception ex) {
			res = 0;
		}
		putNumber(res.ToString());
	}

	protected void OnButton41Clicked (object sender, EventArgs e)
	{
		Double res;
		try {
			res = 1/Convert.ToDouble(getNumber());
		} catch (Exception ex) {
			res = 0;
		}
		putNumber(res.ToString());
	}
}

