using System;

namespace DotCoreWebAPI.Controllers
{
    /// <summary>
    /// Singleton under .net framework 4.0
    /// </summary>
    /// <typeparam name="T">specific class</typeparam>
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/dd642331.aspx"/>
    /// <remarks>author Petter Liu http://wintersun.cnblogs.com </remarks>
    public static class Singleton<T> where T : class
       {
           // Initializes a new instance of the Lazy<T> class. When lazy initialization occurs, the specified
         //     initialization function and initialization mode are used.
         private static readonly Lazy<T> current = new Lazy<T>(
             () =>
                 Activator.CreateInstance<T>(),    // factory method
                 true);                                       // double locks
  
         public static object Current
         {
             get { return current.Value; }
         }
     }
}
