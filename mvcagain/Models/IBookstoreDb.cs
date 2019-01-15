using System.Collections.Generic;

namespace mvcagain.Models
{
    public interface IBookstoreDb
    {
        public void Create(Book x);

        public void Create(Publisher x);


        public void Update(Book x);


        public void Update(Publisher x);


        public void Delete(Book x);


        public void Delete(Publisher x);

        IEnumerable<Publisher> GetPublishers();
    }
}