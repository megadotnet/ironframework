using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.ObjectModel;

namespace IronFramework.Utility
{
    public static class UtilityExtention
    {
        /// <summary>
        /// Gets the method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="methodSelector">The method selector.</param>
        /// <seealso cref="http://stackoverflow.com/questions/3476757/c-sharp-extension-method-for-checking-attributes/3477106#3477106"/>
        /// <returns>MethodInfo</returns>
        public static MethodInfo GetMethod<T>(this T instance, Expression<Func<T, object>> methodSelector)
        {
            // it is not work all the method
            return ((MethodCallExpression)methodSelector.Body).Method;
        }

        public static MethodInfo GetMethod<T>(this T instance,
            Expression<Action<T>> methodSelector)
        {
            return ((MethodCallExpression)methodSelector.Body).Method;
        }

        public static bool HasAttribute<TAttribute>(
            this MemberInfo member)
            where TAttribute : Attribute
        {
            return GetAttributes<TAttribute>(member).Length > 0;
        }

        public static TAttribute[] GetAttributes<TAttribute>(
            this MemberInfo member)
            where TAttribute : Attribute
        {
            var attributes =
                member.GetCustomAttributes(typeof(TAttribute), true);

            return (TAttribute[])attributes;
        }

        #region GetCustomAttributes<T>
        /// <summary>Searches and returns attributes. The inheritance chain is not used to find the attributes.</summary> 
        /// <typeparam name="T">The type of attribute to search for.</typeparam> 
        /// <param name="type">The type which is searched for the attributes.</param> 
        /// <returns>Returns all attributes.</returns> 
        /// <seealso cref=" http://stackoverflow.com/questions/540749/can-a-c-sharp-class-inherit-attributes-from-its-interface"/>
        public static T[] GetCustomAttributes<T>(this Type type) where T : Attribute
        {
            return GetCustomAttributes(type, typeof(T), false).Select(arg => (T)arg).ToArray();
        }

        /// <summary>Searches and returns attributes.</summary> 
        /// <typeparam name="T">The type of attribute to search for.</typeparam> 
        /// <param name="type">The type which is searched for the attributes.</param> 
        /// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes. Interfaces will be searched, too.</param> 
        /// <returns>Returns all attributes.</returns> 
        public static T[] GetCustomAttributes<T>(this Type type, bool inherit) where T : Attribute
        {
            return GetCustomAttributes(type, typeof(T), inherit).Select(arg => (T)arg).ToArray();
        }

        /// <summary>Private helper for searching attributes.</summary> 
        /// <param name="type">The type which is searched for the attribute.</param> 
        /// <param name="attributeType">The type of attribute to search for.</param> 
        /// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attribute. Interfaces will be searched, too.</param> 
        /// <returns>An array that contains all the custom attributes, or an array with zero elements if no attributes are defined.</returns> 
        private static object[] GetCustomAttributes(Type type, Type attributeType, bool inherit)
        {
            if (!inherit)
            {
                return type.GetCustomAttributes(attributeType, false);
            }

            var attributeCollection = new Collection<object>();
            var baseType = type;

            do
            {
                baseType.GetCustomAttributes(attributeType, true).Apply(attributeCollection.Add);
                baseType = baseType.BaseType;
            }
            while (baseType != null);

            foreach (var interfaceType in type.GetInterfaces())
            {
                GetCustomAttributes(interfaceType, attributeType, true).Apply(attributeCollection.Add);
            }

            var attributeArray = new object[attributeCollection.Count];
            attributeCollection.CopyTo(attributeArray, 0);
            return attributeArray;
        }

        /// <summary>Applies a function to every element of the list.</summary> 
        private static void Apply<T>(this IEnumerable<T> enumerable, Action<T> function)
        {
            foreach (var item in enumerable)
            {
                function.Invoke(item);
            }
        }  
        #endregion


    }
}
