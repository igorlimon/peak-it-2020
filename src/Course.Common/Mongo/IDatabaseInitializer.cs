using System.Threading.Tasks;

namespace Course.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}