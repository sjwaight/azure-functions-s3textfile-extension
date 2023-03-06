using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Siliconvalve.AwsS3Extension.Model;

namespace Siliconvalve.AwsS3Extension
{
    [Extension("S3TextFileBinding")]
    public class S3TextFileBinding : IExtensionConfigProvider
    {
        private static IAmazonS3 client;

        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<S3TextFileAttribute>();
            rule.BindToInput<AwsTextFile>(BuildItemFromAttribute);
        }

        private AwsTextFile BuildItemFromAttribute(S3TextFileAttribute arg)
        {
            return ReadAwsTextFile(arg).Result;
        }

        private async Task<AwsTextFile> ReadAwsTextFile(S3TextFileAttribute arg)
        {
            var result = new AwsTextFile();

            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = arg.BucketName,
                Key = arg.FileKeyName
            };

            client = new AmazonS3Client(RegionEndpoint.GetBySystemName(arg.AwsRegionName));

            using (GetObjectResponse response = await client.GetObjectAsync(request))
            using (Stream responseStream = response.ResponseStream)
            using (StreamReader reader = new StreamReader(responseStream))
            {
                string contentType = response.Headers["Content-Type"];
                //log.LogInformation("Content type: {0}", contentType);

                result.Headers = response.Headers;
                result.Content = reader.ReadToEnd();
            }

            return result;
        }

    }
}