using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IResumeRepository
    {
        Task<Resume> GetResumeByIdAsync(int id);
        Task<IReadOnlyList<Resume>> GetResumesAsync();
        Task<Job> GetJobByIdAsync(int id);
        Task<IReadOnlyList<Job>> GetJobsAsync();
        Task<IReadOnlyList<JobCategory>> GetJobsCategoriesAsync();
        Task<IReadOnlyList<ResumeCategory>> GetResumesCategoriesAsync();
    }
}