using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common
{
    public interface IBlobService
    {
        Task<Uri> UploadEmployeeImageAsync(string blobContainerName, Stream content, string contentType, string filename);
        Task<Uri> GetEmployeeImageUrl(string employeeId, string blobContainerName);
    }
}
