using Microsoft.Azure.WebJobs;
using System;

namespace Siliconvalve.AwsS3Extension
{
    public static class S3TextFileBindingExtension
    {
        public static IWebJobsBuilder AddMyFileReaderBinding(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<S3TextFileBinding>();
            return builder;
        }
    }
}