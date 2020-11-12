using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        
        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Gets
        public IEnumerable<CategoryListItem> GetAllCategories()
        {
            using (var ctx = new ApplicationDbContext())//New up DbContext for creating a table for categories
            {
                var query = ctx
                    .Categories
                    .Select
                    (e => new CategoryListItem
                    {
                        CategoryId = e.CategoryId,
                        Name = e.Name
                    }
                    );
                return query.ToArray();
            }
        }

        //Update
        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Categories.Single(e => e.CategoryId == model.CategoryId);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteCategory(int categoryId)//New method, passing in catId of type int
        {
            using(var ctx = new ApplicationDbContext())//varibale that has access to Categories table
            {
                var entity =
                    ctx.Categories
                    .Single(e => e.CategoryId == categoryId);//if variable Id is equal to id passed in, set equal to new variable

                ctx.Categories.Remove(entity);//remove that category from the table

                return ctx.SaveChanges() == 1;//return the bool of true(or 1) and save the table
            }
        }
    }
}
