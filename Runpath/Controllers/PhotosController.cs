using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Runpath.Helpers;
using Runpath.Models;
using Runpath.Processors;

namespace Runpath.Controllers
{
    [Route("api/[controller]")]
    public class PhotosController : Controller
    {
        private IRequestProcessor RequestProcessor;
        public PhotosController()
        {
            RequestProcessor = new RequestProcessor();
        }

        [HttpGet("[action]/{id}")]
        public IEnumerable<Photo> GetPhotosByAlbumId(int id)
        {
            var requestUrl = $"{ApiHelper.base_url}/photos?albumId=" + id;
            var photos = RequestProcessor.Process<List<Photo>>(requestUrl);

            return photos;
        }

        [HttpGet("[action]")]
        public IEnumerable<Photo> GetPhotos(int id)
        {
            var requestUrl = $"{ApiHelper.base_url}/photos" + id;
            var photos = RequestProcessor.Process<List<Photo>>(requestUrl);

            return photos;
        }
    }
}
