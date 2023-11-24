using dotnet_ioc_multi_impl.Delegates;
using dotnet_ioc_multi_impl.Interfaces;

namespace dotnet_ioc_multi_impl.Clients;

/// <summary>
/// A farmer which works with an animal
/// </summary>
public class Farmer
{
    private readonly IAnimal? _animal;
    
    public Farmer(AnimalResolver animalResolver)
    {
        _animal = animalResolver(this.GetType().Name); // Notifies the resolver that it is a farmer
    }

    /// <summary>
    /// Feeding the animal
    /// </summary>
    public void Work()
    {
        _animal?.Feed();
    }
}