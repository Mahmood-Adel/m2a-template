namespace Application.Wrapper;

public class PaginatedResult<T> : Result
{
    public PaginatedResult(List<T> data)
    {
        Data = data;
    }

    internal PaginatedResult(bool succeeded, List<T> data = null, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10)
    {
        Data = data;
        Succeeded = succeeded;
        CurrentPage = page;
        PageSize = pageSize;
        TotalCount = count;
        TotalPages = (int) Math.Ceiling(count / (double) pageSize);
    }
    
    public static PaginatedResult<T> Failure(List<string> messages)
    {
        return new PaginatedResult<T>(false, default, messages);
    }

    public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
    {
        return new PaginatedResult<T>(true, data, null, count, page, pageSize);
    }

    public List<T> Data { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;
}