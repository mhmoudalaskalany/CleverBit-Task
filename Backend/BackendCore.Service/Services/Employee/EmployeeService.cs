using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Base;
using BackendCore.Common.DTO.Employee;
using BackendCore.Common.DTO.Employee.Parameters;
using BackendCore.Service.Services.Base;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BackendCore.Service.Services.Employee
{
    public class EmployeeService : BaseService<Entities.Entities.Employee, AddEmployeeDto, EmployeeDto, int, int?>, IEmployeeService
    {
        #region Properties
        #endregion

        #region Constructors
        public EmployeeService(IServiceBaseParameter<Entities.Entities.Employee> parameters) : base(parameters)
        {

        }
        #endregion


        #region Public Methods

        public async Task<IResponseResult> GetByRegionIdAsync(int regionId)
        {
            var childRegionsIds = await UnitOfWork.GetRepository<Entities.Entities.Region>().FindSelectAsync(x => new
            {
                x.Id
            }, x => x.ParentRegionId == regionId);
            var regions = childRegionsIds.Select(x => x.Id).ToList();
            regions.Add(regionId);

            var employees = (await UnitOfWork.Repository.FindAsync(x => regions.Contains(x.RegionId) , 
                include:src => src.Include(r => r.Region))).ToList();
            var mapped = Mapper.Map<List<Entities.Entities.Employee>, List<EmployeeDto>>(employees);
            return new ResponseResult(mapped);
        }
        

        public async Task<DataPaging> GetAllPagedAsync(BaseParam<EmployeeFilter> filter)
        {

            var limit = filter.PageSize;
            var offset = ((--filter.PageNumber) * filter.PageSize);
            var query = await UnitOfWork.Repository.FindPagedAsync(predicate: PredicateBuilderFunction(filter.Filter), skip: offset, take: limit, filter.OrderByValue);
            var data = Mapper.Map<IEnumerable<Entities.Entities.Employee>, IEnumerable<EmployeeDto>>(query.Item2);
            return new DataPaging(++filter.PageNumber, filter.PageSize, query.Item1, result: data, status: HttpStatusCode.OK, HttpStatusCode.OK.ToString());

        }

        #endregion


        #region Private Methods
        
        static Expression<Func<Entities.Entities.Employee, bool>> PredicateBuilderFunction(EmployeeFilter filter)
        {
            var predicate = PredicateBuilder.New<Entities.Entities.Employee>(true);

            if (!string.IsNullOrWhiteSpace(filter?.Name))
            {
                predicate = predicate.And(b => b.FirstName.ToLower().Contains(filter.Name.ToLower())  
                                               || b.LastName.ToLower().Contains(filter.Name.ToLower()));
            }
           
            return predicate;
        }
        #endregion

    }
}
