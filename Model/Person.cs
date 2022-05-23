using EfficientDynamoDb.Attributes;

namespace DynamoDbRepository.Playground.Model;

[DynamoDbTable("")]
public class Person
{
    #region Dynamo Generators
    public static string PK_Gen (string name) => $"PERSON#{name}";
    public static string SK_Gen () => "METADATA";
    public static string GSI1PK_DynamoDBItemType_Gen() => $"DynamoDBItemType#{nameof(Person)}";
    public static string GSI1SK_InterfaceType_Gen(string profession) => $"PROFESSION#{profession}";
    #endregion
    
    #region DynamoDBItem
    [DynamoDbProperty("PK", DynamoDbAttributeType.PartitionKey)]
    public string PK { get => PK_Gen(Name); }
    
    [DynamoDbProperty("SK", DynamoDbAttributeType.SortKey)]
    public string SK { get => SK_Gen(); }
    
    [DynamoDbProperty("GSI1PK")]
    public string GSI1PK { get => GSI1PK_DynamoDBItemType_Gen(); }
    
    [DynamoDbProperty("GSI1SK")]
    public string GSI1SK { get => GSI1SK_InterfaceType_Gen(Profession); }
    
    [DynamoDbProperty("DynamoDBItemType")]
    public string DynamoDBItemType { get => nameof(Person); }

    #endregion
    
    /// <summary>
    /// Name of the person
    /// </summary>
    [DynamoDbProperty("Name")]
    public string Name { get; set; }
    
    /// <summary>
    /// Profession of the person
    /// </summary>
    [DynamoDbProperty("Profession")]
    public string Profession { get; set; }
}