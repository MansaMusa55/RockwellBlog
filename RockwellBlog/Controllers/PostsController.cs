using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RockwellBlog.Data;
using RockwellBlog.Models;
using RockwellBlog.Services;
using X.PagedList;

namespace RockwellBlog.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBlogFileService _fileService;
        private readonly IConfiguration _configuration;
        private readonly BasicSlugService _slugService;
        private readonly SearchService _searchService;

        public PostsController(ApplicationDbContext context, IBlogFileService fileService, IConfiguration configuration, BasicSlugService slugService, SearchService searchService)
        {
            _context = context;
            _fileService = fileService;
            _configuration = configuration;
            _slugService = slugService;
            _searchService = searchService;
        }
        [AllowAnonymous]
        public async Task<ActionResult> BlogPostIndex(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = _context.Blog.Find(id);
            var blogPosts = await _context.Posts.Where(p => p.BlogId == id).ToListAsync();

            ViewData["HeaderText"] = blog.Name;
            ViewData["SubText"] = blog.Description;
            ViewData["HeaderImage"] = _fileService.DecodeImage(blog.ImageData, blog.ContentType);

            return View(blogPosts);
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            ViewData["HeaderText"] = "The Post Index";
            ViewData["SubText"] = "Read all my Posts!";

            var applicationDbContext = _context.Posts.Include(p => p.Blog);
            return View(await applicationDbContext.ToListAsync());
        }



        [AllowAnonymous]
        // GET: Posts/Details/5
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Blog)
                .Include(p => p.Comments)
                .ThenInclude(c => c.Author)
                .FirstOrDefaultAsync(m => m.Slug == slug);

            if (post == null)
            {
                return NotFound();
            }


            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["BlogId"] = new SelectList(_context.Blog, "Id", "Description");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchIndex(int? page, string searchString)
        {
            ViewData["SearchString"] = searchString;
            //Step 1: I need a set of results stemming from this search string
            var posts = _searchService.SearchContent(searchString);

            var pageNumber = page ?? 1;
            var pageSize = 2;

            return View("Index", await posts.ToPagedListAsync(pageNumber, pageSize));
        }


        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,Title,Abstract,Content,PublishState,ImageFile")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Created = DateTime.Now;

                post.ImageData = (await _fileService.EncodeFileAsync(post.ImageFile)) ??
                  await _fileService.EncodeFileAsync(_configuration["DefaultPostImage"]);

                post.ContentType = post.ImageFile is null ?
                                    _configuration["DefaultPostImage"].Split('.')[1] :
                                    _fileService.ContentType(post.ImageFile);

                var slug = _slugService.UrlFriendly(post.Title);
                if (!_slugService.IsUnique(slug))
                {
                    ModelState.AddModelError("Title", "There is an issue with a Title");
                    ModelState.AddModelError("", "Where does this thing show up");
                    return View(post);
                }
                post.Slug = slug;
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction("BlogPostIndex", new { id = post.BlogId });

            }
            ViewData["BlogId"] = new SelectList(_context.Blog, "Id", "Description", post.BlogId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = new SelectList(_context.Blog, "Id", "Description", post.BlogId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BlogId,Created,Slug,Title,Abstract,Content,PublishState")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var newSlug = _slugService.UrlFriendly(post.Title);
                    //I need to compare the original slug with the curretn slug
                    if(post.Slug != _slugService.UrlFriendly(post.Title))
                    {
                        if (!_slugService.IsUnique(newSlug))
                        {
                            ModelState.AddModelError("Title", "There is an Issue witht the Title.");
                            return View(post);
                        }
                       

                        post.Slug = newSlug;
                    }

                    if(post.ImageFile is not null)
                    {
                        post.ImageData = await _fileService.EncodeFileAsync(post.ImageFile);
                        post.ContentType = _fileService.ContentType(post.ImageFile);
                    }

                    post.Updated = DateTime.Now;


                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogId"] = new SelectList(_context.Blog, "Id", "Description", post.BlogId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Blog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
