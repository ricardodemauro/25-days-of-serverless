using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imache.Services.Api
{
    public interface IUnsplashService
    {
        [Get("/search/photos?query={searchString}&per_page={count}&client_id={clientKey}&color={color}")]
        Task<SearchResult> SearchPhotos(string searchString, string color, int count, string clientKey);
    }
}
