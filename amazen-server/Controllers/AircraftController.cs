using Microsoft.AspNetCore.Mvc;
using amazen_server.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using amazen_server.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace amazen_server.Controllers
{

  [ApiController]
  [Route("api/[Controller]/{aircraftId}/duelist")]
  public class AircraftController : ControllerBase
  {
    private readonly AircraftService _acs;
    public AircraftController(AircraftService acs)
    {
      _acs = acs;
    }

    [HttpPost]
    public ActionResult<List<TaskDue>> Create(TaskDue[] newTasks)
    {
      List<TaskDue> tasks = new List<TaskDue>(newTasks);
      _acs.Create(newTasks);
      tasks.Sort((x, y) => DateTime.Compare(x.NextDue ?? DateTime.MaxValue, y.NextDue ?? DateTime.MaxValue));
      return Ok(tasks);
    }

  }
}