using System;
using System.Reflection;
using System.Text;

namespace ReflectionDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectGetTypeDemo();
            Console.WriteLine();
            
            TypeGetTypeDemo();
            Console.WriteLine();
            
            TypeofDemo();
            Console.WriteLine();

            // Type Properties.
            // Modify this line to retrieve details of any other data type  
            // Get name of type  
            Type t = typeof(Car);
            GetTypeProperties(t); 
            Console.WriteLine();

            // Type Methods.
            GetMethod(t);
            Console.WriteLine();
            GetMethods(t);
            Console.WriteLine();

            // Reflecting on Fields and Properties.
            GetFields(t);
            Console.WriteLine();
            GetProperties(t);
            Console.WriteLine();

            // Reflecting on Interfaces.
            GetInterfaces(t);
            Console.WriteLine();

            // Reflecting on Methods Parameters and Return Values.
            GetParametersInfo(t);
            Console.WriteLine();

            // Reflecting on Constructor.
            GetConstructorsInfo(t);
            Console.WriteLine();

            // Loading Assembly.
            LoadAsm();
            Console.WriteLine();

            // Late Binding.
            LateBinding();
            Console.WriteLine();

            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }

        static void ObjectGetTypeDemo()
        {
            Console.WriteLine("Entering ObjectGetTypeDemo()...");
            Car c = new Car();
            Type t = c.GetType();
            Console.WriteLine(t.FullName);
            Console.WriteLine("Exiting ObjectGetTypeDemo()...");
        }

        static void TypeGetTypeDemo()
        {
            Console.WriteLine("Entering TypeGetTypeDemo()...");

            // Obtain type information using the static Type.GetType() method.  
            // (don't throw an exception if Car cannot be found and ignore case).  
            Type t = Type.GetType("ReflectionDemos.Car", false, true);
            Console.WriteLine(t.FullName);

            Console.WriteLine("Exiting TypeGetTypeDemo()...");
        }

        static void TypeofDemo()
        {
            Console.WriteLine("Entering TypeofDemo()...");

            // Get the Type using typeof.  
            Type t = typeof(Car);
            Console.WriteLine(t.FullName);

            Console.WriteLine("Exiting TypeofDemo()...");
        }

        public static void GetTypeProperties(Type t)
        {
            Console.WriteLine("Entering GetTypeProperties()...");

            StringBuilder OutputText = new StringBuilder();

            //properties retrieve the strings   
            OutputText.AppendLine("Analysis of type " + t.Name);
            OutputText.AppendLine("Type Name: " + t.Name);
            OutputText.AppendLine("Full Name: " + t.FullName);
            OutputText.AppendLine("Namespace: " + t.Namespace);

            //properties retrieve references          
            Type tBase = t.BaseType;

            if (tBase != null)
            {
                OutputText.AppendLine("Base Type: " + tBase.Name);
            }
            Type tUnderlyingSystem = t.UnderlyingSystemType;
            if (tUnderlyingSystem != null)
            {
                OutputText.AppendLine("UnderlyingSystem Type: " + tUnderlyingSystem.Name);
                //OutputText.AppendLine("UnderlyingSystem Type Assembly: " + tUnderlyingSystem.Assembly);  
            }
            //properties retrieve boolean          
            OutputText.AppendLine("Is Abstract Class: " + t.IsAbstract);
            OutputText.AppendLine("Is an Arry: " + t.IsArray);
            OutputText.AppendLine("Is a Class: " + t.IsClass);
            OutputText.AppendLine("Is a COM Object : " + t.IsCOMObject);

            OutputText.AppendLine("\nPUBLIC MEMBERS:");
            MemberInfo[] Members = t.GetMembers();

            foreach (MemberInfo NextMember in Members)
            {
                OutputText.AppendLine(NextMember.DeclaringType + " " +
                NextMember.MemberType + "  " + NextMember.Name);
            }
            Console.WriteLine(OutputText);
            Console.WriteLine("Exiting GetTypeProperties()...");
        }

        // Display method names of type.  
        public static void GetMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");
            Console.WriteLine("Entering GetMethods()...");
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
                Console.WriteLine("->{0}", m.Name);
            Console.WriteLine("Exiting GetMethods()...");
        }
        // Display method name of type.  
        public static void GetMethod(Type t)
        {
            Console.WriteLine("***** Method *****");
            Console.WriteLine("Entering GetMethod()...");

            //This searches for name is case-sensitive.   
            //The search includes public static and public instance methods.  
            MethodInfo mi = t.GetMethod("IsMoving");
            Console.WriteLine("->{0}", mi.Name);
            Console.WriteLine("Exiting GetMethod()...");
        }

        // Display field names of type.  
        public static void GetFields(Type t)
        {
            Console.WriteLine("***** Fields *****");
            Console.WriteLine("Entering GetFields()...");
            FieldInfo[] fi = t.GetFields();
            foreach (FieldInfo field in fi)
                Console.WriteLine("->{0}", field.Name);
            Console.WriteLine("Exiting GetFields()...");
        }
        // Display property names of type.  
        public static void GetProperties(Type t)
        {
            Console.WriteLine("***** Properties *****");
            Console.WriteLine("Entering GetProperties()...");

            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo prop in pi)
                Console.WriteLine("->{0}", prop.Name);
            Console.WriteLine("Exiting GetProperties()...");
        }

        // Display implemented interfaces.  
        public static void GetInterfaces(Type t)
        {
            Console.WriteLine("***** Interfaces *****");
            Console.WriteLine("Entering GetInterfaces()...");
            Type[] ifaces = t.GetInterfaces();
            foreach (Type i in ifaces)
                Console.WriteLine("->{0}", i.Name);
            Console.WriteLine("Exiting GetInterfaces()...");
        }

        //Display Method return Type and paralmeters list  
        public static void GetParametersInfo(Type t)
        {
            Console.WriteLine("***** GetParametersInfo *****");
            Console.WriteLine("Entering GetParametersInfo()...");
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                // Get return value.  
                string retVal = m.ReturnType.FullName;
                StringBuilder paramInfo = new StringBuilder();
                paramInfo.Append("(");

                // Get params.  
                foreach (ParameterInfo pi in m.GetParameters())
                {
                    paramInfo.Append(string.Format("{0} {1} ", pi.ParameterType, pi.Name));
                }
                paramInfo.Append(")");

                // Now display the basic method sig.  
                Console.WriteLine("->{0} {1} {2}", retVal, m.Name, paramInfo);
            }
            Console.WriteLine("Exiting GetParametersInfo()...");
        }

        // Display method names of type.  
        public static void GetConstructorsInfo(Type t)
        {
            Console.WriteLine("***** ConstructorsInfo *****");
            Console.WriteLine("Entering ConstructorsInfo()...");
            ConstructorInfo[] ci = t.GetConstructors();
            foreach (ConstructorInfo c in ci)
                Console.WriteLine(c.ToString());
            Console.WriteLine("Exiting ConstructorsInfo()...");
        }

        // Loading Assembly.
        static void LoadAsm()
        {
            Console.WriteLine("Entering LoadAsm()...");
            Assembly objAssembly;
            // You must supply a valid fully qualified assembly name here.              
            //objAssembly = Assembly.Load("mscorlib,4.0.0.0,Neutral");
            // Loads an assembly using its file name     
            //objAssembly = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\CasPol.exe");
            objAssembly = Assembly.LoadFrom(@"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.1\ref\net6.0\mscorlib.dll");
            //this loads currnly running process assembly  
            //objAssembly = Assembly.GetExecutingAssembly();  

            Type[] Types = objAssembly.GetTypes();
            // Display all the types contained in the specified assembly.  
            foreach (Type objType in Types)
            {
                Console.WriteLine(objType.Name.ToString());
            }

            //fetching custom attributes within an assembly  
            Attribute[] arrayAttributes =
             Attribute.GetCustomAttributes(objAssembly);
            // assembly1 is an Assembly object  

            foreach (Attribute attrib in arrayAttributes)
            {
                Console.WriteLine(attrib.TypeId);
            }
            Console.WriteLine("Exiting LoadAsm()...");
        }

        // Late binding.
        static void LateBinding()
        {
            Console.WriteLine("Entering LateBinding()...");
            Assembly objAssembly;
            // Loads an assembly    
            objAssembly = Assembly.GetExecutingAssembly();

            //get the class type information in which late binding applied  
            Type classType = objAssembly.GetType("ReflectionDemos.Car");

            //create the instance of class using System.Activator class  
            object obj = Activator.CreateInstance(classType);

            //get the method information  
            MethodInfo mi = classType.GetMethod("IsMoving");

            //Late Binding using Invoke method without parameters  
            bool isCarMoving;
            isCarMoving = (bool)mi.Invoke(obj, null);
            if (isCarMoving)
            {
                Console.WriteLine("Car Moving Status is : Moving");
            }
            else
            {
                Console.WriteLine("Car Moving Status is : Not Moving");
            }

            //Late Binding with parameters  
            object[] parameters = new object[3];
            parameters[0] = 32456;//parameter 1 startMiles  
            parameters[1] = 32810;//parameter 2 end Miles  
            parameters[2] = 10.6;//parameter 3 gallons  
            mi = classType.GetMethod("calculateMPG");
            double MilesPerGallon;
            MilesPerGallon = (double)mi.Invoke(obj, parameters);
            Console.WriteLine("Miles per gallon is : " + MilesPerGallon);

            Console.WriteLine("Exiting LateBinding()...");
        }
    }
}
