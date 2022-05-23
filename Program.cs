// See https://aka.ms/new-console-template for more information

using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using DynamoDbRepository.Playground.Data;
using DynamoDbRepository.Playground.Model;
using EfficientDynamoDb;
using EfficientDynamoDb.Configs;
using EfficientDynamoDb.Credentials.AWSSDK;

Console.WriteLine("Hello, Dynamo!");

var chain = new CredentialProfileStoreChain();
AWSCredentials awsCredentials;
DynamoDbContext dynamodbContext = default;

if (chain.TryGetAWSCredentials("default", out awsCredentials))
{
    var config = new DynamoDbContextConfig(RegionEndpoint.USEast1,
        awsCredentials.ToCredentialsProvider())
    {
    };
    dynamodbContext = new DynamoDbContext(config);
}

var myRepo = new MyRepository<Person>(dynamodbContext);


// Feed Data
var yo = new Person()
{
    Name = "Jesus",
    Profession = "Engineer"
};


var result = await myRepo.Create(yo, "DynamoDbRepositoryPlayground");
Console.WriteLine("Exit");

