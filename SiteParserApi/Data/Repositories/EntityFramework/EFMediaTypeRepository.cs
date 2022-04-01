using System.Collections.Generic;
using System.Linq;
using SiteParserApi.Data.Models;
using SiteParserApi.Data.Repositories.Abstract;
using SiteParserApi.Services;

namespace SiteParserApi.Data.Repositories.EntityFramework
{
    public class EFMediaTypeRepository : IMediaTypeRepository
    {
        private readonly AppDBContext _context;

        public EFMediaTypeRepository(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<MediaType> GetAllMediaTypes() => _context.MediaType;

        public MediaType GetMediaTypeById(int id) => _context.MediaType.FirstOrDefault(x => x.Id == id);

        public int GetMediaTypesCount() => _context.MediaType.Count();
    }
}
