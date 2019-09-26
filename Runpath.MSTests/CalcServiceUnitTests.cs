using Microsoft.VisualStudio.TestTools.UnitTesting;
using Runpath.Models;
using Runpath.Services;
using System.Collections.Generic;
using System.Linq;

namespace Runpath.MSTests
{
    [TestClass]
    public class CalcServiceUnitTests
    {
        [TestMethod]
        public void CheckCalcServiceOnNull()
        {
            // 1. Arrange
            var cs = new CalcService();

            // 2. Act 
            var result = cs.CombineAlbumsAndPhotos(null, new List<Photo>());

            // 3. Assert 
            Assert.IsTrue(result != null && !result.Any(), $"The CombineAlbumsAndPhotos function shouldn't retrieve any results");
        }

        [TestMethod]
        public void CheckCalcServiceOnNull2()
        {
            // 1. Arrange
            var cs = new CalcService();

            // 2. Act 
            var result = cs.CombineAlbumsAndPhotos(new List<Album>(), null);

            // 3. Assert 
            Assert.IsTrue(result != null && !result.Any(), $"The CombineAlbumsAndPhotos function shouldn't retrieve any results");
        }

        [TestMethod]
        public void TestCombineAlbumsAndPhotos()
        {
            // 1. Arrange
            var cs = new CalcService();

            var albums = new List<Album>()
            {
                new Album() { Id = 999, UserId = 111, Title = "Test" },
                new Album() { Id = 888, UserId = 111, Title = "Test" }
            };

            var photos = new List<Photo>()
            {
                new Photo() { Id = 111, AlbumId = 999, Title = "Test" },
                new Photo() { Id = 222, AlbumId = 999, Title = "Test" },
                new Photo() { Id = 333, AlbumId = 999, Title = "Test" },
                new Photo() { Id = 444, AlbumId = 888, Title = "Test" },
                new Photo() { Id = 999, AlbumId = 1000, Title = "Test" } // The photo doesn't have any album
            };

            // 2. Act 
            var result = cs.CombineAlbumsAndPhotos(albums, photos);

            // 3. Assert 
            Assert.IsTrue(result != null && result.Count == 2, $"The CombineAlbumsAndPhotos function should retrieve 2 albums");
            Assert.IsTrue(result[0].Id == 999 && result[0].Photos != null && result[0].Photos.Count == 3);
            Assert.IsTrue(result[1].Id == 888 && result[1].Photos != null && result[1].Photos.Count == 1);
        }
    }
}
