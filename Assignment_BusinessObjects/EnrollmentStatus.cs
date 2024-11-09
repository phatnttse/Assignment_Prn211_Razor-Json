using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_BusinessObjects
{
    public enum EnrollmentStatus
    {
        Pending,    // Đang chờ xử lý
        Approved,   // Đã được chấp nhận
        Rejected,   // Bị từ chối
        Completed,  // Đã hoàn thành
        Cancelled   // Đã hủy
    }
}
