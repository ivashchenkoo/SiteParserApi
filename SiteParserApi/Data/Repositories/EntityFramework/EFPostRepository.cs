﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiteParserApi.Data.Models;
using SiteParserApi.Data.Repositories.Abstract;
using SiteParserApi.Services;

namespace SiteParserApi.Data.Repositories.EntityFramework
{
    public class EFPostRepository : IPostRepository
    {
        private readonly AppDBContext _context;

        public EFPostRepository(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAllPosts() => _context.Posts.Include(c => c.Medias).ThenInclude(c => c.MediaType);

        public Post GetPostById(int id) => _context.Posts.Include(c => c.Medias).ThenInclude(c => c.MediaType).FirstOrDefault(x => x.Id == id);

        public IEnumerable<Post> GetPostsBySource(string source) => _context.Posts.Include(c => c.Medias).ThenInclude(c => c.MediaType).Where(x => x.Source == source);

        public int GetPostsCount() => _context.Posts.Count();

        public Task SaveEntity(Post entity)
        {
            _context.Posts.Add(entity);
            return _context.SaveChangesAsync();
        }
    }
}