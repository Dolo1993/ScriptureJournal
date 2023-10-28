using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_Scripture_App.Data;
using System;
using System.Linq;

namespace My_Scripture_App.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new My_Scripture_AppContext(
                serviceProvider.GetRequiredService<DbContextOptions<My_Scripture_AppContext>>()))
            {
                // Look for any scripture journal entries.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Book of Mormon",
                        Chapter = 1,
                        Verse = 1,
                        Text = "I, Nephi, having been born of goodly parents...",
                        DateAdded = DateTime.Parse("2023-10-20"),
                        Note = "This is the first verse of the Book of Mormon." 

                    }, 


                    new Scripture
                    {
                        Book = "Book of Mormon",
                        Chapter = 2,
                        Verse = 16,
                        Text = "And it came to pass that I, Nephi, being exceedingly...",
                        DateAdded = DateTime.Parse("2023-10-23"),
                        Note = "Nephi's vision of the tree of life."
                    },
                    new Scripture
                    {
                        Book = "Doctrine and Covenants",
                        Chapter = 88,
                        Verse = 118,
                        Text = "And as all have not faith, seek ye diligently...",
                        DateAdded = DateTime.Parse("2023-10-24"),
                        Note = "Counsel on seeking learning and knowledge."
                    }, 
                    new Scripture
                    {
                        Book = "Genesis",
                        Chapter = 1,
                        Verse = 1,
                        Text = "In the beginning, God created the heavens and the earth.",
                        DateAdded = DateTime.Parse("2023-10-26"),
                        Note = "The opening verse of the Bible."
                    },
                    new Scripture
                    {
                        Book = "Exodus",
                        Chapter = 20,
                        Verse = 3,
                        Text = "You shall have no other gods before me.",
                        DateAdded = DateTime.Parse("2023-10-27"),
                        Note = "One of the Ten Commandments given to Moses."
                    },
                    new Scripture
                    {
                        Book = "Matthew",
                        Chapter = 5,
                        Verse = 3,
                        Text = "Blessed are the poor in spirit, for theirs is the kingdom of heaven.",
                        DateAdded = DateTime.Parse("2023-10-28"),
                        Note = "One of the Beatitudes from the Sermon on the Mount."
                    },
                    new Scripture
                    {
                        Book = "John",
                        Chapter = 3,
                        Verse = 16,
                        Text = "For God so loved the world, that he gave his only Son...",
                        DateAdded = DateTime.Parse("2023-10-29"),
                        Note = "A well-known verse about God's love and salvation."
                    },

                    new Scripture
                    {
                        Book = "Doctrine and Covenants",
                        Chapter = 76,
                        Verse = 22,
                        Text = "And now, after the many testimonies...",
                        DateAdded = DateTime.Parse("2023-10-21"),
                        Note = "A significant revelation on the three degrees of glory."
                    },

                    new Scripture
                    {
                        Book = "Pearl of Great Price",
                        Chapter = 2,
                        Verse = 27,
                        Text = "Thus I, Abraham, talked with the Lord...",
                        DateAdded = DateTime.Parse("2023-10-22"),
                        Note = "Abraham's conversation with the Lord."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
