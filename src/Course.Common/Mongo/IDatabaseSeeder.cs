using System.Threading.Tasks;

namespace Course.Common.Mongo
{
    public interface IDatabaseSeeder
    {
         Task SeedAsync();
    }
}