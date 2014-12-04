using System;

namespace MyStack
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Stack test");
			Stack myst = new Stack(-1);
			try {
          myst.Push(1);
      } catch (MyExcept e) {
          Console.WriteLine("!!!!");
      }
			
      int i;
			try
			{
				for (i = 0; i < 10; i++)
					myst.Push(i);
				Console.WriteLine("You will never see this message");
			} catch (MyExcept e) {
				Console.WriteLine(e.ToString());
			} try {
				for (i = 0; i < 10; i++)
					myst.Pop();
				Console.WriteLine("Second invisible message");
			} catch (MyExcept e) {
				Console.WriteLine(e.ToString());
			} finally {
				Console.WriteLine("All good");
			}
		}
	}
	
	class Stack
	{
		private int[] stck;
		private int in_stack;

		public Stack(int n)
		{
			if (n <= 0) 
      {
        stck = new int[0];
        return;
      }
			stck = new int[n];
			in_stack = n;
			Clear();
			in_stack = 0;
		}
		
		public void Clear()
		{
			for (; in_stack > 0; in_stack--) 
        stck[in_stack-1] = 0;
		}
		
		public int Pop()
		{
			if (in_stack == 0) 
        throw new StEmpty();	//Exception
			return stck[--in_stack];
		}
		
		public void Push(int a)
		{
			if (in_stack == stck.Length) 
        throw new StOver();	//Exception
			stck[in_stack++] = a;
		}
		
		public void Print()
		{
			int i;
			for (i = in_stack; i > 0; i--) 
        Console.WriteLine(i.ToString() + ": " + stck[i-1].ToString());
		}
		
		public int Top()
		{
			return in_stack;
		}
		
	}
	
	abstract class MyExcept : Exception
	{
		public MyExcept()
		{
			//Console.WriteLine(ToString());
			Console.WriteLine("AAAARRRGGGH!! EXCEPTION!!!");
		}
		
		public abstract override string ToString();
	}
	
	class StOver : MyExcept
	{
		public override string ToString()
		{
			return "Stack overflow exception!";
		}
	}
	
	class StEmpty : MyExcept
	{
		
		public override string ToString()
		{
			return "Stack empty exception!";
		}
	}
}

