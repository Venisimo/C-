//using System;
//static class Math
//{
//    public static int Square(int num)
//    {
//        return num * num;
//    }

//    public static int SPryamougol(int a, int b)
//    {
//        return a * b;
//    }

//    public static int PPryamougol(int a, int b)
//    {
//        return (a + b) * 2;
//    }

//    public static int VPryamougol(int a, int b, int h)
//    {
//        return (a * b * h);
//    }
//    public static double SCircle(int r)
//    {
//        return r * r * 3.14;
//    }
//}


//class HelloWorld
//{
//    static void Main()
//    {
//        Console.WriteLine(Math.Square(3));
//        Console.WriteLine(Math.SPryamougol(10, 20));
//        Console.WriteLine(Math.PPryamougol(10, 20));
//        Console.WriteLine(Math.VPryamougol(10, 20, 5));
//        Console.WriteLine(Math.SCircle(5));
//    }
//}



//using System;

//class Clients
//{
//    private string[] Names = new string[30];

//    public string this[int index]
//    {
//        get
//        {
//            return Names[index];
//        }
//        set
//        {
//            Names[index] = value;
//        }
//    }
//}
//class HelloWorld
//{
//    static void Main()
//    {
//        Clients Client = new Clients();
//        Client[0] = "fdsfs";
//        Console.WriteLine(Client[0]);
//    }
//}

//using System;

//class Box
//{
//    public int height { get; set; }
//    public int width { get; set; }

//    public Box(int h, int w)
//    {
//        height = h;
//        width = w;
//    }
//    public static Box operator +(Box a, Box b)
//    {
//        int h = a.height + b.height;
//        int w = a.width + b.width;
//        Box res = new Box(h, w);
//        return res;
//    }
//}

//public class HelloWorld
//{
//    static void Main()
//    {
//        Box o1 = new Box(6, 8);
//        Box o2 = new Box(10, 10);
//        Box o3 = o1 + o2;
//        Console.WriteLine("H: " + o3.height + " W: " + o3.width);
//    }
//}


using System;
class Animal
{
    public string TypeAnimal { get; set; }
    protected int Age { get; set; }

    public Animal()
    {
        Console.WriteLine("Const animal");
    }
    ~Animal()
    {
        Console.WriteLine("destruct animal");
    }
    public void MainVoice()
    {
        Console.WriteLine("Hello");
    }
}

class Dog : Animal
{
    public Dog()
    {
        Age = 20;
        Console.WriteLine("Const dog");
    }
    ~Dog()
    {
        Console.WriteLine("destruct dog");
    }
    public void Voice()
    {
        Console.WriteLine(Age);
    }
}

class HelloWorld
{
    static void Main()
    {
        Dog d1 = new Dog();
        //Console.WriteLine(d1.Age);
        //d1.Voice();
        //d1.MainVoice();
    }
}

//using System;
//class HelloWorld
//{
//    static void Main()
//    {
//        using System;
//class Animal
//    {
//        public string TypeAnimal { get; set; }
//        protected int Age { get; set; }
//        public void Dog()
//        {
//            Console.WriteLine("Woof");
//        }
//    }

//    class HelloWorld
//    {
//        static void Main()
//        {
//            Dog d1 = new Dog();
//            Console.WriteLine(d1.Dog);
//            d1.Dog();
//        }
//    }
