using GRPCEmployeeService;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronFramework.Utility.UI;
using DataTransferObject;
using BusinessObject;

namespace IronFramework.GrpcService.Impl
{
    /// <summary>
    /// GrpcEmployeeServiceImpl
    /// </summary>
    public class GrpcEmployeeServiceImpl : GRPCEmployeeService.gRPC.gRPCBase
    {
        /// <summary>
        /// The Employee bo
        /// </summary>
        private IEmployeeBO _EmployeeBO = null;

        /// <summary>
        /// GrpcEmployeeServiceImpl
        /// </summary>
        /// <param name="_employeeBO"></param>
        public GrpcEmployeeServiceImpl(IEmployeeBO _employeeBO)
        {
            _EmployeeBO = _employeeBO;
        }

        /// <summary>
        /// GetEmployeeList
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<GetEmployeeListResponse> GetEmployeeList(GetEmployeeListRequest request, ServerCallContext context)
        {
            CheckRequestInvalid(request);

            var  _employeeDtos = new EmployeeDto() { EmployeeID= request.EmployeeID };
            var pagedlist = new PagedList<EmployeeDto> { _employeeDtos };

            pagedlist.PageIndex = 1;
            pagedlist.PageSize = int.MaxValue;
            var employeeResults =_EmployeeBO.FindAll(pagedlist);

            var getEmployeeListResponse = new GetEmployeeListResponse() { Count = employeeResults.Total, IsSuccess = true };

            //Fill collection
            employeeResults.Rows.ToList().ForEach(e => {
                var msgItem = new GetEmployeeListResponse.Types.EmployeeItem()
                {
                    ContactID = e.ContactID,
                    EmployeeID = e.EmployeeID,
                    NationalIDNumber = e.NationalIDNumber,
                    Title = e.Title
                };

                getEmployeeListResponse.Items.Add(msgItem);
            });

         

            return Task.FromResult(getEmployeeListResponse);
        }


        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<EditEmployeeReply> Edit(EditEmployeeRequest request, ServerCallContext context)
        {
            CheckRequestInvalid(request);

            var result = new EditEmployeeReply();
            result.IsSuccess = _EmployeeBO.UpdateEntiy(new EmployeeDto {
                EmployeeID = request.EmployeeID
            , Title=request.Title
            , NationalIDNumber=request.NationalIDNumber});

            return await Task.FromResult(result);
        }

        /// <summary>
        /// GetOne
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<GetEmployeeOneReply> GetOne(GetEmployeeOneRequest request, ServerCallContext context)
        {
            CheckRequestInvalid(request);

            var employeeDto=_EmployeeBO.GetEntiyByPK(new EmployeeDto { EmployeeID = request.EmployeeID });

            return await Task.FromResult(new GetEmployeeOneReply
            {
                IsSuccess = true,
                EmployeeID = employeeDto.EmployeeID,
                ContactID = employeeDto.ContactID,
                Title = employeeDto.Title,
                NationalIDNumber = employeeDto.NationalIDNumber
            });
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<RemoveEmployeeReply> Remove(RemoveEmployeeRequest request, ServerCallContext context)
        {
            CheckRequestInvalid(request);

            var result = new RemoveEmployeeReply();
       
            result.IsSuccess = _EmployeeBO.DeleteEntiy(new EmployeeDto { EmployeeID = request.EmployeeID });
            return await Task.FromResult(result);
        }

        /// <summary>
        /// CheckRequestInvalid
        /// </summary>
        /// <param name="request"></param>
        private static void CheckRequestInvalid<T>(T request) where T: class
        {
            if (request == null)
            {
                throw new ArgumentNullException("request should not be null");
            }
        }
    }
}
