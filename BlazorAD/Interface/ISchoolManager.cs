using BlazorAD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAD.Interface
{
    public interface ISchoolManager
    {
            Task<int> Count(string search);
            Task<List<School>> ListAll(int skip, int take, string orderBy, string direction, string search);

            Task<List<School>> ListAllENV2(int skip, int take, string orderBy, string direction, string search);
        
    }
}
