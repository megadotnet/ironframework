namespace DataServiceClient
{
    using System.Threading.Tasks;

    /// <summary>
    /// IRESTAPIWrapperClinet
    /// </summary>
    public interface IRESTAPIWrapperClinet
    {
        /// <summary>
        ///     Gets or sets the URI.
        /// </summary>
        /// <value>
        ///     The URI.
        /// </value>
        string URI { get; set; }

        /// <summary>
        /// Clients the HTTP get string.
        /// </summary>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="paramstr">The paramstr.</param>
        /// <param name="customURL">The custom URL.</param>
        /// <param name="isawait">if set to <c>true</c> [isawait].</param>
        /// <returns></returns>
        Task<string> ClientHTTPGetString<Query>(string paramstr, string customURL, bool isawait) where Query : new();

        /// <summary>
        /// Clients the HTTP delete.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> ClientHTTPDelete<TResult>(int id);


        /// <summary>
        /// Clients the HTTP delete.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="customURL">The custom URL.</param>
        /// <returns></returns>
        Task<bool> ClientHTTPDelete<TResult>(int id, string customURL);

        /// <summary>
        /// Clients the HTTP get.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <param name="id">
        /// The identifier.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TResult> ClientHTTPGet<TResult>(int id) where TResult : new();

        /// <summary>
        /// Clients the HTTP get.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <param name="id">
        /// The identifier.
        /// </param>
        /// <param name="customURL">
        /// The custom URL.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TResult> ClientHTTPGet<TResult>(int id, string customURL) where TResult : new();

        /// <summary>
        /// Clients the HTTP get by URL.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <typeparam name="Query">
        /// The type of the uery.
        /// </typeparam>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="url">
        /// The URL.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TResult> ClientHTTPGetList<TResult, Query>(Query query, string url) where TResult : new();

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <typeparam name="Query">
        /// The type of the uery.
        /// </typeparam>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TResult> ClientHTTPGetList<TResult, Query>(Query query) where TResult : new();

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <typeparam name="Query">
        /// </typeparam>
        /// <param name="query">
        /// </param>
        /// <param name="isawait">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TResult> ClientHTTPGetList<TResult, Query>(Query query, bool isawait) where TResult : new();

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <typeparam name="Query">
        /// The type of the uery.
        /// </typeparam>
        /// <param name="partialURI">
        /// The partial URI.
        /// </param>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="isawait">
        /// if set to <c>true</c> [isawait].
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TResult> ClientHTTPGetList<TResult, Query>(string partialURI, Query query, bool isawait)
            where TResult : new();

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <typeparam name="QueryDto">
        /// The type of the uery dto.
        /// </typeparam>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TResult> ClientHTTPGetList<TResult, QueryDto>(string queryString) where TResult : new();

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <typeparam name="QueryDto">
        /// The type of the uery dto.
        /// </typeparam>
        /// <param name="partialURI">
        /// The partial URI.
        /// </param>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TResult> ClientHTTPGetList<TResult, QueryDto>(string partialURI, string queryString)
            where TResult : new();

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <typeparam name="QueryDto">
        /// The type of the uery dto.
        /// </typeparam>
        /// <param name="partialURI">
        /// The partial URI.
        /// </param>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <param name="configureAwait">
        /// if set to <c>true</c> [configure await].
        /// </param>
        /// <see cref="http://stackoverflow.com/questions/12933090/async-await-with-configureawaits-continueoncapturedcontext-parameter-and-synchr"/>
        /// <seealso cref="http://stackoverflow.com/questions/12482338/async-action-filter-in-mvc-4"/>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TResult> ClientHTTPGetList<TResult, QueryDto>(
            string partialURI, 
            string queryString, 
            bool configureAwait) where TResult : new();

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TQueryDto">The type of the query dto.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="query">The query.</param>
        /// <param name="isawait">if set to <c>true</c> [isawait].</param>
        /// <returns></returns>
        Task<TResult> ClientHTTPGetList<TResult, TQueryDto, Query>(string partialURI, Query query, bool isawait)
where TResult : new();

        /// <summary>
        /// Clients the HTTP put.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> ClientHTTPPut<TResult>(TResult model);

        /// <summary>
        /// Clients the HTTP put.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="customPartialUri">
        /// The custom partial URI.
        /// </param>
        /// <returns>
        /// bool
        /// </returns>
        Task<bool> ClientHTTPPut<TResult>(TResult model, string customPartialUri);

        /// <summary>
        /// Clients the invoke HTTP post.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> ClientHttpPOST<TResult>(TResult model);

        Task<bool> ClientHttpPOST<T, Query>(Query query, string customURL) where T : new();

        Task<bool> ClientHttpPOST<T, Query>(Query query, string customURL, bool isawait) where T : new();
        Task<ReturnObject> ClientHttpPOST<ReturnObject, T, Query>(Query query, string customURL)
            where T : new()
            where ReturnObject : new();

      /// <summary>
     /// Clients the HTTP post.
     /// </summary>
     /// <typeparam name="ReturnObject">The type of the eturn object.</typeparam>
     /// <typeparam name="T"></typeparam>
     /// <typeparam name="Query">The type of the uery.</typeparam>
     /// <param name="query">The query.</param>
     /// <param name="customURL">The custom URL.</param>
    /// <param name="isawait">if set to <c>true</c> [isawait].</param>
     /// <returns></returns>
        Task<ReturnObject> ClientHttpPOST<ReturnObject, T, Query>(Query query, string customURL, bool isawait)
            where ReturnObject : new()
            where T : new();

        /// <summary>
        /// Clients the HTTP put.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="customPartialUri">The custom partial URI.</param>
        /// <returns></returns>
        Task<bool> ClientHTTPPut<TResult, Query>(Query model, string customPartialUri);

        /// <summary>
        /// Clients the HTTP put.
        /// </summary>
        /// <typeparam name="ReturnObject">The type of the eturn object.</typeparam>
        /// <typeparam name="TQueryDto">The type of the query dto.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="customPartialUri">The custom partial URI.</param>
        /// <returns></returns>
        Task<ReturnObject> ClientHTTPPut<ReturnObject, TQueryDto, Query>(Query model, string customPartialUri) where ReturnObject : new();

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="isawait">if set to <c>true</c> [isawait].</param>
        /// <returns></returns>
        Task<TResult> ClientHTTPGetList<TResult, Query>(string partialURI, bool isawait) where TResult : new();

        string GetQueryString(object obj);
    }
}