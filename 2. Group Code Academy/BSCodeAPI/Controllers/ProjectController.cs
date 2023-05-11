using BSCodeAPI.Services;
using BSCodeAPI.Services.Interface;
using BSCodeModels_Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            this._projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }

        // GET: api/<ValuesController>
        [HttpGet("GetAllProject")]
        public List<Project> Get()
        {
            return _projectService.Get();
        }

        // GET api/<ValuesController>/5
        [HttpGet("GetProject/{id}")]
        public Project Get(Guid id)
        {
            return _projectService.Get(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("UpdateProject")]
        public Project Update([FromBody] Project project)
        {
            return _projectService.Update(project);
        }

        // POST api/<ValuesController>
        [HttpPost("AddProject")]
        public bool Add([FromBody] Project project)
        {
            return _projectService.Add(project);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("DeleteProject/{id}")]
        public bool Delete(Guid id)
        {
            return _projectService.Delete(id);
        }
    }
}
