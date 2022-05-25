using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace BackendCore.Service.Services.File
{
    public class FileService : IFileService
    {
        #region Private Fields

        private readonly IUnitOfWork<Entities.Entities.Region> _uow;

        #endregion

        #region Constructors

        public FileService(IUnitOfWork<Entities.Entities.Region> uow)
        {
            _uow = uow;
        }

        #endregion

        #region Public Methods

        public async Task<IFinalResult> UploadAsync(IFormFileCollection files)
        {
            if (files.Count > 2)
            {
                return new ResponseResult(false, HttpStatusCode.BadRequest, null, "Upload 2 Files Only");
            }
            List<Entities.Entities.Region> regions = new List<Entities.Entities.Region>();
            List<Entities.Entities.Employee> employees = new List<Entities.Entities.Employee>();

            ReadFiles(files, regions, employees);
            var filteredRegions = GetFilteredRegions(regions);
            AddRegions(filteredRegions);
            await _uow.SaveChangesAsync();
            AddEmployees(employees , filteredRegions);
            var rows = await _uow.SaveChangesAsync();
            return new ResponseResult();
        }


        #endregion

        #region Private Methods

        private void ReadFiles(IFormFileCollection files, List<Entities.Entities.Region> regions, List<Entities.Entities.Employee> employees)
        {
            foreach (var file in files)
            {
                using var streamReader = new StreamReader(file.OpenReadStream());
                var rows = streamReader.ReadLine()?.Split(',');
                var firstColumn = rows?[0];
                var parsed = int.TryParse(firstColumn, out _);
                if (parsed)
                {
                    CreateEmployeesEntities(streamReader, employees);
                }
                else
                {
                    CreateRegionsEntities(streamReader, regions);
                }

            }

        }

        private void CreateRegionsEntities(StreamReader streamReader, List<Entities.Entities.Region> regions)
        {
            while (!streamReader.EndOfStream)
            {
                var rows = streamReader.ReadLine()?.Split(',');
                var regionName = rows?[0];
                var isValidRegionId = int.TryParse(rows?[1], out int regionId);
                if (isValidRegionId)
                {
                    var region = new Entities.Entities.Region
                    {
                        Id = regionId,
                        Name = regionName
                    };

                    var result = int.TryParse(rows?[2], out int parentId);
                    if (result)
                    {
                        region.ParentRegionId = parentId;
                    }

                    regions.Add(region);
                }
                
            }
        }

        private void CreateEmployeesEntities(StreamReader streamReader, List<Entities.Entities.Employee> employees)
        {
            while (!streamReader.EndOfStream)
            {
                var rows = streamReader.ReadLine()?.Split(',');
                var regionId = int.Parse(rows?[0] ?? string.Empty);
                var firstName = rows?[1];
                var lastName = rows?[2];

                var employee = new Entities.Entities.Employee
                {
                    RegionId = regionId,
                    FirstName = firstName,
                    LastName = lastName
                };
                employees.Add(employee);

            }
        }

        private List<Entities.Entities.Region> GetFilteredRegions(List<Entities.Entities.Region> regions)
        {
            var grouped = regions.GroupBy(x => x.Id).ToList();
            var duplicated = grouped.Where(x => x.Count() > 1).Select(x => x.Key).ToList();
            //var filteredRegions = regions.Where(x => x.ParentRegionId != null && regions.Select(r => r.Id).ToList().Contains(x.ParentRegionId.Value)).ToList();
            var filteredRegions = regions.DistinctBy(e => e.Id).ToList();
            
            return filteredRegions; 
        }
        private void AddRegions(List<Entities.Entities.Region> regions)
        {
            _uow.Repository.AddRange(regions);
        }

        private void AddEmployees(List<Entities.Entities.Employee> employees , List<Entities.Entities.Region> regions)
        {
            employees = employees.Where(x => regions.Select(r => r.Id).ToList().Contains(x.RegionId)).ToList();
            _uow.GetRepository<Entities.Entities.Employee>().AddRange(employees);
        }



        #endregion

    }
}
