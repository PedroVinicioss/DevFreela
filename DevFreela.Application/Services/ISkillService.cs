using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services
{
    public interface ISkillService
    {
        ResultViewModel<List<Skill>> GetAll(string search = "", int page = 0, int size = 3);
        ResultViewModel<int> Insert(CreateSkillInputModel model);
    }

    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _context;
        public SkillService(DevFreelaDbContext context)
        {
            _context = context;
        }
        public ResultViewModel<List<Skill>> GetAll(string search = "", int page = 0, int size = 3)
        {
            var skills = _context.Skills
                .AsNoTracking()
                .Where(s => s.Description.Contains(search))
                .Skip(page * size)
                .Take(size)
                .ToList();

            return ResultViewModel<List<Skill>>.Success(skills);
        }

        public ResultViewModel<int> Insert(CreateSkillInputModel model)
        {
            var skill = new Skill(model.Description);

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(skill.Id);
        }
    }
}
