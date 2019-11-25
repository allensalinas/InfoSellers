using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.Domain.Model
{
    public class OperationResult<T>
    {
        public OperationResult(T succesResult)
        {
            Result = succesResult;
        }

        public OperationResult(string errorDescription, int errorID)
        {
            ErrorDescription = errorDescription;
            ErrorID = errorID;
        }

        public string ErrorDescription { get; set; }
        public int ErrorID { get; set; }
        public T Result { get; set; }

        public bool SuccessResult
        {
            get
            {
                return String.IsNullOrEmpty(ErrorDescription);
            }
        }
    }
}