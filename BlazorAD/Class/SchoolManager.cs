using BlazorAD.Interface;
using BlazorAD.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BlazorAD.Class
{
    public class SchoolManager : ISchoolManager
    {
        private readonly IDapperManager _dapperManager;

        public SchoolManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public Task<int> Count(string search)
        {
            var totSchool= Task.FromResult(_dapperManager.Get<int>($"select COUNT(*) from [Schools] WHERE SchoolName like '%{search}%'", null,
                    commandType: CommandType.Text));
            return totSchool;
        }

        public Task<List<School>> ListAll(int skip, int take, string orderBy, string direction = "DESC", string search = "")
        {
            var articles = Task.FromResult(_dapperManager.GetAll<School>
                ($"SELECT * FROM [Schools] WHERE SchoolName like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return articles;
        }

        public Task<List<School>> ListAllENV2(int skip, int take, string orderBy, string direction = "DESC", string search = "")
        {
            var articles = Task.FromResult(_dapperManager.GetAllENV2<School>
                ($"SELECT * FROM [Schools] WHERE SchoolName like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return articles;
        }
    }
}

