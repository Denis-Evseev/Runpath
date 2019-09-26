using Runpath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runpath.Services
{
    public interface ICalcService
    {
        List<Album> CombineAlbumsAndPhotos(List<Album> albums, List<Photo> photos);
    }
}
