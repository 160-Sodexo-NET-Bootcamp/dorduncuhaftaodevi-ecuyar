using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Mvc;
using ProcessMaker_Data.DataModel;
using ProcessMaker_Data.Randoms;
using ProcessMaker_Data.UoW;
using ProcessMakerWebAPI.Jobs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcessMakerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessMakerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProcessMakerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        //this can be wanted so I added
        //return all processes status == false and status == true
        [HttpGet("all")]
        public async Task<IActionResult> GetAllProcesses()
        {
            var allProcesses = await unitOfWork.Processes.GetAll();

            //convert model to dto
            List<ProcessDto> processes = mapper.Map<IEnumerable<Process_DataModel>, List<ProcessDto>>(allProcesses);

            return Ok(processes);
        }

        //return all processes that status == true
        [HttpGet("allActives")]
        public IActionResult GetAllActiveProcesses()
        {
            var allActiveProcesses = unitOfWork.Processes.Where(r => r.Status == true);

            //convert model to dto
            List<ProcessDto> processes = mapper.Map<IEnumerable<Process_DataModel>, List<ProcessDto>>(allActiveProcesses);

            return Ok(processes);
        }

        //we will start the adding job
        [HttpGet("startProcess")]
        public IActionResult StartRecurringProcess()
        {
            //this job have both methods: Insert process every 15 minute and 
            AddProcesses addProcess = new(unitOfWork);

            return Ok("Process is added. Note: Insert process works only at from 08:00 to 18:00. \nUpdate process works only at 18:00.");
        }
    }
}
