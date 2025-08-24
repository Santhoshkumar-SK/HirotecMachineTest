using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto
{
	public class BaseResponse<T>
	{
		public bool isSuccess { get; set; }
		public int HttpStatusCode { get; set; }
		public string ErrorInfo { get; set; }
		public T Result { get; set; }
	}
}
