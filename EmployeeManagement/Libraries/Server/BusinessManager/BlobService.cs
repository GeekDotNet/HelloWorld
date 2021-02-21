using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EmployeeManagement.Common;
namespace EmployeeManagement.Server
{
    public class BlobService : IBlobService
    {
        public readonly BlobServiceClient _blobServiceClient;
        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public Task<Uri> GetEmployeeImageUrl(string employeeId, string blobContainerName)
        {
            throw new NotImplementedException();
        }

        public async Task<Uri> UploadEmployeeImageAsync(string blobContainerName, Stream content, string contentType, string filename)
        {
            var containerClient = GetContainerClient(blobContainerName);
            var blobClient = containerClient.GetBlobClient(filename);
            await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = "image/jpeg" });
            return blobClient.Uri;
        }

        private BlobContainerClient GetContainerClient(string blobContainerName)
        {
            var conatainerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
            conatainerClient.CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
            return conatainerClient;
        }
    }
}
