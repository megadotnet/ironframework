using GRPCEmployeeService;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronFramework.GrpcService.Impl
{
    /// <summary>
    /// GrpcEmployeeServiceImpl
    /// </summary>
    public class GrpcEmployeeServiceImpl : GRPCEmployeeService.gRPC.gRPCBase
    {
        /// <summary>
        /// GetEmployeeList
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<GetEmployeeListResponse> GetEmployeeList(GetEmployeeListRequest request, ServerCallContext context)
        {
            if (request==null)
            {
                throw new ArgumentNullException("request should not be null");
            }

            var getEmployeeListResponse = new GetEmployeeListResponse() { Count = 1, IsSuccess = true };

            var msgItem = new GetEmployeeListResponse.Types.EmployeeItem()
            {
                ContactID = 1,
                EmployeeID = 1,
                NationalIDNumber = "54353",
                Title = "Develop"
            };

            getEmployeeListResponse.Items.Add(msgItem);

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
            var result = new EditEmployeeReply();
            result.IsSuccess = true;

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
            //var msg = await _msgRepository.Get(request.Id);

            return await Task.FromResult(new GetEmployeeOneReply
            {
                IsSuccess = true,
                EmployeeID = 1,
                ContactID = 1,
                Title = "test",
                NationalIDNumber = "23434"
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
            var result = new RemoveEmployeeReply();
            // result.IsSuccess = await _msgRepository.Delete(request.EmployeeID);
            result.IsSuccess = true;
            return await Task.FromResult(result);
        }
    }
}
