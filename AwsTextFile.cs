using Amazon.S3.Model;

namespace Siliconvalve.AwsS3Extension.Model
{
    public class AwsTextFile
    {
        public HeadersCollection Headers { get; set; }
        public string Content { get; set; }
    }
}