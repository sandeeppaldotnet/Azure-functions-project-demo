using System;
using System.IO;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Drawing.Imaging;

namespace Blob_Trigger
{
    public class ImageThumbnailGenerator
    {
        [FunctionName("ImageThumbnailGenerator")]
        public static void Run(
          [BlobTrigger("images/{name}")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"Processing image: {name}");
            // Call the method to create a thumbnail
            CreateThumbnail(myBlob, name, log);
        }

        private static void CreateThumbnail(Stream imageStream, string name, ILogger log)
        {
            using (var image = System.Drawing.Image.FromStream(imageStream))
            {
                // Set the desired thumbnail size
                int thumbnailWidth = 100;
                int thumbnailHeight = 100;

                // Create a new bitmap with the thumbnail dimensions
                using (var thumbnail = new Bitmap(thumbnailWidth, thumbnailHeight))
                {
                    using (var graphics = Graphics.FromImage(thumbnail))
                    {
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                        // Draw the original image into the thumbnail
                        graphics.DrawImage(image, 0, 0, thumbnailWidth, thumbnailHeight);
                    }

                    // Save the thumbnail to a new blob (e.g., in a different container or with a modified name)
                    using (var memoryStream = new MemoryStream())
                    {
                        thumbnail.Save(memoryStream, ImageFormat.Jpeg);
                        // Reset stream position
                        memoryStream.Position = 0;

                        // Upload the thumbnail to Blob Storage
                        var thumbnailBlobName = $"thumbnails/{name}"; // Change the path as needed
                        var blobClient = new BlobServiceClient("UseDevelopmentStorage=true"); // For local use
                        var containerClient = blobClient.GetBlobContainerClient("thumbnails");
                        containerClient.CreateIfNotExists(); // Ensure the container exists

                        var blobClient1 = containerClient.GetBlobClient(thumbnailBlobName);
                        blobClient1.Upload(memoryStream, true);
                        log.LogInformation($"Thumbnail uploaded: {thumbnailBlobName}");
                    }
                }
            }
        }
    }
}
