using dotnet_ioc_multi_impl.Interfaces;

namespace dotnet_ioc_multi_impl.Implementations;

/// <summary>
/// IAnimal implementation
/// </summary>
public class Lion : IAnimal
{
    public void Feed()
    {
        Console.WriteLine($"Feed Lion");
    }
}