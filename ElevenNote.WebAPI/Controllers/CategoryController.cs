using ElevenNote.Models;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        //create instance of Category Service (liek creating an instance of our repository from console apps
        private CategoryService CreateCategoryService()
        {
            var categoryService = new CategoryService();
            return categoryService;
        }

        //get all categories
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var cate = categoryService.GetAllCategories();
            return Ok(cate);
        }

        //post/create new category - posting a new object to the table
        public IHttpActionResult Post(CategoryCreate cate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCategoryService();

            if (!service.CreateCategory(cate))
            {
                return InternalServerError();
            }

            return Ok();
        }

        //Put/Update - change name of categories
        public IHttpActionResult Put(CategoryEdit cate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCategoryService();

            if (!service.UpdateCategory(cate))
            {
                return InternalServerError();
            }

            return Ok();
        }

        //Delete - remove a category via the Id from the Category table
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();

            if (!service.DeleteCategory(id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
