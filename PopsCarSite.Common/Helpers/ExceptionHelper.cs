using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsCarsSite.Common.Helpers;
public static class ExceptionHelper
{

	public static IEnumerable<Exception> GetAllExceptions(this Exception exception)
	{
		var innerException = exception;
		do
		{
			yield return innerException;
			innerException = innerException.InnerException;
		}
		while (innerException != null);
	}
}
