using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IResumeRepository _repo;
        public JobsController(IResumeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Job>>> GetJobs()
        {
            var jobs = await _repo.GetJobsAsync();

            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            return await _repo.GetJobByIdAsync(id);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<Job>>> GetJobCategories()
        {
            return Ok(await _repo.GetJobsCategoriesAsync());
        }
    }
}