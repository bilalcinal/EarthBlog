namespace EarthBlog.Core.Utilities.Result;

public interface IResult
{
	bool Success { get; }

	string Message { get; }
}