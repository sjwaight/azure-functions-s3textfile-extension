using Siliconvalve.AwsS3Extension;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(S3TextFileBindingStartup))]
namespace Siliconvalve.AwsS3Extension
{
    public class S3TextFileBindingStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddMyFileReaderBinding();
        }
    }
}