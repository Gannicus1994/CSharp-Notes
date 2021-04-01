using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    #region 值类型、引用类型
    //对象在内存中的存储方式不同，被分为值类型、引用类型

    //a.非成员数据的存储
    //  1.值类型只需要一段单独的内存，用于存储实际的数据（存于栈）
    //  2.引用类型需要两段内存
    //      a.第一段存储实际数据，它总位于堆中
    //      b.第二段是一个引用，指向数据在堆中存放的位置

    //b.存储引用类型对象的成员
    //  1.引用类型的任何对象，它所有的数据成员无论值类型还是引用类型都存放在堆里



    /*值类型：
     * 预定义类型：sbyte 、byte、float、short、ushort、double、int、uint、char、long、ulong、decimal、bool
     * 用户定义类型：struct、enum
    */

    /*引用类型：
     * 预定义类型：object、string、dynamic
     * 用户定义类型：class、interface、delegate、array
     */
    #endregion


    #region 值参数、引用参数、输出参数、参数数组、方法重载、命名参数、可选参数、栈帧
    //1.值参数：
    //  a.在栈中卫形参分配空间
    //  b.通过将实参的值复制到形参的方式把数据传递给方法
    //  c.实参不一定是变量，它可以是任何能计算成相应数据类型的表达式
    //  d.在把变量用作实参前，必须赋值（除非是输出参数，对于引用类型的变量，可被设置为一个实际的引用或null）

    //2.引用参数：
    //  a.使用引用参数，必须再方法的声明和调用时都使用ref修饰符
    //  b.引用参数的行为就像是将实参作为形参的别名，在方法调用时，形参和实参都指向堆中相同的对象
    //  c.实参必须是变量，不能是其他类型表达式，在用作实参前必须被赋值。如果是引用类型变量，可以赋值为一个引用或null
    //  d.当创建新的对象并赋值给形参时，形参和实参的引用都指向该新对象

    //3.输出参数
    //  a.使用输出参数，必须再方法的声明和调用时都使用out修饰符
    //  b.实参必须是变量，不能是其他类型表达式，因为方法需要内存位置保存返回值
    //  c.输出参数在读取之前必须赋值，在方法返回之前，方法内部贯穿的任何路径都必须为所有的输出参数进行一次赋值

    //4.参数数组
    //  a.数据类型前使用params修饰符，数据类型后放置一组空括号,调用时无需修饰符
    //  b.在一个参数列表中只能有一个参数数组，若有其他参数，参数数组必须是最后一个
    //  c.参数数组中所有参数都必须是相同类型
    //  d.数组是一个引用类型，所有数据都保存在堆里
    //  e.void ListInts( params int[] inVals)

    //5.方法重载
    //  a.一个类中可以拥有一个以上的方法拥有相同的名称     
    //  b.每个方法和其他方法要有一个不同的签名（方法名称、参数的数目、参数的数据类型和顺序、参数修饰符）
    //  c.返回类型和形参的名称不是签名的一部分

    //6.命名参数
    //  a.显示指定参数的名字，就可以用任意顺序在方法调用中列出实参

    //7.可选参数
    //  a.在方法声明的时候为参数提供默认值
    //  b.必须从可选参数的最后开始省略，一直到参数列表的开头
    //  c.可设置可选参数的两种情况：1.值类型、值参数    2.引用类型、值参数（允许null的默认值）
    //  d.参数设置顺序：必填参数    可选参数    params参数

    //8.栈帧
    //  a.调用方法的时候，内存从栈的顶部开始分配，保存和方法关联的数据项
    //  b.栈帧包含的内存内容：返回地址（方法退出时继续执行的位置）、参数分配的内存（方法的值参数、参数数组）、和方法调用相关的其他管理数据项
    class MyClass
    {
        public int Val = 20;

        public void ListInts(params int[] inVals)
        {
            if ((inVals != null) && (inVals.Length != 0))
            {
                for (int i = 0; i < inVals.Length; i++)
                {
                    inVals[i] = inVals[i] * 10;
                    Console.WriteLine("class4{0}", inVals[i]);
                }
            }
        }
    }
    class ValueProgram
    {

        void MyMethodValue(MyClass f1, int f2)
        {
            f1.Val = f1.Val + 5;
            f2 = f2 + 5;
            Console.WriteLine("class1.val:{0},f2:{1}", f1.Val, f2);
        }

        void MyMethodRef(ref MyClass f1, ref int f2)
        {
            f1.Val = f1.Val + 5;
            f2 = f2 + 5;
            Console.WriteLine("class2.Val:{0},f2:{1}", f1.Val, f2);
        }

        void MyMethodOut(out MyClass f1, out int f2)
        {
            f1 = new MyClass();
            f1.Val = 25;
            f2 = 15;
            Console.WriteLine("class3.Val:{0},f2:{1}", f1.Val, f2);
        }


        void Main()
        {
            //值参数
            MyClass class1 = new MyClass();
            int num1 = 10;
            MyMethodValue(class1, num1);
            Console.WriteLine("class1.Val:{0},f2:{1}", class1.Val, num1);

            //引用参数
            MyClass class2 = new MyClass();
            int num2 = 10;
            MyMethodRef(ref class2, ref num2);
            Console.WriteLine("class2.Val:{0},f2:{1}", class2.Val, num2);

            //输出参数
            MyClass class3 = null;
            int num3;
            MyMethodOut(out class3, out num3);
            Console.WriteLine("class3.Val:{0},f2:{1}", class3.Val, num3);

            //参数数组
            int first = 5, second = 6, third = 7;
            MyClass class4 = new MyClass();
            class4.ListInts(first, second, third);
            Console.WriteLine("class4:{0},{1},{2}", first, second, third);

            int[] intArray = { 1, 2, 3 };
            class4.ListInts(intArray);
        }
    }
    //class1.val:25,f2:15
    //class1.val:25,f2:10

    //class2.val:25,f2:15
    //class2.val:25,f2:15

    #endregion


    #region 字段、属性、成员常量、静态字段、静态函数
    /// <summary>
    /// 字段、属性
    /// </summary>
    public class TestProperty
    {
        //属性：
        //a.它有类型
        //b.它可以被赋值和读取set、get
        //c.它是一个函数成员
        //d.它不为数据存储分配内存，它执行代码
        //e.属性内部只能有get set方法,两个访问器至少有一个被定义
        //f.可以只读或只写，字段不行
        public const int value = 0;
        private int hourValue;//属性的后备字段：会分配内存
        public int HourValue
        {
            //set访问器：拥有一个单独的、隐式的值参，名称为value，与属性的类型相同，不能显示被调用
            set
            {
                hourValue = value > 24 ? 24 : value;
            }
            //get访问器：没有参数，拥有一个和属性类型相同的返回类型，不能显示被调用
            //访问器的访问级别 修饰
            private get
            {
                return hourValue;
            }
        }

        //实例构造函数
        public TestProperty(double getA = 3, double getB = 4)
        {
            A = getA;
            B = getB;
        }
        public double A;
        public double B;

        //属性不设置后备字段，只设置只读属性
        public double Hypotenuse
        {
            get { return Math.Sqrt((A * A) + (B * B)); }
        }

        //自动实现属性
        public double Hypotenuse2
        {
            set; get;
        }

        //静态属性
        //a.能被实例成员访问，不能访问类的实例成员
        //b.不管类是否有实例，它都存在
        //c.从类的外部访问时，必须使用类名引用，而不是实例名
        public static double MyStaticValue { set; get; }

        //成员常量：对每个类的实例都可见，不能被声明为static，没有自己的存储位置，在编译时被编辑器替换相当于c++中的define
        public const double PI = 3.1415926;
        public static int Item1 = 123;          //静态字段

        //静态函数
        public static void AddItem1()
        {
            //静态函数可以访问静态成员，不能访问实例成员
            Item1++;
        }
    }

    class ValueProgramMain
    {
        void Main()
        {
            //类的外部访问属性
            TestProperty testProperty = new TestProperty(4, 5);
            Console.WriteLine("Hypotenuse:{0}", testProperty.Hypotenuse);

            //从类的外部访问静态属性
            TestProperty.MyStaticValue = 10;

            //成员常量的调用
            double getPI = TestProperty.PI + 1;

            //静态字段成员的调用
            TestProperty.Item1++;

            //静态函数成员的调用
            TestProperty.AddItem1();
        }
    }

    #endregion


    #region 表达式和运算符

    //求余运算符
    //0 % 3 = 0   0除以3得0余0
    //1 % 3 = 1   1除以3得0余1
    //2 % 3 = 2   2除以3得0余2
    //3 % 3 = 0   3除以3得1余0
    //4 % 3 = 1   4除以3得1余1


    //浅比较：
    //1.如果引用相等，也就是说如果它们指向内存中相同对象，那么相等性比较为true，否则为false
    //2.引用不相同，即使是两个对象内容完全相等，也为false

    //深比较：
    //1.string类型对象也是引用类型，比较方式不同，比较字符串相等性比较的是长度和内容
    //2.string类型，如果两个字符串的长度、内容（区分大小写）相同，即便占用不同的内存区域那也为true
    //3.委托比较，如果两个委托都是null，或两者的调用列表中有相同数目的成员，列表匹配，那么为true
    //4.enum比较，比较操作数的实际值


    //递增运算符  递减运算符
    //int x = 5, y;
    //y = x++;    //result: y:5、  x:6

    //int a = 5, b;
    //b = ++a;    //result: b:6、  a:6


    //条件逻辑运算符
    //  && 与    两个操作数都是true，结果为true    
    //  || 或    所有操作数中其中至少有一个为true，结果为true     
    //   ！非    操作数为false，结果为true，否则为false


    //逻辑运算符
    //   &  位与      产生两个操作数的按位与，仅当两个操作位都为1时，结果位才是1
    //   |  位或      产生两个操作数的按位或，只要一个操作数为1，结果位就是1
    //   ^  位异或    产生两个操作数的按位异或，仅当一个而不是两个操作数为1时，结果位为1
    //   ~  位非      操作数的每个位都取反，该操作得到的操作数的二进制反码（数字的反码是其二进制的形式按位取反的结果，也就是说，每个0都变成1，每个1都变成0）


    //移位运算符
    //  14 << 3 = 112   14左移3个位置
    //  14 >> 3 = 1     14右移3个位置


    //用户定义的类型转换
    class LimitedInt
    {
        //隐式转换  关键字implicit
        //public 和 static修饰符是必须的

        public int TheValue { get; private set; }

        //将LimitedInt类型转换为int型
        public static implicit operator int(LimitedInt li)
        {
            return li.TheValue;
        }
        //将LimitedInt类型转换为int型
        public static implicit operator LimitedInt(int x)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = x;
            return li;
        }


        //显式转换 关键字explicit
        public float TheValue2 { get; private set; }

        //将LimitedInt类型转换为int型
        public static explicit operator float(LimitedInt li)
        {
            return li.TheValue2;
        }
        //将LimitedInt类型转换为int型
        public static explicit operator LimitedInt(float x)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue2 = x;
            return li;
        }
        static void Main()
        {
            //隐式转换
            LimitedInt li = 500;        //将500转换为LimitedInt
            int value = li;             //将LimitedInt转换为int

            //显式转换
            LimitedInt li2 = (LimitedInt)500f;       //将500转换为LimitedInt
            float value2 = (float)li2;               //将LimitedInt转换为int
        }
    }

    //运算符重载
    //只能用于类和结构
    //为类或结构重载一个运算符x，可以声明一个名称为operator x的方法并实现他的行为
    //一元运算符的重载方法带一个单独的class或者struct类型的参数
    //二元运算符的重载方法带两个参数，其中至少一个必须是class或struct类型
    //可重载的一元运算符：+、-、！、~、++、--、true、false
    //可重载的二元运算符：+、-、*、/、%、&、|、^、<<、>>、==、!=、>、<、>=、<=
    class LimitedInt2
    {
        public int TheValue { get; private set; }

        //加运算符
        public static LimitedInt2 operator +(LimitedInt2 x, double y)
        {
            LimitedInt2 li = new LimitedInt2();
            li.TheValue = x.TheValue + (int)y;
            return li;
        }

        //一元运算符 减运算符，你可以说它是负数而不是减法，因为运算符的方法只有一个单独的参数，因此是一元的，而减法运算符是二元的
        public static LimitedInt2 operator -(LimitedInt2 x)
        {
            //在这个类中取一个值的负数，会让这个值等于0
            LimitedInt2 li = new LimitedInt2();
            li.TheValue = 0;
            return li;
        }

        //二元运算符  减运算符
        public static LimitedInt2 operator -(LimitedInt2 x, LimitedInt2 y)
        {
            LimitedInt2 li = new LimitedInt2();
            li.TheValue = x.TheValue - y.TheValue;
            return li;
        }

        static void Main()
        {
            LimitedInt2 li1 = new LimitedInt2();
            li1.TheValue = 10;
            LimitedInt2 li2 = new LimitedInt2();
            li2.TheValue = 26;
            LimitedInt2 li3 = new LimitedInt2();
            li3 = -li1;         //0
            li3 = li2 - li1;    //16
        }
    }



    //typeof运算符
    //返回作为其参数的任何类型的system.type对象
    // Type t = typeof(SomeClass);

    class SomeClass
    {
        public int Field1;
        public int Field2;

        public void Method1() { }
        public int Method2() { return 1; }
    }

    class TypeOfProgram
    {
        static void Main()
        {
            Type t = typeof(SomeClass);
            FieldInfo[] fi = t.GetFields();
            MethodInfo[] mi = t.GetMethods();

            foreach (FieldInfo f in fi)
                Console.WriteLine("Fielf:{0}", f.Name);

            foreach (MethodInfo f in mi)
                Console.WriteLine("Method:{0}", f.Name);
        }
    }

    #endregion


     #region 类
    //private       类的内部可访问
    //internal      程序集内所有类可访问
    //protected     对所有继承该类的类可访问
    //protected internal    对所有继承该类或在该程序集内声明的类可访问
    //public        任何类都可访问


    //抽象类
    //被设计为被继承的类，抽象类只能被用作其他类的基类
    //1.不能创建抽象类的实例
    //2.可以包含抽象成员或普通的非抽象成员。抽象类的成员可以使抽象成员和普通带实现的成员的任意组合
    //3.抽象类可以自己派生自另一个抽象类
    //4.任何派生自抽象类的类必须使用override关键字实现该类的所有的抽象成员，除非派生类自己也是抽象类
    //abstract class MyClass;

    //抽象成员
    //被设计为被覆写的函数成员
    //1.必须是一个函数成员（字段和常量不能为抽象成员）
    //2.必须用abstract修饰符
    //3.不能有实现代码块,用分号表示
    //4.在派生类中，必须被覆写使用override
    //abstract public void PrintStuff(string s);
    //abstract public int Myproperty{get; set;}

    //抽象类
    abstract class AbsClass
    {
        public int SideLength = 10; //数据成员
        abstract public void IdentifyDerived();//抽象方法
        abstract public int MyInt { get; set; }//抽象属性

        //普通方法
        public void IdentifyBase()
        {
            Console.WriteLine("AbsClass");
        }
    }

    //派生类
    class DerivedClass : AbsClass
    {
        //覆盖抽象属性
        private int _myInt;
        public override int MyInt
        {
            get { return _myInt; }
            set { _myInt = value; }
        }

        //抽象方法的实现
        public override void IdentifyDerived()
        {
            Console.WriteLine("DerivedClass");
        }
    }

    class AbsProgram
    {
        static void main()
        {
            //AbsClass a = new AbsClass();//错误，抽象类不能实例化

            DerivedClass b = new DerivedClass();
            b.IdentifyBase();       //调用继承的方法
            b.IdentifyDerived();    //调用抽象方法
            b.MyInt = 28;
        }
    }


    //密封类
    //只能用作独立的类，不能被用作基类
    //sealed修饰符

    //静态类
    //所有的成员都是静态，用来存放不受实例数据影响的数据和函数

    //扩展方法
    //1.声明扩展方法的类必须为static
    //2.扩展方法本身必须是static
    //3.扩展方法必须包含关键字this作为它的第一个参数类型，并在后面跟着它所扩展的类的名称
    class MyData
    {
        private double D1, D2, D3;

        public MyData(double d1, double D2, double D3)
        {
            D1 = d1;
            this.D2 = D2;
            this.D3 = D3;
        }

        public double Sum()
        {
            return D1 + D2 + D3;
        }
    }

    //声明扩展方法的类
    static class ExtendMyData
    {
        public static double Average(MyData md)
        {
            return md.Sum() / 3;
        }

        //扩展方法
        public static double Average2(this MyData md)
        {
            return md.Sum() / 3;
        }
    }

    class ExtendProgram
    {
        static void main()
        {
            MyData md = new MyData(3, 4, 5);
            ExtendMyData.Average(md);

            //扩展方法的调用
            md.Average2();
        }
    }


    public class TestClass
    {
        public double A;
        public double B;
        public static Random randomKey;

        //readonly修饰符，类似于成员常量const，一旦值被设定就不能改变
        //1.const只能在字段声明语句中初始化，readonly可在字段声明语句中、类的所有构造函数，如果是static字段，初始化必须静态构造函数中完成
        //2.const字段的值必须在编译时决定，而readonly字段的值可以再运行时决定这种增加的自由性允许你在不同的环境或不同的构造函数中设置不同的值
        //3.const的行为总是静态的，readonly可以是实例字段，也可以是静态字段，它在内存中有存储位置
        readonly double PI = 3.1415;
        readonly double NumberOfSide1;
        readonly double NumberOfSide2;


        //声明索引器
        //1.只要索引器的参数列表不同（参数类型、参数数量），一个类可以有任意多个索引器
        //2.只有索引器的类型不同是不够的
        public string LastName;
        public string FirstName;
        public string CityOfBirth;

        public string this[int index]
        {
            set
            {
                switch (index)
                {
                    case 0: LastName = value; break;
                    case 1: FirstName = value; break;
                    case 2: CityOfBirth = value; break;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
            get
            {
                switch (index)
                {
                    case 0: return LastName;
                    case 1: return FirstName;
                    case 2: return CityOfBirth;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
        }

        //构造函数 
        private TestClass()
        {
            NumberOfSide1 = 53;
        }

        //
        public TestClass(int value) : this()
        {
            NumberOfSide2 = value;
        }

        //带参数的构造函数
        // a.如果你为类声明了任何构造函数，那么编译器将不会为该类定义默认的构造函数
        public TestClass(double A = 3, double B = 4)
        {
            //this 关键字
            //1.被用在 实例构造函数、实例方法、属性和索引器的实例访问器中
            //2.用于区分类的成员和本地变量或参数
            //3.作为调用方法的实参
            this.A = A;
            this.B = B;
        }

        //静态构造函数
        //1.初始化类级别的项
        //2.在引用任何静态成员之前
        //3.在创造类的任何实例之前
        //4.通常类的静态构造函数初始化类的静态字段
        static TestClass()
        {
            randomKey = new Random();
        }

        public int GetRandomNumber()
        {
            return randomKey.Next();
        }

    }

    class ClassProgramMain
    {
        void Main()
        {
            //对象初始化语句                    //成员初始化语句，会覆盖构造函数中的赋值
            TestClass testClass = new TestClass { A = 2, B = 3 };

            //索引器调用
            testClass[0] = "Park";
            testClass[1] = "Peter";
            testClass[2] = "NewNork";
        }
    }


    #endregion


    #region 结构

    //结构：
    //1.有数据成员和函数成员，与类相似,区别是，类是引用类型而结构是值类型
    //2.结构是隐式密封的，不能被派生
    //3.结构类型的变量不能为null
    //4.两个结构不能引用同一个对象
    //5.结构可以有构造函数和静态构造函数，但是不允许有析构函数
    //6.结构中不允许初始化字段
    //7.结构作为返回值时，减创建它的副本并从函数成员返回
    //8.结构用作值参数时，将创建实参结构的副本
    //9.结构用作ref和out参数，传入方法的是结构的引用，这样就可以修改其数据成员

    class ClassSimple
    {
        public int X;
        public int Y;
    }

    struct StructSimple
    {
        public int X;
        public int Y;

        //public int x = 12;  //错误  结构中不允许初始化字段
        //public int y = 30;

        public StructSimple(int a, int b)
        {
            X = a;
            Y = b;
        }
    }

    class StructProgram
    {
        static void Main()
        {
            ClassSimple cs1 = new ClassSimple(), cs2 = null;//类实例
            StructSimple ss1 = new StructSimple(), ss2 = new StructSimple();//结构实例
            cs1.X = ss1.X = 5;
            cs1.Y = ss1.Y = 10;

            cs2 = cs1;//赋值给类实例
            ss2 = ss1;//赋值给结构实例

            //不使用new运算符创建结构的实例
            //在显示设置数据成员后，才能使用它们的值
            //在对所有数据成员赋值之后，才能调用任何函数成员
            StructSimple ss3;
            //Console.WriteLine("{0},{1}", ss3.X, ss3.Y);//编辑错误，还未被赋值
            ss3.X = 5;
            ss3.Y = 10;
            Console.WriteLine("{0},{1}", ss3.X, ss3.Y);//正确
        }
    }
    #endregion


    #region 数组
    //元素、数组的独立数据项
    //维度、数组有任何为正数的维度数
    //维度长度、数组每一个维度都有长度，就是这个方向的位置个数
    //数组长度、数组所有维度的元素总和

    //1.数组声明后，维度数是固定的了，维度长度知道数组实例化时才会确定
    //2.数组存储的元素都是值类型。值类型数组
    //3.数组存储的元素都是引用类型对象，引用型数组
    class ArrayClass
    {
        static void Main()
        {
            int[] intArr1 = new int[15];    //声明一个一维数组
            intArr1[2] = 10;                //向第三个元素写入值
            int var1 = intArr1[2];          //从第二个元素中读取值

            int[,,] intArr2 = new int[2, 3, 6];    //声明一个三维数组

            int[] intArr3 = new int[] { 10, 20, 30, 40 };    //显式初始化一维数组

            int[,] intArr4 = new int[,] { { 1, 2, }, { 3, 4 }, { 5, 6 } }; //显式初始化二维数组
            int[,] intArr5 = { { 1, 2, }, { 3, 4 }, { 5, 6 } };        //快捷语法 显式初始化二维数组

            //交错数组:数组的数组
            //不能声明语句中初始化顶层数组之外的数组
            int[][] Arr1 = new int[3][];         //实例化顶层数组
            Arr1[0] = new int[] { 10, 20, 30 };  //实例化子数组
            Arr1[1] = new int[] { 40, 50, 60 };  //实例化子数组
            Arr1[2] = new int[] { 70, 80, 90 };  //实例化子数组

            //带有三个二维数组的交错数组
            int[][,] Arr2 = new int[3][,];         //实例化顶层数组
            Arr2[0] = new int[,] { { 10, 20, 30 }, { 100, 200, 300 } };  //实例化子数组
            Arr2[1] = new int[,] { { 40, 50, 60 }, { 400, 500, 600 } };  //实例化子数组
            Arr2[2] = new int[,] { { 70, 80, 90 }, { 700, 800, 900 } };  //实例化子数组

            for (int i = 0; i < Arr2.GetLength(0); i++)
            {
                for (int j = 0; j < Arr2[i].GetLength(0); j++)
                {
                    for (int k = 0; k < Arr2[i].GetLength(1); k++)
                    {
                        Console.WriteLine("[{0},{1},{2}] = {3}", i, j, k, Arr2[i][j, k]);
                    }
                }
            }

            foreach (int[,] array in Arr2)
            {
                Console.WriteLine("start new array");
                foreach (int item in array)
                {
                    Console.WriteLine("Item:{0}", item);
                }
            }
        }
    }

    //数组协变
    //1.某个对象不是数组额基类型也可以把它赋值给数组元素
    //2.数组是引用类型数组
    //3.在赋值的对象类型和数组基类型之间有隐式转换或显示转换
    //4.值类型数组没有协变   

    //clone方法
    //1.克隆值类型数组会产生两个独立数组
    //2.克隆引用类型数组会产生指向相同对象的两个数组




    #endregion


    #region  排序
    static class ProgramSort
    {
        //冒泡排序(小 -> 大)
        public static void BubbleSort(int[] data)
        {
            //0      1      2    3 
            //123    23     3    
            for (var i = 0; i < data.Length - 1; i++)
            {
                for (var j = i + 1; j < data.Length; j++)
                {
                    if (data[i] > data[j])
                    {
                        var temp = data[i];
                        data[i] = data[j];
                        data[j] = temp;
                    }
                }
            }
        }

        //选择排序
        public static void ChooseSort(int[] data)
        {
            for (var i = 0; i < data.Length - 1; i++)
            {
                var minIndex = i;
                for (var j = i + 1; j < data.Length; j++)
                {
                    if (data[minIndex] > data[j])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    var temp = data[i];
                    data[i] = data[minIndex];
                    data[minIndex] = temp;
                }
            }
        }
    }
    #endregion


    #region  委托

    /*
     * 委托：是持有一个或多个方法的对象,正常情况下你不想“执行”一个对象，
     * 但委托与典型对象不同。可以执行委托，这时委托会执行它所“持有”的方法。
     * 委托和类一样，是用户自定义类型。但类表示的是数据和方法的集合，
     * 而委托持有一个或多个方法，以及一系列预定义操作。 
    */

    //1.委托是一个包含有序方法列表的对象，这些方法具有相同的签名和返回类型
    //2.方法的列表称为调用列表
    //3.委托保存的方法可以来自任何类和结构，只要委托的返回类型、委托的签名（包括ref和out修饰符）匹配
    //4.调用列表中的方法可以使实例方法或者静态方法
    //5.调用委托时，会执行列表中所有方法

    //1.为委托添加方法， +=运算符
    //2.从委托移除方法， -= 运算符从列表最后开始搜索，并移除第一个与方法匹配的实例
    //3.试图调用空委托会发生异常
    //4.试图删除委托中不存在的方法没有效果

    /// <summary>
    /// 委托示例1
    /// </summary>
    /// <param name="value"></param>
    //关键字  返回类型 委托类型名   签名
    delegate void MyDel(int value);//声明委托类型
    delegate double MyDe2(int value);//声明委托类型（Lambda 表达式）

    class ProgramDelegate
    {
        void PrintLow(int value)
        {
            Console.WriteLine("{0} - Low Value", value);
        }
        void PrintHigh(int value)
        {
            Console.WriteLine("{0} - High Value", value);
        }
        static void Main()
        {
            ProgramDelegate program = new ProgramDelegate();
            MyDel del;      //声明委托变量
            var rand = new Random();
            var randomValue = rand.Next(99);
            //创建一个包含PrintLow、PrintHigh的委托对象，并将其赋值给del变量
            del = randomValue < 50 ? new MyDel(program.PrintLow) : new MyDel(program.PrintHigh);
            del(randomValue);   //执行委托


            //匿名方法  
            MyDe2 myde2 = delegate (int x) { return x + 1; };
            //Lambda表达式完整示例
            MyDe2 le1 = (int x) => { return x + 1; };
            MyDe2 le2 = (x) => { return x + 1; };
            MyDe2 le3 = x => { return x + 1; };
            MyDe2 le4 = x => x + 1;
            Console.WriteLine("{0}", myde2(12));
            Console.WriteLine("{0}", le1(12));
            Console.WriteLine("{0}", le2(12));
            Console.WriteLine("{0}", le3(12));
            Console.WriteLine("{0}", le4(12));
        }
    }


    /// <summary>
    /// 委托示例2
    /// </summary>
    delegate void PrintFunction();
    class Testelegate
    {
        public void Print1()
        {
            Console.WriteLine("Print1 -- instance");
        }
        public static void Print2()
        {
            Console.WriteLine("Print2 -- static");
        }
    }
    class Program
    {
        static void Main()
        {
            var t = new Testelegate();
            PrintFunction pf;
            pf = t.Print1;
            pf += Testelegate.Print2;
            pf += t.Print1;
            pf += Testelegate.Print2;
            pf -= Testelegate.Print2;//从委托移除方法

            if (null != pf)
            {
                pf();
            }
            else
            {
                Console.WriteLine("Delegate is empty");
            }
        }
    }
    //Print1 -- instance
    //Print2 -- static
    //Print1 -- instance
    //Print2 -- static


    /// <summary>
    /// 委托示例3  调用带返回值的委托
    /// </summary>
    /// <returns></returns>
    /// 1.调用列表中最后一个返回的值就是委托调用返回的值
    /// 2.调用列表中所有其他方法的返回值都会被忽略
    delegate int MyDel3();
    class MyDelClass
    {

        int IntValue = 5;
        public int Add1()
        {
            IntValue += 2;
            return IntValue;
        }

        public int Add2()
        {
            IntValue += 3;
            return IntValue;
        }
    }

    class ProgramDelegate2
    {
        static void Main()
        {
            var mc = new MyDelClass();
            MyDel3 mDel = mc.Add1;
            mDel += mc.Add2;
            mDel += mc.Add1;
            Console.WriteLine("Value: {0}", mDel());
        }
    }
    //Value：12



    /// <summary>
    /// 委托示例4 调用带引用参数的委托
    /// </summary>
    /// <param name="x"></param>
    delegate void MyDel4(ref int x);
    class MyDelClass2
    {
        public void Add1(ref int x)
        {
            x += 2;
        }

        public void Add2(ref int x)
        {
            x += 3;
        }
        static void Main()
        {
            var mc = new MyDelClass2();
            MyDel4 mDel = mc.Add1;
            mDel += mc.Add2;
            mDel += mc.Add1;

            int x = 5;
            mDel(ref x);
            Console.WriteLine("Value: {0}", x);
        }
    }
    // Value：12

    #endregion


    #region  事件

    /*
     * 事件：和方法、属性一样，事件是类或结构的成员，这一点引出几个重要特性。
     * 由于事件是成员：
     *      我们不能在一段可执行代码中声明事件，它必须声明在类或结构中。
     *      事件成员被隐式自动初始化为null
     */

    /// <summary>
    /// 事件示例1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    // delegate：关键字     void：委托类型     EventHandler：事件名
    public delegate void EventHandler(object sender, EventArgs e);
    //发布者：发布某个事件的类或结构，其他类可以在该事件发生时得到通知
    class Incrementer
    {
        public event EventHandler event1, event2, event3;   //使用逗号分隔同时声明多个事件
        public static event EventHandler event4;            //使用static关键字让事件变成静态

        //     关键字   委托类型      事件名
        //      ↓        ↓           ↓
        public event EventHandler CountedADozen;            //创建事件并发布
        public void DoCount()
        {
            for (int i = 1; i < 100; i++)
            {
                if ((i % 12 == 0) && (CountedADozen != null))
                {
                    CountedADozen(this, null);
                }
            }
        }
    }
    //订阅者：注册并在事件发生时得到通知的类或结构
    class Dozens
    {
        public int DozensCount { get; private set; }
        public Dozens(Incrementer incrementer)
        {
            DozensCount = 0;
            incrementer.CountedADozen += IncrementDozensCount;//订阅事件
        }
        void IncrementDozensCount(object source, EventArgs e)//声明事件处理程序
        {
            DozensCount++;
        }
    }
    class ProgramEvent
    {
        static void Main()
        {
            var incrementer = new Incrementer();
            var dozensCounter = new Dozens(incrementer);
            incrementer.DoCount();
            Console.WriteLine("Number of dozens = {0}", dozensCounter.DozensCount);
        }
    }



    /// <summary>
    /// 事件示例2
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public class IncrementerEventArgs : EventArgs
    {
        public int IterationCount { get; set; }
    }
    //发布者
    class Incrementer2
    {
        //使用自定义类的泛型委托    
        public event EventHandler<IncrementerEventArgs> CountedADozen;//创建事件并发布
        public void DoCount()
        {
            IncrementerEventArgs args = new IncrementerEventArgs();
            for (int i = 1; i < 100; i++)
            {
                if ((i % 12 == 0) && (CountedADozen != null))
                {
                    args.IterationCount = i;
                    CountedADozen(this, args);
                }
            }
        }
    }
    //订阅者
    class Dozens2
    {
        public int DozensCount { get; private set; }
        public Dozens2(Incrementer2 incrementer)
        {
            DozensCount = 0;
            incrementer.CountedADozen += IncrementDozensCount;//订阅事件
        }
        void IncrementDozensCount(object source, IncrementerEventArgs e)//声明事件处理程序
        {
            Console.WriteLine("Incremented at iteration: {0} in {1}", e.IterationCount, source.ToString());
            DozensCount++;
        }
    }
    class Program2
    {
        static void Main()
        {
            var incrementer = new Incrementer2();
            var dozensCounter = new Dozens2(incrementer);
            incrementer.DoCount();
            Console.WriteLine("Number of dozens = {0}", dozensCounter.DozensCount);
        }
    }

    #endregion


    #region 接口
    /*
     * 是指定一组函数成员而不实现它们的引用类型。所以只能类和结构来实现接口。
     *      1.声明接口：
     *          接口声明 不能 包含数据成员、静态成员
     *          接口声明 只能 包含如下类型的非静态成员函数的声明：方法、属性、事件、索引器
     *          接口声明可以有任何的访问修饰符public、protected、internal、private         
     *          接口的成员不能实现任何代码，只能用分号
     *          接口的成员是隐式public,不允许有任何访问修饰符，包括public
     *          
     *          接口允许访问修饰符
                   ↓
                public interface IMyInterface2
                {
                    private int Method1(int nVar1); //错误，接口成员不允许访问修饰符
                }
     *          
     *      2.实现接口：
     *          在基类列表中包括接口名称
     *          如果类实现了接口，它必须实现接口的所有成员
     *          如果类从基类继承并实现了接口，基类列表中的基类名称必须放在所有接口之前
     *          
     *                  基类必须放在最前面       接口名
                                ↓                 ↓
                class Derived:MyBaseClass,IIfc1,IEnumerable,IComparable
     */

    /// <summary>
    /// 接口示例1
    /// </summary>
    interface IInfo       //声明接口
    {
        string GetName();
        string GetAge();
    }
    class CA : IInfo         //声明了实现接口的CA类
    {
        public string Name;
        public int Age;
        public string GetName() { return Name; }
        public string GetAge() { return Age.ToString(); }
    }
    class CB : IInfo         //声明了实现接口的CB类
    {
        public string First;
        public string Last;
        public double PersonsAge;
        public string GetName() { return First + "" + Last; }
        public string GetAge() { return PersonsAge.ToString(); }
    }
    class ProgramInterface
    {
        static void PrintInfo(IInfo item)
        {
            Console.WriteLine("Name: {0},Age {1}", item.GetName(), item.GetAge());
        }
        static void Main()
        {
            var a = new CA() { Name = "John Doe", Age = 35 };
            var b = new CB() { First = "Jane", Last = "Doe", PersonsAge = 33 };
            PrintInfo(a);
            PrintInfo(b);
        }
    }


    /// <summary>
    /// 接口示例2 
    /// </summary>
    class MyInterFace : IComparable
    {
        public int TheValue;
        public int CompareTo(object obj)
        {
            var mc = (MyInterFace)obj;
            if (this.TheValue < mc.TheValue)
                return -1;
            if (this.TheValue > mc.TheValue)
                return 1;
            return 0;
        }
    }

    class ProgramInterFace
    {
        static void PrintOut(string str, MyInterFace[] mc)
        {
            Console.WriteLine(str);
            foreach (var m in mc)
            {
                Console.WriteLine("{0}", m.TheValue);
            }
            Console.WriteLine("");
        }

        static void main()
        {
            var myInt = new[] { 20, 4, 16, 9, 2 };
            var mcArr = new MyInterFace[5];
            for (var i = 0; i < 5; i++)
            {
                mcArr[i] = new MyInterFace();
                mcArr[i].TheValue = myInt[i];
            }
            PrintOut("Initial Order: ", mcArr);
            Array.Sort(mcArr);
            PrintOut("Sorted Order: ", mcArr);
        }
    }


    /// <summary>
    /// 接口示例3 
    /// </summary>

    /*
     * 1.不能直接通过类对象的成员访问接口，可以将类对象引用强制转换为接口类型来获取指向接口的引用，
     * 有了接口引用可以使用点号来调用接口方法
     * 
     * 2.如果一个类实现了多接口，并且其中有些接口有相同签名和返回类型，
     * 那么类可以实现单个成员来满足所有包含重复成员的接口。 
     */

    interface IIfc1
    {
        void PrintOut(string str);
    }

    interface IIfc2
    {
        void PrintOut(string str);
    }

    //接口可以继承接口
    interface IIfc3 : IIfc1, IIfc2
    {

    }



    //实现具有重复成员的接口时，实现单个接口来满足所有包含重复成员的接口
    class MyInterFace2 : IIfc1, IIfc2
    {
        public void PrintOut(string str)
        {
            Console.WriteLine("Calling through: {0}", str);
        }
    }

    //显式接口成员实现
    class MyInterFace3 : IIfc1, IIfc2
    {
        void IIfc1.PrintOut(string s)
        {
            Console.WriteLine("IIfc1: {0}", s);
        }
        void IIfc2.PrintOut(string s)
        {
            Console.WriteLine("IIfc2: {0}", s);
        }

        //访问显式接口成员实现
        public void Method()
        {
            ((IIfc1)this).PrintOut("interface 1");
            ((IIfc2)this).PrintOut("interface 2");
        }
    }

    class ProgramInterFace2
    {
        static void Main()
        {
            var mc = new MyInterFace2();
            mc.PrintOut("object");      //调用类对象的实现方法

            IIfc1 ifc = (IIfc1)mc;
            ifc.PrintOut("interface1");  //调用引用方法

            IIfc2 ifc2 = mc as IIfc2;    //接口和as运算符
            if (ifc2 != null)
                ifc2.PrintOut("interface2");


            var mc2 = new MyInterFace3();

            IIfc1 ifc3 = mc2 as IIfc1;
            if (ifc3 != null)
                ifc3.PrintOut("interface 1");

            IIfc2 ifc4 = mc2 as IIfc2;
            if (ifc4 != null)
                ifc4.PrintOut("interface 2");
        }
    }


    #endregion


    #region 转换
    //checked和unchecked运算符


    //装箱转换
    //1.值类型到引用类型的隐式转换
    //2.隐式转换，它接受值类型的值，根据这个值在堆上创建一个完整的引用类型对象并返回对象引用


    //拆箱转换
    //1.装箱后的对象转换成值类型的过程
    //2.拆箱是显示转换


    //is运算符
    //1.检测转换时否会成功完成
    //2.检测 引用转换、装箱转换、拆箱转换


    //as运算符
    //1.和强制运算符类型，只是它不抛出异常，如果转换失败，它返回null而不是抛出异常


    class ChangeLClass
    {
        static void Main()
        {
            //装箱转换
            int i = 10;     //创建并初始化值类型
            object oi = i;  //对i装箱并把引用赋值给oi
            Console.WriteLine("i:{0},oi:{1}", i, oi);

            i = 12;
            oi = 15;
            Console.WriteLine("i:{0},oi:{1}", i, oi);

            //i:10, oi：10
            //i:12, oi：15

            //拆箱转换
            if (oi is int)
            {
                int j = (int)oi;
            }
        }
    }


    #endregion


    #region 泛型

    /*
     * 泛型：让多个类型共享一组代码，声明类型参数化的代码，用不同的类型进行实例化
     * 类型不是对象而是对象的模板，同样，泛型类型不是类型，而是类型的模板。
     * 
     *      1.声明泛型类
     *      
     */



    /// <summary>
    /// 泛型类 示例1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyStack<T>
    {
        T[] StackArray;
        int StackPointer = 0;
        public void Push(T x)
        {
            if (!IsStackFull)
            {
                StackArray[StackPointer++] = x;
            }
        }
        public T Pop()
        {
            return (!IsStackEmpty) ? StackArray[--StackPointer] : StackArray[0];
        }
        const int MaxStack = 10;
        bool IsStackFull { get { return StackPointer >= MaxStack; } }
        bool IsStackEmpty { get { return StackPointer <= 0; } }
        public MyStack()
        {
            StackArray = new T[MaxStack];
        }
        public void Print()
        {
            for (int i = StackPointer - 1; i >= 0; i--)
            {
                Console.WriteLine("  Value:{0}", StackArray[i]);
            }
        }
    }
    class ProgramFangXing
    {
        static void Main()
        {
            var StackInt = new MyStack<int>();
            var StackString = new MyStack<string>();
            StackInt.Push(3);
            StackInt.Push(5);
            StackInt.Push(7);
            StackInt.Push(9);
            StackInt.Print();
            StackString.Push("This is fun");
            StackString.Push("Hi there!  ");
            StackString.Print();
        }
    }

    /// <summary>
    /// 泛型方法 示例2
    /// </summary>

    /*  
     *  类型参数的约束
     *  约束类型:  class、 struct、 interface、 new()
     */
    class SomeClass<T1, T2, T3, T4>
        where T3 : ICloneable
        where T4 : IComparable
    {
        T1 FirstValue;
        T2 SecondtValue;
        //声明泛型方法
        public void PrintData<T1, T2>(T1 t1, T2 t2)
        {

        }
    }

    class ProgramSomeClass
    {
        static void Main()
        {
            var first = new SomeClass<int, string, ICloneable, IComparable>();
            var second = new SomeClass<int, long, ICloneable, IComparable>();
            first.PrintData<int, string>(25, "请打印我");
        }
    }



    /// <summary>
    /// 泛型方法 示例3
    /// </summary>

    /*  非泛型类中的泛型方法  */
    class Simple    //非泛型类
    {
        static public void ReverseAndPrint<T>(T[] arr)      //泛型方法
        {
            Array.Reverse(arr);
            foreach (T item in arr)     //使用类型参数T
            {
                Console.WriteLine("{0},", item.ToString());
            }
            Console.WriteLine("");
        }
    }
    class ProgramSimple
    {
        static void Main()
        {
            var intArray = new int[] { 3, 5, 7, 9, 11 };
            var stringArray = new string[] { "first", "second", "third" };
            var doubleArray = new double[] { 3.567, 7, 891, 2, 345 };

            Simple.ReverseAndPrint<int>(intArray);  //调用方法
            Simple.ReverseAndPrint(intArray);       //推断类型并调用

            Simple.ReverseAndPrint<string>(stringArray);
            Simple.ReverseAndPrint(stringArray);

            Simple.ReverseAndPrint<double>(doubleArray);
            Simple.ReverseAndPrint(doubleArray);
        }
    }

    /// <summary>
    /// 泛型方法 示例4
    /// </summary>

    /*
     * 泛型类的扩展方法
     * 将其他类中的静态方法关联到不同的泛型类上
     * 其他类 必须声明为static，该方法必须是静态类的成员
     * 第一个参数类型中必须有关键字 this，后面是扩展的泛型类的名字
     */
    static class ExtendHolder
    {
        public static void Print<T>(this Holder<T> h)
        {
            T[] vals = h.GetValues();
            Console.WriteLine("{0},\t{1},\t{2}", vals[0], vals[1], vals[2]);
        }
    }

    class Holder<T>
    {
        T[] Vals = new T[3];
        public Holder(T v0, T v1, T v2)
        {
            Vals[0] = v0;
            Vals[1] = v1;
            Vals[2] = v2;
        }

        public T[] GetValues()
        {
            return Vals;
        }
    }

    class ProgramExtend
    {
        static void Main(string[] args)
        {
            var intHolder = new Holder<int>(3, 5, 7);
            var stringHolder = new Holder<string>("a1", "b2", "c3");
            intHolder.Print();
            stringHolder.Print();
        }
    }


    /// <summary>
    /// 泛型方法 示例5
    /// </summary>
    /// <typeparam name="T"></typeparam>

    /*
     * 泛型结构
     */
    struct PieceOfData<T>
    {
        public PieceOfData(T value)
        {
            _data = value;
        }

        private T _data;
        public T Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }

    class ProgramPiece
    {
        static void Main()
        {
            var intData = new PieceOfData<int>(10);
            var stringData = new PieceOfData<string>("Hi there.");
            Console.WriteLine("intData    ={0}", intData.Data);
            Console.WriteLine("stringData ={0}", stringData.Data);
        }
    }


    /// <summary>
    /// 泛型方法 示例6
    /// </summary>
    /// <typeparam name="T"></typeparam>

    /*
     * 泛型委托1
     */
    delegate void MyDelegate<T>(T value);       //泛型委托

    class SimpleDelegate
    {
        static public void PrintString(string str)  //方法匹配委托
        {
            Console.WriteLine(str);
        }

        static public void PrintUpperString(string str)
        {
            Console.WriteLine("{0}", str.ToUpper());
        }
    }

    class ProgramSimpleDelegate
    {
        static void Main()
        {
            var myDel = new MyDelegate<string>(SimpleDelegate.PrintString);//创建委托的实例
            myDel += SimpleDelegate.PrintUpperString;           //添加方法
            myDel("Hi! Mother Fuck !");         //调用委托
        }
    }


    /*
     * 泛型委托2
     */
    //    委托返回类型      委托参数类型
    //              ↓      ↓  ↓      ↓     ↓
    public delegate TR Func<T1, T2, TR>(T1 t1, T2 t2);//泛型委托

    class SimpleDelegate2
    {
        static public string PrintString(int p1, int p2)//方法匹配委托
        {
            int total = p1 + p2;
            return total.ToString();
        }
    }

    class ProgramSimpleDelegate2
    {
        static void Main()
        {
            var myDel = new Func<int, int, string>(SimpleDelegate2.PrintString);//创建委托实例
            Console.WriteLine("Total:{0}", myDel(15, 13));
        }
    }


    /// <summary>
    /// 泛型方法 示例7
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 

    /*
     * 泛型接口
     */
    interface IMyIfc<T>      //泛型接口
    {
        T ReturnIt(T value);
    }

    //泛型类实现泛型接口
    class Simple<S> : IMyIfc<S> //泛型类
    {
        public S ReturnIt(S inValue)        //实现泛型接口
        {
            return inValue;
        }
    }

    //非泛型类实现泛型接口
    class Simple2 : IMyIfc<int>, IMyIfc<string>  //泛型类
    {
        public int ReturnIt(int inValue)        //实现泛型接口
        {
            return inValue;
        }

        public string ReturnIt(string inValue)        //实现泛型接口
        {
            return inValue;
        }
    }
    class ProgramInterface2
    {
        static void Main()
        {
            var trivInt = new Simple<int>();
            var trivString = new Simple<string>();
            Console.WriteLine("{0}", trivInt.ReturnIt(5));
            Console.WriteLine("{0}", trivString.ReturnIt("Hi there."));

            var triv2 = new Simple2();
            Console.WriteLine("{0}", triv2.ReturnIt(5));
            Console.WriteLine("{0}", triv2.ReturnIt("Hi there."));
        }
    }


    /* 每个变量都有一种类型，可以将派生类对象的实例赋值给基类变量，这叫赋值兼容性
     * 协变：如果派生类只是用于输出值，那么这种结构化的委托有效性之间的常数关系叫协变
     * 逆变：这种期望传入基类时允许传入派生对象的特性叫做逆变
     * 
     */

    //Factory委托
    //协变
    delegate T Factory<out T>();

    //逆变
    delegate void Action1<in T>(T a);

    //基类
    class Animal
    {
        public int Legs = 4;
    }

    //派生类
    class Dog : Animal
    {
    }

    class ProgramFactory
    {
        //符合协变委托的方法
        static Dog MakeDog()
        {
            return new Dog();
        }

        //符合逆变委托的方法
        static void ActOnAnimal(Animal a)
        {
            Console.WriteLine(a.Legs);
        }

        static void Main()
        {
            var a1 = new Animal();
            var a2 = new Dog();
            Console.WriteLine("Number of dog legs:{0}", a2.Legs);

            //协变
            Factory<Dog> dogMaker = MakeDog; //创建委托对象
            Factory<Animal> animalMaker = dogMaker; //尝试赋值给委托对象,错误(在Factory委托中增加 out 关键字)

            //逆变
            Action1<Animal> act1 = ActOnAnimal;
            Action1<Dog> dog1 = act1;
            dog1(new Dog());
        }
    }
    #endregion


    #region 枚举器和迭代器
    //枚举器是一个叫做ArrEnumerator的实例
    //实现GetEnumerator方法的类型叫做可枚举类型(enumerable type)，例如数组
    //实现IEnumerator接口的枚举器包含3个函数成员：Current、MoveNext、Reset
    //Current：只读属性，返回object类型的引用，所以可以返回任何类型
    //MoveNext：把枚举器的位置前进到集合的下一项的方法，返回布尔值，指示新的位置是有效位置还是已经超过了序列的尾部
    //Reset：把位置重置为原始状态的方法

    //模仿foreach的循环
    class EnumeratorClass
    {
        static void Main()
        {
            int[] MyArray = { 10, 11, 12, 13 };
            IEnumerator ie = MyArray.GetEnumerator();
            while (ie.MoveNext())
            {
                int i = (int)ie.Current;
                Console.WriteLine("{0}", i);
            }
        }
    }

    //可枚举类
    //是指实现了IEnumerable接口的类，IEnumerable接口只有一个成员，GetEnumerator方法，它返回对象的枚举器
    class ColorEnumerator : IEnumerator
    {
        string[] _colors;
        int _position = -1;
        public ColorEnumerator(string[] theColors)
        {
            _colors = new string[theColors.Length];
            for (int i = 0; i < theColors.Length; i++)
                _colors[i] = theColors[i];
        }

        public object Current
        {
            get
            {
                if (_position == -1)
                    throw new InvalidOperationException();
                if (_position >= _colors.Length)
                    throw new InvalidOperationException();
                return _colors[_position];
            }
        }

        public bool MoveNext()
        {
            if (_position < _colors.Length - 1)
            {
                _position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _position = -1;
        }
    }

    class Spectrum : IEnumerable
    {
        string[] Colors = { "Red", "Yellow", "Blue", "Green" };
        public IEnumerator GetEnumerator()
        {
            return new ColorEnumerator(Colors);
        }
    }

    class SpectrumProgram
    {
        static void Main()
        {
            Spectrum spectrum = new Spectrum();
            foreach (string color in spectrum)
                Console.WriteLine(color);

        }
    }


    //迭代器
    //更加简单创建枚举器和可枚举类型的方式，编译器将为我们创建它们。

    //迭代器块
    //yield return语句指定了序列中返回的下一项
    //yield break语句指定在序列中没有其他项
    class IEnumeSimple
    {
        //产生枚举器的迭代器
        public IEnumerator<string> IteratorMethod()
        {
            yield return "";
        }

        //产生可枚举类型的迭代器
        public IEnumerable<string> IterableMethod()
        {
            yield return "";
        }
    }

    /// <summary>
    /// 用迭代器创建枚举器
    /// </summary>
    class IEnumeratorClass
    {
        public IEnumerator<string> GetEnumerator()
        {
            return BlackAndWhite();//返回枚举器
        }

        public IEnumerator<string>BlackAndWhite()
        {
            yield return "black";
            yield return "gray";
            yield return "white";
        }
    }

    class IEnumeratorProgram
    {
        static void Main()
        {
            IEnumeratorClass ie = new IEnumeratorClass();
            //使用IEnumeratorClass的实例
            foreach (string shade in ie)
                Console.WriteLine(shade);
        }
    }



    /// <summary>
    /// 用迭代器创建可枚举类型
    /// </summary>
    class IEnumerableClass
    {
        public IEnumerator<string> GetEnumerator()
        {
            IEnumerable<string> myEnumerable = BlackAndWhite();//获取可枚举类型
            return myEnumerable.GetEnumerator();              //返回枚举器
        }

        //返回可枚举类型
        public IEnumerable<string> BlackAndWhite()
        {
            yield return "black";
            yield return "gray";
            yield return "white";
        }
    }

    class IEnumerableProgram
    {
        static void Main()
        {
            IEnumerableClass ie = new IEnumerableClass();
            //使用IEnumerableClass 的实例
            foreach (string shade in ie)
                Console.WriteLine(shade);

            //使用类枚举器方法
            foreach (string shade in ie.BlackAndWhite())
                Console.WriteLine(shade);
        }
    }


    /// <summary>
    /// 将迭代器作为属性
    /// </summary>
    class SpectrumProperty
    {
        bool _listFromUVtoIR;
        string[] colors = { "bule", "green", "yellow", "red" };
        public SpectrumProperty(bool listFromUVtoIR)
        {
            _listFromUVtoIR = listFromUVtoIR;
        }

        public IEnumerator<string>GetEnumerator()
        {
            return _listFromUVtoIR ? UVtoIR : IRtoUV;
        }

        public IEnumerator<string> UVtoIR
        {
            get
            {
                for (int i = 0; i < colors.Length; i++)
                    yield return colors[i];
            }
        }

        public IEnumerator<string>IRtoUV
        {
            get
            {
                for (int i = colors.Length - 1; i >= 0; i++)
                    yield return colors[i];
            }
        }
    }

    #endregion


    #region Linq

    /*
     * 一、匿名类型
     * 1.匿名类型只能和局部变量配合使用，不能用于类成员
     * 2.由于匿名类型没有名字。必须用var关键字作为变量类型
     * 3.不能设置匿名类型对象的属性。编译器为匿名类型创建的属性是只读的
     *
     *
     * 二、方法语法和查询语法
     * 1.方法语法：使用标准的方法调用。是命令式的，指明了查询方法的调用顺序
     * 2.查询语法：使用表达式书写。是声明式的，查询描述的是你想返回的东西，并没有指明如何执行这个查询
     * 
     * 
     * 三、查询变量
     * LINQ查询可以返回两种类型的结果：
     * 1.可以是一个枚举（可枚举的一组数据，不是枚举类型）
     * 2.可以是一个叫做标量的单一值
     * 
     * 
     * 四、标准查询运算符 
     */
    class Other
    {
        static public string Name = "Marry Jones";
    }

    class OtherProgram
    {
        static void Main()
        {
            string Major = "History";
            //                 赋值形式    成员访问   标识符
            var student = new { Age = 19, Other.Name, Major };

            Console.WriteLine("{0},Age{1},Major:{2}", student.Name, student.Age, student.Major);


            /*
             * 查询变量的用法：
             * 1.等号左边的叫查询变量，numsQuery、numMethod、numsCount
             * 2.如果查询表达式返回可枚举数据，查询一直到处理可枚举数据时才会执行
             * 3.可枚举数据被处理多次，查询就会执行多次
             * 4.如果在进行遍历之后，查询执行之前数据有改动，则查询会使用新的数据
             * 5.如果查询表达式返回标量，查询立即执行，并且把结果保存在查询变量中
             */

            /*
             * 查询表达式的结构：
             * 1.子句必须按照一定的顺序出现
             * 2.from子句和select...group子句这两部分是必需的
             * 3.其他子句是可选的
             * 4.可以有任意多的from....let...where...子句
             */
            int[] numbers = { 2, 5, 28, 31, 17, 16, 42 };

            //查询语法,返回可枚举的一组数据
            IEnumerable<int> numsQuery = from n in numbers   
                            where n < 20
                            select n;

            //方法语法,返回可枚举的一组数据
            IEnumerable<int> numMethod = numbers.Where(x => x < 20);

            //两种形式结合，返回的是一个整数
            int numsCount = (from n in numbers  
                             where n < 20
                             select n).Count();
        }
    }


    /* from子句
     *      // from Type Item in Items
     *      
     *      a.迭代变量逐个表示数据源的每个元素
     *      b.Type是集合中元素的类型，这是可选的，因为编译器可以从集合来推断类型
     *      c.Item是迭代变量的名字
     *      d.Items是要查询的集合的名字。集合必须是可枚举的
     *      
     * from子句和foreach语句非常相似，不同点如下：
     *      a.foreach语句命令式的指定了从第一个到最后一个按顺序的访问集合中的项，而from子句则声明式的
     *      规定集合中的每个项都要被访问，但并没有假定以什么样的顺序。
     *      b.foreach语句在遇到代码时就执行其主体，而from子句什么也不执行。只有在程序的控制流遇到访问
     *      查询变量的语句时，才会执行
     *      
     * join子句
     *      a.使用联结来结合两个或更多集合中的数据
     *      b.联结操作接受两个集合然后创建一个临时的对象集合，每一个对象包含原始集合对象中的所有字段
     *      
     *      
     * let子句
     *      a.接受一个表达式的运算并且把它赋值给一个需要在其他运算中使用的标识符
     *   
     *   
     * orderby子句
     *      a.接受一个表达式并根据表达式按顺序返回结果项
     *      b.默认排序是升序，可以使用ascending和descending关键字显示的设置元素的排序为升序或降序
     *      
     *      
     * select...group子句
     *      a.select子句指定所选对象的哪部分应该被select
     *     
     *     
     * group子句
     *      a.如果项包含在查询的结果中，它们就可以根据某个字段的值进行分组。作为分组依据的属性叫做键（key）
     *       b.group子句返回的不是原始数据源中项的枚举，而是返回可以枚举已经形成的项的分组的可枚举类型
     *       c.分组本身是可枚举类型，它们可以枚举实际的项
     *       
     *       
     * into子句
     *      a.查询延续子句可以接受查询的一部分结果并赋予一个名字，从而可以在查询的另一部分中使用。 
     */


    class ProgramLinq
    {
        public class Student
        {
            public int StID;
            public string LastName;
        }
        public class CourseStudent
        {
            public string CourseName;
            public int StID;
            public int Score;
        }

        public Student[] students = new Student[]
        {
        new Student{StID=1,LastName="Carson"},
        new Student{StID=2,LastName="Klassen"},
        new Student{StID=3,LastName="Fleming"}
        };

        public CourseStudent[] studentsInCourses = new CourseStudent[]
        {
        new CourseStudent{CourseName="Art",StID=1, Score = 50},
        new CourseStudent{CourseName="Art",StID=2, Score = 60},
        new CourseStudent{CourseName="History",StID=1, Score = 70},
        new CourseStudent{CourseName="History",StID=3, Score = 80},
        new CourseStudent{CourseName="Physics",StID=3, Score = 90}
        };

        void Main()
        {
            //查找所有选择了历史课的学生的姓氏
            var query = from student in students                                   //from子句
                        join courses in studentsInCourses on student.StID equals courses.StID  //join子句
                        where courses.CourseName == "History"
                        select student.LastName;

            //显示所有选择了历史课的学生的名字
            foreach (var q in query)
            {
                Console.WriteLine("Student taking History:{0}", q);
            }


            //let子句
            var groupA = new[] { 3, 4, 5, 6 };
            var groupB = new[] { 6, 7, 8, 9 };
            var someInts = from a in groupA
                           from b in groupB
                           let sum = a + b         //在新的变量中保存结果
                           where sum == 12
                           select new { a, b, sum };
            foreach (var a in someInts)
            {
                Console.WriteLine(a);
            }

            //orderby子句
            var students2 = new[]
            {
            new{LName="Jones",FName="Mary",Age=19,Major="History"},
            new{LName="Smith",FName="Bob",Age=20,Major="CompSci"},
            new{LName="Fleming",FName="Carol",Age=21,Major="History"},
            };
            var query2 = from student in students2
                        orderby student.Age
                        select student;
            foreach (var s in query2)
            {
                Console.WriteLine("{0},{1}: {2} - {3}", s.LName, s.FName, s.Age, s.Major);
            }


            //select... group子句
            //select子句可以选择对象的某些字段
            var query3 = from student in students2
                         select student.LName;
            foreach (var s in query3)
            {
                Console.WriteLine(s);
            }


            //group子句
            var query4 = from student in students2
                         group student by student.Major;
            foreach (var student in query4)
            {
                Console.WriteLine("{0}", student.Key);
                foreach (var t in student)
                {
                    Console.WriteLine("{0}-{1}", t.LName, t.FName);
                }
            }
            //History
            //          Jones-Mary
            //          Fleming-Carol
            //CompSci
            //          Smith-Bob



            //查询延续：into子句
            var groupA1 = new[] { 3, 4, 5, 6 };
            var groupB1 = new[] { 4, 5, 6, 7 };
            var someInts1 = from a in groupA1
                           join b in groupB1 on a equals b
                           into groupAandB
                           from c in groupAandB
                           select c;
            foreach (var a in someInts)
            {
                Console.WriteLine(a);
            }
            //4 5 6


            //直接语法调用和扩展语法调用时完全相等的
            int count1 = Enumerable.Count(groupA1);
            int firstnum1 = Enumerable.First(groupA1);

            int count2 = groupA1.Count();
            int firstnum2 = groupA1.First();


            //使用lambda表达式参数的示例
            //                       寻找奇数的lambda表达式
            var count3 = groupA1.Count(n => n % 2 == 1);


            //使用委托参数的示例
            Func<int, bool> myDel = new Func<int, bool>(IsOdd);
            int count4 = groupA1.Count(myDel);


            //使用匿名方法
            Func<int, bool> myDe2 = delegate (int x)
             {
                 return x % 2 == 1;
             };
            int count5 = groupA1.Count(myDe2);
        }

        static bool IsOdd(int x)//委托对象使用的方法
        {
            return x % 2 == 1;//如果是奇数返回true
        }
    }










    #endregion


    #region 异步编程
    /* 
     * 一、线程
     * 1.默认情况下，一个进程只包含一个线程，从程序的开始一直执行到结束
     * 2.线程可以派生其他线程，因此在任意时刻，一个进程都可能包含不同状态的多个线程，
     * 来执行程序的不同部分
     * 3.如果一个进程拥有多个线程，它们将共享进程的资源
     * 4.系统为处理器执行所规划的单元是线程，不是进程
     * 
     * 
     * 二、异步方法
     * 1.方法头中包含async方法修饰符，修饰符本身并不能创建任何异步操作
     * 2.包含一个或多个await表达式，表示可以异步完成的任务
     * 3.必须具备以下三种返回类型。第二种（Task）和第三种（Task<T>）的返回对象表示将在未来完成的工作，
     * 调用方法和异步方法可以继续执行。  void  Task  Task<T>
     * 4.异步方法的参数可以为任意类型任意数量，但不能为out或ref参数
     * 5.按照约定，异步方法的名称应该以Async为后缀
     * 6.除了方法以外，Lambda表达式和匿名方法也可以作为异步对象
     * 
     * 7.Task<T>：如果调用方法要从调用中获取一个T类型的值，异步方法的返回类型就必须是Task<T>
     * 调用方法将通过读取Task的Result属性来获取这个T类型的值
     *  Task<int> someTask = DoStuff.CalculateSumAsync(5,6);
     *  ...
     *  Console.WriteLine("Value:{0}", someTask.Result);
     *  
     * 
     * 8.Task：如果调用方法不需要从异步方法中返回某个值，但需要检查异步方法的状态，那么异步方法可以返回
     * 一个Task类型的对象。这时，即使异步方法中出现了return语句，也不会返回任何东西
     *  Task someTask = DoStuff.CalculateSumAsync(5,6);
     *  ...
     *  someTask.Wait();
     *  
     *  
     *  9.void：如果调用方法仅仅想执行异步方法，则不需要与它做任何进一步的交互时，异步方法可以
     *  返回void类型，即使异步方法包含任何return语句，也不会返回任何东西
     */

    class AsyncClass
    {
        //关键字async      返回类型Task<int>
        async Task<int> CountCharactersAsync(int id, string site)
        {
            WebClient wc = new WebClient();
            string result = await wc.DownloadStringTaskAsync(new Uri(site));//await表达式
            return result.Length;
        }

        //关键字async      返回类型Task
        async Task CountCharactersAsync2(int id, string site)
        {
            WebClient wc = new WebClient();
            string result = await wc.DownloadStringTaskAsync(new Uri(site));//await表达式
        }

        //关键字async      返回类型void
        async void CountCharactersAsync3(int id, string site)
        {
            WebClient wc = new WebClient();
            string result = await wc.DownloadStringTaskAsync(new Uri(site));//await表达式
        }

        //Func<int> 委托兼容的Lanmbda表达式
        public int Get10()
        {
            return 10;
        }
        public async Task DoWorkAsync()
        {
            Func<int> ten = new Func<int>(Get10);
            int a = await Task.Run(ten);
            int b = await Task.Run(new Func<int>(Get10));
            int c = await Task.Run(() => { return 10; });
        }


        //用可接受Func委托的形式创建一个Lanmbda表达式
        private static int GetSum(int a, int b)
        {
            return a + b;
        }

        public static async Task DoWorkAsync2()
        {
            int a = await Task.Run(()=>GetSum(5,6));
        }
    }

    class FuncProgram
    {
        static void Main()
        {
            Task t = (new AsyncClass()).DoWorkAsync();
            t.Wait();

            Task t2 = AsyncClass.DoWorkAsync2();
            t2.Wait();
        }
    }

    #endregion

}