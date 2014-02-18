using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPIandAngularJSSample.Models
{
    public class WebAPIandAngularJSSampleContextInitializer : DropCreateDatabaseAlways<WebAPIandAngularJSSampleContext>
    {
        protected override void Seed(WebAPIandAngularJSSampleContext context)
        {
            Blog blog1 = new Blog();
            blog1.Title = "Introducing Helios";
            blog1.Description = "In late 2013 we made available a prerelease NuGet package which allows running a managed web application directly on top of IIS without going through the normal ASP.NET (System.Web) request processing pipeline. This was a relatively quiet event without too much fanfare. At last month’s MVA Windows Azure Deep Dive, we spoke about this for the first time publicly to a global audience";

            Blog blog2 = new Blog();
            blog2.Title = "Supplemental to ASP.NET Project “Helios”";
            blog2.Description = "This is a supplemental document to my earlier Introducing ASP.NET Project 'Helios' post.  It contains extra information that might be of interest to the advanced developer but which didn’t make it into the main post.  I encourage reading the original post before continuing";

            context.Blogs.Add(blog1);
            context.Blogs.Add(blog2);

            context.SaveChanges();
        }
    }
}