using PopsCarsSite.Common.Helpers;

namespace PopsCarsSite.Common.Models;

public class CommonResponse<T>
{
	public Exception? ResponseException { get; set; }
	public bool Error { get; set; }
	public string? ResponseErrorMsg { get; set; }
	public List<string> ResponseErrorMsgs { get; set; } = new List<string>();
	public T? Value { get; set; }

	public async Task SetExceptionAsync(Exception? ex = null, string msg = "")
	{
		Error = true;
		if (ex != null)
		{
			ResponseException = ex;
			ResponseErrorMsgs.AddRange(ex.GetAllExceptions().Select(e => e.Message).ToList());

			if (string.IsNullOrEmpty(ResponseErrorMsg))
			{
				ResponseErrorMsg = string.IsNullOrWhiteSpace(msg) ? ex.Message : msg;
			}
		}
		else
		{
			if (!string.IsNullOrWhiteSpace(msg))
			{
				ResponseErrorMsg = msg;
				ResponseErrorMsgs.Add(msg);
			}
		}
	}
}