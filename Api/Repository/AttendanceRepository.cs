using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _ctx;

        public AttendanceRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<AttendanceModel> GetAttendance(string ownerId, string id)
        {
            return await _ctx.Attendance.FirstOrDefaultAsync(x => x.Id == id && x.OwnerId == ownerId);
        }

        public async Task PostAttendance(AttendanceModel model)
        {
            await _ctx.Attendance.AddAsync(model);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<AttendanceModel>> GetAllAttendance(string ownerId)
        {
            return await _ctx.Attendance.Where(x => x.OwnerId == ownerId).ToListAsync();
        }
    }
}
