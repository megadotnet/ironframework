using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectStandard.Service
{
    /// <summary>
    /// IService
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IService<TEntity>  where TEntity : class
    {
    }
}
