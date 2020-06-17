﻿using System;
using System.Reflection;
using System.Reflection.Emit;

namespace EmitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName aName = new AssemblyName("DynamicAssemblyExample");

            var ab = AssemblyBuilder.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndCollect);
            ModuleBuilder mb = ab.DefineDynamicModule(aName.Name + ".dll");
            TypeBuilder tb = mb.DefineType("MyDynamicType", TypeAttributes.Public);
            FieldBuilder fbNumber = tb.DefineField("m_number", typeof(int), FieldAttributes.Private);
            Type[] parameterTypes = { typeof(int) };
            ConstructorBuilder ctor1 = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);

            ILGenerator ctor1IL = ctor1.GetILGenerator();
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));

            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Ldarg_1);
            ctor1IL.Emit(OpCodes.Stfld, fbNumber);
            ctor1IL.Emit(OpCodes.Ret);

            // Define a default constructor that supplies a default value
            // for the private field. For parameter types, pass the empty
            // array of types or pass null.
            ConstructorBuilder ctor0 = tb.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                Type.EmptyTypes);

            ILGenerator ctor0IL = ctor0.GetILGenerator();
            // For a constructor, argument zero is a reference to the new
            // instance. Push it on the stack before pushing the default
            // value on the stack, then call constructor ctor1.
            ctor0IL.Emit(OpCodes.Ldarg_0);
            ctor0IL.Emit(OpCodes.Ldc_I4_S, 42);
            ctor0IL.Emit(OpCodes.Call, ctor1);
            ctor0IL.Emit(OpCodes.Ret);


            PropertyBuilder pbNumber = tb.DefineProperty("Number", PropertyAttributes.HasDefault, typeof(int), null);
            MethodAttributes getSetAttr = MethodAttributes.Public |
            MethodAttributes.SpecialName | MethodAttributes.HideBySig;

            MethodBuilder mbNumberGetAccessor = tb.DefineMethod("get_Number", getSetAttr, typeof(int), Type.EmptyTypes);

            ILGenerator numberGetIL = mbNumberGetAccessor.GetILGenerator();

            numberGetIL.Emit(OpCodes.Ldarg_0);
            numberGetIL.Emit(OpCodes.Ldfld, fbNumber);
            numberGetIL.Emit(OpCodes.Ret);

            MethodBuilder mbNumberSetAccessor = tb.DefineMethod(
        "set_Number",
        getSetAttr,
        null,
        new Type[] { typeof(int) });

            ILGenerator numberSetIL = mbNumberSetAccessor.GetILGenerator();
            // Load the instance and then the numeric argument, then store the
            // argument in the field.
            numberSetIL.Emit(OpCodes.Ldarg_0);
            numberSetIL.Emit(OpCodes.Ldarg_1);
            numberSetIL.Emit(OpCodes.Stfld, fbNumber);
            numberSetIL.Emit(OpCodes.Ret);


            pbNumber.SetGetMethod(mbNumberGetAccessor);
            pbNumber.SetSetMethod(mbNumberSetAccessor);

            MethodBuilder meth = tb.DefineMethod(
       "MyMethod",
       MethodAttributes.Public,
       typeof(int),
       new Type[] { typeof(int) });

            ILGenerator methIL = meth.GetILGenerator();

            methIL.Emit(OpCodes.Ldarg_0);
            methIL.Emit(OpCodes.Ldfld, fbNumber);
            methIL.Emit(OpCodes.Ldarg_1);
            methIL.Emit(OpCodes.Mul);
            methIL.Emit(OpCodes.Ret);

            Type t = tb.CreateType();

            //    ab.Save(aName.Name + ".dll");
            MethodInfo mi = t.GetMethod("MyMethod");
            PropertyInfo pi = t.GetProperty("Number");
            object o1 = Activator.CreateInstance(t);
            Console.WriteLine("o1.Number: {0}", pi.GetValue(o1, null));
            pi.SetValue(o1, 127, null);
            Console.WriteLine("o1.Number: {0}", pi.GetValue(o1, null));
            object[] arguments = { 22 };
            Console.WriteLine("o1.MyMethod(22): {0}",
                mi.Invoke(o1, arguments));

            object o2 = Activator.CreateInstance(t,
     new object[] { 5280 });
            Console.WriteLine("o2.Number: {0}", pi.GetValue(o2, null));

            Console.ReadKey();
        }

    }
}
