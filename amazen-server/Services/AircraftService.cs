using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amazen_server.Models;
using amazen_server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace amazen_server.Services
{
  public class AircraftService
  {
    private readonly AircraftRepository _repo;
    public AircraftService(AircraftRepository repo)
    {
      _repo = repo;
    }

    public ActionResult<List<TaskDue>> Create(TaskDue[] newTasks)
    {

      List<TaskDue> tasks = new List<TaskDue>();
      List<Plane> planes = _repo.GetPlanes();


      foreach (TaskDue task in newTasks)
      {
        Plane plane = planes.Find(p => p.AircraftId == task.PlaneId);
        DateTime logDate = DateTime.Parse(task.LogDate);
        double? DaysRemainingByHoursInterval;
        DateTime? IntervalHoursNextDueDate = null;
        DateTime? IntervalMonthsNextDueDate = null;
        var today = DateTime.Parse("2018-06-19T00:00:00");

        if (task.IntervalMonths != null && task.LogDate != null)
        {
          IntervalMonthsNextDueDate = logDate.AddMonths((int)task.IntervalMonths);
        }

        if (task.LogHours != null && task.IntervalHours != null)
        {
          DaysRemainingByHoursInterval = (((task.LogHours + task.IntervalHours) - plane.CurrentHours) / plane.DailyHours);
          IntervalHoursNextDueDate = today.AddDays((double)DaysRemainingByHoursInterval);
        }

        if (IntervalHoursNextDueDate <= IntervalMonthsNextDueDate || IntervalMonthsNextDueDate == null)
        {
          task.NextDue = IntervalHoursNextDueDate;
        }
        else
        {
          task.NextDue = IntervalMonthsNextDueDate;
        }


        tasks.Add(task);

      }

      tasks.Sort((x, y) => DateTime.Compare(x.NextDue ?? DateTime.MaxValue, y.NextDue ?? DateTime.MaxValue));
      return tasks;

    }
  }

}