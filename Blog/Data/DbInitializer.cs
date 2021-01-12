using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class DbInitializer
    {
        public static void Initialize(BlogpostContext context)
        {
            context.Database.EnsureCreated();

            if (context.Blogposts.Any())
            {
                return;
            }

            var blogposts = new List<Blogpost>
            {
                new Blogpost
                {
                    Author = "Admin",
                    Title = "Screaming Architecture",
                    DateTime = new DateTime(2020, 12, 30, 08, 05, 00),
                    Text = "Imagine that you are looking at the blueprints of a building. This document, prepared " +
                           "by an architect, tells you the plans for the building. What do these plans tell you? " +
                           "If the plans you are looking at are for a single family residence, then you’ll likely " +
                           "see a front entrance, a foyer leading to a living room and perhaps a dining room. " +
                           "There’ll likely be a kitchen a short distance away, close to the dining room. Perhaps a " +
                           "dinette area next to the kitchen, and probably a family room close to that. As you " +
                           "looked at those plans, there’d be no question that you were looking at a house. The " +
                           "architecture would scream: house."
                },
                new Blogpost
                {
                    Author = "Admin",
                    Title = "The Theme of an Architecture",
                    DateTime = new DateTime(2020, 08, 14, 12, 15, 00),
                    Text = "Go back and read Ivar Jacobson’s seminal work on software architecture: Object Oriented " +
                           "Software Engineering. Notice the subtitle of the book: A use case driven approach. In " +
                           "this book Ivar makes the point that software architectures are structures that support " +
                           "the use cases of the system. Just as the plans for a house or a library scream about " +
                           "the use cases of those buildings, so should the architecture of a software application " +
                           "scream about the use cases of the application. Architectures are not (or should not) be " +
                           "about frameworks. Architectures should not be supplied by frameworks. Frameworks are " +
                           "tools to be used, not architectures to be conformed to. If your architecture is based " +
                           "on frameworks, then it cannot be based on your use cases."
                },
                new Blogpost
                {
                    Author = "Admin",
                    Title = "The Purpose of an Architecture",
                    DateTime = new DateTime(2021, 01, 07, 12, 44, 00),
                    Text = "The reason that good architectures are centered around use-cases is so that architects " +
                           "can safely describe the structures that support those use-cases without committing to " +
                           "frameworks, tools, and environment. Again, consider the plans for a house. The first " +
                           "concern of the architect is to make sure that the house is usable, it is not to ensure " +
                           "that the house is made of bricks. Indeed, the architect takes pains to ensure that the " +
                           "homeowner can decide about bricks, stone, or cedar later, after the plans ensure that " +
                           "the use cases are met."
                },
                new Blogpost
                {
                    Author = "Admin",
                    Title = "But what about the Web?",
                    DateTime = new DateTime(2017, 08, 14, 11, 02, 00),
                    Text = "Is the web an architecture? Does the fact that your system is delivered on the web " +
                           "dictate the architecture of your system? Of course not! The Web is a delivery " +
                           "mechanism, and your application architecture should treat it as such. The fact that " +
                           "your application is delivered over the web is a detail and should not dominate your " +
                           "system structure. Indeed, the fact that your application is delivered over the web is " +
                           "something you should defer. Your system architecture should be as ignorant as possible " +
                           "about how it is to be delivered. You should be able to deliver it as a console app, or " +
                           "a web app, or a thick client app, or even a web service app, without undue complication " +
                           "or change to the fundamental architecture."
                }
            };

            context.Blogposts.AddRange(blogposts);
            context.SaveChanges();
        }
    }
}
