using EfficientDynamoDb;
using EfficientDynamoDb.Extensions;
using EfficientDynamoDb.Operations.Shared;

namespace DynamoDbRepository.Playground.Data;

public class MyRepository<T> where T : class
{
    private readonly DynamoDbContext _dynamoDbContext;
    
    public MyRepository(DynamoDbContext dynamoDbContext)
    {
        _dynamoDbContext = dynamoDbContext;
    }
    
    public async Task<Result<T>> Create(T entity, string tableName)
    {
        var item = await _dynamoDbContext.PutItem()
            .WithItem(entity)
            .WithTableName(tableName)
            .WithReturnValues(ReturnValues.AllOld)
            .ToItemAsync();

        return Result<T>.ByValue(item, "Internal error");
    }
    
    public async Task<Result<T>> CreateWithResponse(T entity, string tableName)
    {
        var item = await _dynamoDbContext.PutItem()
            .WithItem(entity)
            .WithTableName(tableName)
            .ToResponseAsync();

        return Result<T>.ByValue(null, "Internal error");
    }
}