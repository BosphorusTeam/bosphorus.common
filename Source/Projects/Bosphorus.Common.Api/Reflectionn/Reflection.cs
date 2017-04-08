using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Bosphorus.Common.Api.Reflectionn
{
    public class Reflection<TReflected>
    {
        private readonly static Type reflectedType;

        static Reflection()
        {
            reflectedType = typeof (TReflected);
        }

        public static MethodInfo GetMethodInfo(Expression<Action<TReflected>> expression)
        {
            var result = GetMethodInfo(expression as LambdaExpression);
            return result;
        }

        public static MethodInfo GetMethodInfo<TResult>(Expression<Func<TReflected, TResult>> expression)
        {
            var result = GetMethodInfo(expression as LambdaExpression);
            return result;
        }

        public static MethodInfo GetMethodInfo(LambdaExpression expression)
        {
            MethodCallExpression outermostExpression = expression.Body as MethodCallExpression;

            if (outermostExpression == null)
            {
                throw new ArgumentException("Invalid Expression. Expression should consist of a Method call only.");
            }

            return outermostExpression.Method;
        }

        public static MethodInfo GetExplicitMethodInfo(MethodInfo interfaceMethodInfo)
        {
            Type interfaceType = interfaceMethodInfo.DeclaringType;
            InterfaceMapping interfaceMapping = reflectedType.GetInterfaceMap(interfaceType);

            MethodInfo[] interfaceMethods = interfaceMapping.InterfaceMethods;
            int index = Array.IndexOf(interfaceMethods, interfaceMethodInfo);

            MethodInfo explicitMethodInfo = interfaceMapping.TargetMethods[index];
            return explicitMethodInfo;
        }
    }
}
