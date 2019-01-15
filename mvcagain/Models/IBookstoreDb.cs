using System.Collections.Generic;

namespace mvcagain.Models
{
    public interface IBookstoreDb
    {
        void Create(Book x);

        void Create(Publisher x);


        void Update(Book x);


        void Update(Publisher x);


        void Delete(Book x);


        void Delete(Publisher x);

        IEnumerable<Publisher> GetPublishers();
    }
}