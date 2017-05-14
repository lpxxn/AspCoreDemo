using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressDemo
{
    // my class
    public class MyObject
    {
        public bool DisplayValue { get; set; }
    }

    public class Test1
    {
        // memberinitexpression
        // https://msdn.microsoft.com/en-us/library/system.linq.expressions.memberinitexpression.aspx

        public Test1()
        { // my lambda:
            var lambda = (Func<bool, MyObject>)
                 (displayValue => new MyObject { DisplayValue = displayValue });
            var display = new MyObject();
            var obj1 = lambda(true);

            var builedLambda = BuildLambda();
        }

        public Expression<Func<bool, MyObject>> BuildLambda()
        {
            var createdType = typeof(MyObject);
            var displayValueParam = Expression.Parameter(typeof(bool), "displayValue");
            var ctor = Expression.New(createdType);
            var displayValueProperty = createdType.GetProperty("DisplayValue");
            var displayValueAssigment = Expression.Bind(displayValueProperty, displayValueParam);
            var memberInit = Expression.MemberInit(ctor, displayValueAssigment);
            var exp = Expression.Lambda<Func<bool, MyObject>>(memberInit, displayValueParam);
            Console.WriteLine(exp.ToString());
            return exp;
        }





        //var instantiator = AnonymousInstantiator(new { Name = default(string), Num = default(int) });

        //var a1 = instantiator(new object[] { "abc", 123 }); // strongly typed
        //var a2 = instantiator(new object[] { "xyz", 789 }); // strongly typed
                                                            // etc.
        //You can avoid using DynamicInvoke which is painfully slow.You could make use of type inference in C# to get your anonymous type instantiated generically. Something like:

        public static Func<object[], T> AnonymousInstantiator<T>(T example)
        {
            var ctor = typeof(T).GetConstructors().First();
            var paramExpr = Expression.Parameter(typeof(object[]));
            return Expression.Lambda<Func<object[], T>>
            (
                Expression.New
                (
                    ctor,
                    ctor.GetParameters().Select
                    (
                        (x, i) => Expression.Convert
                        (
                            Expression.ArrayIndex(paramExpr, Expression.Constant(i)),
                            x.ParameterType
                        )
                    )
                ), paramExpr).Compile();
        }




    }



}
