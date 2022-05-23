namespace DynamoDbRepository.Playground.Data;

public class Result
{
    protected Result()
    {
            
    }
    
    public bool Success { get; init; }
    public string? ErrorMessage { get; init; }
    
    public static Result Ok() => new Result { Success = true };
}

public class Result<T> : Result
{
    private Result() : base()
    {
            
    }
    
    public T? Value { get; init; }
    
    public new static Result<T> Ok() => new Result<T> { Success = true };
    public static Result<T> Ok(T? value) => new Result<T> { Success = true, Value = value};
    public static Result<T> ByValue(T? value, string possibleError) => new Result<T> { Success = value is not null, Value = value, ErrorMessage = value is null ? possibleError : null};
    public static Result<T> Error(string error) => new Result<T> { Success = true, ErrorMessage = error};
}
