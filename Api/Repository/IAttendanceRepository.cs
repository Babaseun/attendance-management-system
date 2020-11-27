using Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repository
{
    public interface IAttendanceRepository
    {
        Task<AttendanceModel> GetAttendance(string ownerId, string id);
        Task PostAttendance(AttendanceModel model);
        Task<List<AttendanceModel>> GetAllAttendance(string ownerId);
    }
}
