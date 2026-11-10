using Medias.Data.Entities;
using Medias.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Conversions
{
    public static class BookConversions
    {
        public static BookDto ToBookDto(BookDetail bookDetail)
        {
            if (bookDetail == null)
            {
                return null;
            }
            return new BookDto
            {
                Id = bookDetail.MediaItemId,
                Pages = bookDetail.Pages,
                Genre = bookDetail.Genre,
                Author = bookDetail.Author,
                TimeToRead = bookDetail.TimeToRead,
                ISBN = bookDetail.ISBN,
                OpenLibraryId = bookDetail.OpenLibraryId
            };
        }
        
    }
}
