using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIandAngularJSSample.Models;

namespace WebAPIandAngularJSSample.Controllers
{
    public class BlogsController : ApiController
    {
        private WebAPIandAngularJSSampleContext db = new WebAPIandAngularJSSampleContext();

        // GET api/Blogs
        public IQueryable<Blog> GetBlogs()
        {
            return db.Blogs;
        }

        // GET api/Blogs/5
        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> GetBlog(int id)
        {
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        // PUT api/Blogs/5
        public async Task<IHttpActionResult> PutBlog(int id, Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blog.Id)
            {
                return BadRequest();
            }

            db.Entry(blog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Blogs
        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> PostBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Blogs.Add(blog);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = blog.Id }, blog);
        }

        // DELETE api/Blogs/5
        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> DeleteBlog(int id)
        {
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            db.Blogs.Remove(blog);
            await db.SaveChangesAsync();

            return Ok(blog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogExists(int id)
        {
            return db.Blogs.Count(e => e.Id == id) > 0;
        }
    }
}