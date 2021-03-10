using amazen_server.Models;
// using amazen_server.DB;
using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amazen_server.Repositories
{
  public class AircraftRepository
  {
    public List<Plane> GetPlanes()
    {
      List<Plane> planes = new List<Plane>();
      planes.Add(new Plane() { AircraftId = 1, DailyHours = .7, CurrentHours = 550 });
      planes.Add(new Plane() { AircraftId = 2, DailyHours = 1.1, CurrentHours = 200 });
      return planes;
    }

  }


}