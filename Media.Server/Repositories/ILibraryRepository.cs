using Medias.Data.Entities;
using Medias.Shared;
using System.Linq.Expressions;

namespace Medias.Server.Repositories
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Library>> GetLibraries();
    
    }
}
