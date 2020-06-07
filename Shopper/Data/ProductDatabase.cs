using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopper.Models;
using SQLite;

namespace Shopper

{
    public class ProductDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ProductDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Product).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Product)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<Product>> GetItemsAsync()
        {
            return Database.Table<Product>().ToListAsync();
        }

        public Task<List<Product>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Product>("SELECT * FROM [Product] WHERE [Bought] = 0");
        }

        public Task<Product> GetItemAsync(int id)
        {
            return Database.Table<Product>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Product product)
        {
            if (product.ID != 0)
            {
                return Database.UpdateAsync(product);
            }
            else
            {
                return Database.InsertAsync(product);
            }
        }

        public Task<int> DeleteItemAsync(Product product)
        {
            return Database.DeleteAsync(product);
        }
    }
}

