using RockwellBlog.Data;
using RockwellBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockwellBlog.Enums;

namespace RockwellBlog.Services
{
    public class SearchService
    {
        private readonly ApplicationDbContext _context;

        public SearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IOrderedQueryable<Post> SearchContent(string searchString)
        {
            //Step1: GEt an Iqueryable that contains all the Posts
            //the user does not supply a serach string
            var result = _context.Posts.Where(p => p.PublishState == PublishState.ProductionReady);

            if (!string.IsNullOrEmpty(searchString))
            {

                result = result.Where(p => p.Title.Contains(searchString) ||
                                           p.Abstract.Contains(searchString) ||
                                           p.Content.Contains(searchString) ||
                                           p.Comments.Any(c => c.Body.Contains(searchString) ||
                                                               c.ModeratedBody.Contains(searchString) ||
                                                               c.Author.FirstName.Contains(searchString) ||
                                                               c.Author.LastName.Contains(searchString) ||
                                                               c.Author.Email.Contains(searchString)));
            }
            return result.OrderByDescending(p => p.Created);


        }
    }
}
