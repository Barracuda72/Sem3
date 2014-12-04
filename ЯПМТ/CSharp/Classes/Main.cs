using System;

namespace Classes
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello, World!");
			int i;
			Random rnd = new Random(34353545);
			LiveCreature[] a = new LiveCreature[10];
			for(i = 0; i < 10; i++)
			{
				switch (rnd.Next()%9)
				{
					case 0:
						a[i] = new Worm();
						break;
					case 1:
						a[i] = new Tree();
						break;
					case 2:
						a[i] = new Cat();
						break;
					case 3:
						a[i] = new Dog();
						break;
					case 4:
						a[i] = new Flower();
						break;
					case 5:
						a[i] = new LiveCreature();
						break;
					case 6:
						a[i] = new Animal();
						break;
					case 7:
						a[i] = new Plant();
						break;
					case 8:
						a[i] = new Hord();
						break;
				}
			}
			
			for(i = 0; i < 10; i++)
				a[i].Print();
		}
	}
	
	class LiveCreature
	{
		virtual public void Print()
    {
      Write("Я жив!");
    }
		protected void Write(string s)
		{
			Console.WriteLine(s);
		}
	}
	
	class Animal : LiveCreature
	{

	}
	
	class Plant : LiveCreature
	{

	}
	
	class Worm : Animal
	{
		public override void Print()
		{
			Write("I am a Worm!");
		}
	}
	
	class Hord : Animal
	{
		
	}
	
	class Tree : Plant
	{
		public override void Print()
		{
			Write("I am a Tree!");
		}
	}
	
	class Flower : Plant
	{
		public override void Print()
		{
			Write("I am a flower!");
		}
	}
	
	class Cat : Hord
	{
		public override void Print()
		{
			Write("I am a cat!");
		}
	}
	
	class Dog : Hord
	{
		public override void Print()
		{
			Write("I am a dog!");
		}
	}
}

