namespace Application.Wrapper;

public interface IResult
{
    public List<string> Messages { get; set; }
    public bool Succeeded { get; set; }
}

public interface IResult<out T> : IResult
{
    T Data { get; }
}