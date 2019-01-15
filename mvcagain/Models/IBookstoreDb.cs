using System.Collections.Generic;

namespace mvcagain.Models
{
    public interface IBookstoreDb
    {
        IEnumerable<Publisher> GetPublishers();
    }
}