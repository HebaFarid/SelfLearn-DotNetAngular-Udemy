using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumesController : ControllerBase
    {
        private readonly IGenericRepository<Resume> _resumesRepo;
        private readonly IGenericRepository<ResumeCategory> _categoriesRepo;
        private readonly IMapper _mapper;
        
        public ResumesController(IGenericRepository<Resume> resumesRepo, IGenericRepository<ResumeCategory> categoriesRepo, IMapper mapper)
        {
            _mapper = mapper;
            _categoriesRepo = categoriesRepo;
            _resumesRepo = resumesRepo;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ResumeToReturnDto>>> GetResumes()
        {
            var spec = new ResumesWithCategoriesSpecification();
            var resumes = await _resumesRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Resume>, IReadOnlyList<ResumeToReturnDto>>(resumes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResumeToReturnDto>> GetResume(int id)
        {
            var spec = new ResumesWithCategoriesSpecification(id);
            var resume =  await _resumesRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Resume, ResumeToReturnDto>(resume);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ResumeCategory>>> GetResumesCategories()
        {
            return Ok(await _categoriesRepo.ListAllAsync());
        }
        
    }
}