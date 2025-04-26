using DevFreela.Application.Models;
using DevFreela.Core.Entities;
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
}
