using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model
{
    public class DevGalleryInfo
    {
        public int DeveloperID { get; set; }
        public string PreviewImageSrc { get; set; }
        public string ThumbnailImageSrc { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
    }
}
