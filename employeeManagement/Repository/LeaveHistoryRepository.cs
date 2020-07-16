using employeeManagement.Contracts;
using employeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeManagement.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveRequest entity)
        {
            _db.LeaveRequests.Add(entity);

            return Save();
        }

        public bool Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);

            return Save();
        }

        public ICollection<LeaveRequest> FindAll()
        {
            var leaveHistories = _db.LeaveRequests.ToList();

            return leaveHistories;
        }

        public LeaveRequest FindById(int id)
        {
            var leaveHistory = _db.LeaveRequests.Find(id);

            return leaveHistory;
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveRequests.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);

            return Save();
        }
    }
}
