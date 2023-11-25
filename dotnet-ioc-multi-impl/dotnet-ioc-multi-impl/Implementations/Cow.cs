using dotnet_ioc_multi_impl.Interfaces;

namespace dotnet_ioc_multi_impl.Implementations;

/// <summary>
/// IAnimal implementation
/// </summary>
public class Cow : IAnimal
{
    public void Feed()
    {
        Console.WriteLine($"Feed Cow");
    }
}