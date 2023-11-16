# InjectableServices

1. Add `Injectable` attribute to your service

   ```cs
   using InjectableServices;

   // The attribute
   [Injectable(ServiceLifetime.Scoped)]
   public class ItemService : IItemService
   {
       private DataContext Context { get; }

       public ItemService(DataContext dataContext)
       {
           Context = dataContext;
       }

       public Item[] GetAllItems()
       {
           return Context.Items.ToArray();
       }
   }
   ```

1. Easily register injectable services

   ```cs
   using InjectableServices;

   var builder = WebApplication.CreateBuilder(args);

   // The services registration
   builder.Services.AddInjectableServices();

   var app = builder.Build();
   ```
