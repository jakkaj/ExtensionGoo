using System.Collections.Generic;

namespace ExtensionGoo.Tests.Entity
{
    public class VisionResponse
    {
        public Adult adult { get; set; }
        public List<Tag> tags { get; set; }
        public Description description { get; set; }
        public string requestId { get; set; }
        public Metadata metadata { get; set; }
        public List<object> faces { get; set; }
        public Color color { get; set; }
        public ImageType imageType { get; set; }
    }
}