using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class JobsController : BaseApiController
    {
        private readonly IGenericRepository<Job> _jobsRepo;
        private readonly IGenericRepository<JobCategory> _categoriesRepo;
        private readonly IMapper _mapper;
        
        public JobsController(IGenericRepository<Job> jobsRepo, IGenericRepository<JobCategory> categoriesRepo, IMapper mapper)
        {
            _mapper = mapper;
            _categoriesRepo = categoriesRepo;
            _jobsRepo = jobsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<JobToReturnDto>>> GetJobs([FromQuery]JobsSpecParams jobParams)
        {
            var spec = new JobsWithCategoriesSpecification(jobParams);
            var countSpec = new JobWithFiltersForCountSpecification(jobParams);
            var totalCount = await _jobsRepo.CountAsync(countSpec);
            var jobs = await _jobsRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Job>, IReadOnlyList<JobToReturnDto>>(jobs);

            return Ok(new Pagination<JobToReturnDto>(jobParams.PageIndex, jobParams.PageSize, totalCount, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JobToReturnDto>> GetJob(int id)
        {
            var spec = new JobsWithCategoriesSpecification(id);

            var job = await _jobsRepo.GetEntityWithSpec(spec);

            if(job == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Job, JobToReturnDto>(job);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<Job>>> GetJobCategories()
        {
            return Ok(await _categoriesRepo.ListAllAsync());
        }
    }
}