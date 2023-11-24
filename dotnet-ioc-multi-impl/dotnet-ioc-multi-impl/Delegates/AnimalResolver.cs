using dotnet_ioc_multi_impl.Interfaces;

namespace dotnet_ioc_multi_impl.Delegates;

/// <summary>
/// Animal resolver for clients
/// Injects the needed implementation of the IAnimal object
/// according to the given key which represents the class name
/// </summary>
public delegate IAnimal? AnimalResolver(string key); 