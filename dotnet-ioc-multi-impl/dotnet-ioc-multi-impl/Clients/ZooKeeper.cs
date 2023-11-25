using dotnet_ioc_multi_impl.Delegates;
using dotnet_ioc_multi_impl.Interfaces;

namespace dotnet_ioc_multi_impl.Clients;

/// <summary>
/// A zookeeper which works with an animal
/// </summary>
public class ZooKeeper
{
    private readonly IAnimal? _animal;
    
    public ZooKeeper(AnimalResolver animalResolver)
    {
        _animal = animalResolver(this.GetType().Name); // Notifies the resolver that it is a zooKeeper
    }

    /// <summary>
    /// Feeding the animal
    /// </summary>
    public void Work()
    {
        _animal?.Feed();
    }
}