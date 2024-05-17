using Auctions.Models;

namespace Auctions.Data.Services
{
    public interface IlListingService
    {
        IQueryable<Listing> GetAll();
        Task Add(Listing listing);
    }
}
