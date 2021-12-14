using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly ResumeContext _context;
        public ResumeRepository(ResumeContext context)
        {
            _context = context;
        }

        public async Task<Resume> GetResumeByIdAsync(int id)
        {
            return await _context.Resumes.Include(p => p.ResumeCategory).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Resume>> GetResumesAsync()
        {
            return await _context.Resumes.Include(p =>p.ResumeCategory).ToListAsync();
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _context.Jobs.Include(p => p.JobCategory).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Job>> GetJobsAsync()
        {
            return await _context.Jobs.Include(p => p.JobCategory).ToListAsync();
        }

        public async Task<IReadOnlyList<JobCategory>> GetJobsCategoriesAsync()
        {
            return await _context.JobCategories.ToListAsync();
        }

        public async Task<IReadOnlyList<ResumeCategory>> GetResumesCategoriesAsync()
        {
            return await _context.ResumeCategories.ToListAsync();
        }
    }
}