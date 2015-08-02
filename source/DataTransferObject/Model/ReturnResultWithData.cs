namespace DataTransferObject.Model
{
    public class ReturnResultWithData<T> : ReturnResult
    {
        /// <summary>
        /// 结果数据
        /// </summary>
        public T Data { get; set; }
    }
}