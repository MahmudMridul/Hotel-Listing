using HotelListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.IRepositories
{
    /* The primary use of this interface(IDisposable) is to release 
     * unmanaged resources. The garbage collector automatically 
     * releases the memory allocated to a managed object 
     * when that object is no longer used. However, it is not 
     * possible to predict when garbage collection will occur. */
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }
        Task Save();
    }
}
