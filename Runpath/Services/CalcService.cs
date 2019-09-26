using Runpath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runpath.Services
{
    public class CalcService : ICalcService
    {
        public List<Album> CombineAlbumsAndPhotos(List<Album> albums, List<Photo> photos)
        {
            if (albums == null) return new List<Album>();
            if (photos == null) return albums;

            foreach (var album in albums)
                album.Photos = photos.Where(p => p.AlbumId == album.Id).ToList();

            return albums;
        }
    }
}
