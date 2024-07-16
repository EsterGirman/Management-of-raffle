using AutoMapper;
using FinalProject.BLL;
using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{   
        [ApiController]
        [Route("api/[controller]")]
    public class CategoryController : ControllerBase
        {
            public readonly IMapper mapper;
            public readonly ICategoryService Category;
            public CategoryController(ICategoryService Category, IMapper mapper)
            {
                this.Category = Category;
                this.mapper = mapper;
            }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<CategoryDTO>> getAllCategorys()
        {
            List<Category>gg= await Category.getAllCategories();
            return mapper.Map<List<CategoryDTO>>(gg);
        }

        [HttpGet("{id}")]
        public async Task<CategoryDTO> getCategoryById(int id)
        {

            Category gg= await Category.getCategoryById(id);
            return mapper.Map<CategoryDTO>(gg);
        }

        
        [HttpPost]
       // [Authorize(Roles = "Manager")]
        public async Task<CategoryDTO> Add(CategoryDTO CategoryDTO)
        {
            Category C = mapper.Map<Category>(CategoryDTO);
            Category C3= await Category.Add(C);
            return mapper.Map<CategoryDTO>(C3);

            }

        [HttpDelete]
       // [Authorize(Roles = "Manager")]
        public async Task<CategoryDTO> deleteCategories(int id)
        {
            Category C=  await Category.deleteCategories(id);
            return mapper.Map<CategoryDTO>(C);

        }

        [HttpPut]
      //  [Authorize(Roles = "Manager")]
        public async Task<CategoryDTO> Update(CategoryDTO CategoryDTO, int id)
            {
                Category c = mapper.Map<Category>(CategoryDTO);
            Category cate=await Category.updateCategory(id, c);
            return mapper.Map<CategoryDTO>(cate);
        }
    }
    }

