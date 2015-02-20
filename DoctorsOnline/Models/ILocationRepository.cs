using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DoctorsOnline.Models
{
    public interface ILocationRepository
    {
        IList<Division> GetAllDivisions();
        IList<District> GetAllDistrictsByDivisionId(int divisionId);
        IList<Thana> GetAllThanasByDistrictId(int districtId);
    }
}
