using System;
using Microsoft.Azure.WebJobs.Description;

namespace Siliconvalve.AwsS3Extension
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public sealed class S3TextFileAttribute : Attribute
    {
        [AutoResolve]
        public string BucketName {get; set;}

        [AutoResolve]
        public string FileKeyName {get; set;}

        [AutoResolve]
        public string AwsRegionName {get; set;}
    }
}
