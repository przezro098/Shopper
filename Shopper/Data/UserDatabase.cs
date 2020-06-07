using Shopper.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Data
{
    public class UserDatabase
    {
        static readonly Lazy<SQLiteConnection> lazyInitializer = new Lazy<SQLiteConnection>(() =>
        {
            return new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public UserDatabase()
        {
            InitializeAsync();
        }

        void InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(User).Name))
                {
                    Database.CreateTable<User>();
                    initialized = true;
                }
            }
        }

        public bool AddUser(User user)
        {
            var table = Database.Table<User>();
            if (table.Where(x => x.Email == user.Email).FirstOrDefault() != null)
            {
                return false;
                
            }
            else
            {
                Database.Insert(user);
                return true;
            }
        }

        public bool AreCredentialsValid(User user)
        {
            var table = Database.Table<User>();
            if (table.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault() == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
