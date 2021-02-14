using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAllCustomers();
        IResult Add(Customer customers);
        IResult Update(Customer customers);
        IResult Delete(Customer customers);
    }
}
