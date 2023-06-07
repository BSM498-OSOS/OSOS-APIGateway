using Core.Utilities.Results;
using Entities.Models.CustomerApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.CustomerApi
{
    public interface ICustomerApiService
    {
        Task<HttpResponseMessage> Add(Customer customer);
        Task<HttpResponseMessage> Delete(Customer customer);
        Task<HttpResponseMessage> Update(Customer customer);
        Task<IDataResult<Customer>> GetById(Guid customerId);
        Task<IDataResult<Customer>> GetByMeterSerialNo(int serialNo);
        Task<IDataResult<List<Customer>>> GetAll();

    }
}
