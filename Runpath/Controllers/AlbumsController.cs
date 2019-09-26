using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Runpath.Helpers;
using Runpath.Models;
using Runpath.Processors;
using Runpath.Services;

namespace Runpath.Controllers
{
    [Route("api/[controller]")]
    public class AlbumsController : Controller
    {
        private IRequestProcessor RequestProcessor;
        private ICalcService CalcService;

        public AlbumsController()
        {
            RequestProcessor = new RequestProcessor();
            CalcService = new CalcService();
        }

        [HttpGet("[action]/{id}")]
        public IEnumerable<Album> GetAlbumsByUserId(int id)
        {
            var requestUrl = $"{ApiHelper.base_url}/albums?userId=" + id;
            var albums = RequestProcessor.Process<List<Album>>(requestUrl);

            return albums;
        }

        [HttpGet("[action]/{id}")]
        public IEnumerable<Album> GetAllAlbumsAndPhotos(int id)
        {
            var requestUrl = $"{ApiHelper.base_url}/albums?userId=" + id;
            var albums = RequestProcessor.Process<List<Album>>(requestUrl);

            // The photos endpoint doesn't support filter by albumId
            requestUrl = $"{ApiHelper.base_url}/photos";
            var photos = RequestProcessor.Process<List<Photo>>(requestUrl);

            var combinedAlbumsAndPhotos = CalcService.CombineAlbumsAndPhotos(albums, photos);

            return combinedAlbumsAndPhotos;
        }

    }
}
