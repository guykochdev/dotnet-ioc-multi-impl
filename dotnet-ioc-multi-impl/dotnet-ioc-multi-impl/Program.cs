using Microsoft.Extensions.DependencyInjection;
using dotnet_ioc_multi_impl.Implementations;
using dotnet_ioc_multi_impl.Clients;
using dotnet_ioc_multi_impl.Delegates;

#region IOC container
ServiceCollection serviceCollection  = new ServiceCollection();

serviceCollection.AddTransient<Cow>();
serviceCollection.AddTransient<Lion>();
serviceCollection.AddTransient<Farmer>();
serviceCollection.AddTransient<ZooKeeper>();
// Animal Resolver Injection by cases
// The resolver is injected to the clients ( ZooKeeper / Farmer )
// and the object can ask the resolver for the instance it requires according to its type.
// Notice that if we want to change the implementation for a client,
// this is the only place we need to change it in
serviceCollection.AddTransient<AnimalResolver>(serviceProvider => key =>
{
    return key switch
    {
        "Farmer" => serviceProvider.GetService<Cow>(), // if the object is a farmer - gets a cow
        "ZooKeeper" => serviceProvider.GetService<Lion>(), // if the object is a zookeeper - gets a lion
        _ => null
    };
});
ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
#endregion

#region Application Logic
// Clients initialization
Farmer farmer = serviceProvider.GetRequiredService<Farmer>(); // Creates a Farmer instance
farmer.Work(); // Prints "Feed Cow"

ZooKeeper zooKeeper = serviceProvider.GetRequiredService<ZooKeeper>(); // Creates a ZooKeeper Instance
zooKeeper.Work(); // Prints "Feed Lion"
#endregion


