using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SiteParserApi.Data.Models;
using SiteParserApi.Data.Repositories.Abstract;
using SiteParserApi.Services;

namespace SiteParserApi.Data.Repositories.EntityFramework
{
    public class EFMediaRepository : IMediaRepository
    {
        private readonly AppDBContext _context;

        public EFMediaRepository(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Media> GetAllMedias() => _context.Medias.Include(c => c.MediaType);

        public Media GetMediaById(int id) => _context.Medias.Include(c => c.MediaType).FirstOrDefault(x => x.Id == id);

        public IEnumerable<Media> GetMediasByPostId(int id) => _context.Medias.Include(c => c.MediaType).Where(x => x.PostId == id);

        public int GetMediasCount() => _context.Medias.Count();

        public int GetMediasCountByPostId(int id) => _context.Medias.Where(x => x.PostId == id).Count();
    }
}
