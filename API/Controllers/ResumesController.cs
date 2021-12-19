using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ResumesController : BaseApiController
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResumeToReturnDto>> GetResume(int id)
        {
            var spec = new ResumesWithCategoriesSpecification(id);
            var resume =  await _resumesRepo.GetEntityWithSpec(spec);

            if(resume == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Resume, ResumeToReturnDto>(resume);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ResumeCategory>>> GetResumesCategories()
        {
            return Ok(await _categoriesRepo.ListAllAsync());
        }
        
    }
}