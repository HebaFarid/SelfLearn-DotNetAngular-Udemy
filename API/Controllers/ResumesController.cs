using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumesController : ControllerBase
    {
        private readonly IResumeRepository _repo;
        public ResumesController(IResumeRepository repo)
        {
            _repo = repo;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Resume>>> GetResumes()
        {
            var resumes = await _repo.GetResumesAsync();

            return Ok(resumes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resume>> GetResume(int id)
        {
            return await _repo.GetResumeByIdAsync(id);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ResumeCategory>>> GetResumesCategories()
        {
            return Ok(await _repo.GetResumesCategoriesAsync());
        }
        
    }
}