using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class Collection
    {
        public int CollectionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<MediaItemCollection> MediaItemCollections { get; set; }
    }
}
