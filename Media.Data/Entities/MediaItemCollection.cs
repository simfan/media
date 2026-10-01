using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class MediaItemCollection
    {
        public int MediaItemId { get; set; }
        public int CollectionId { get; set; }
        public MediaItem MediaItem { get; set; } = null!;
        public Collection Collection { get; set; } = null!;
    }
}
