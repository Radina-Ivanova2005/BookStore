using bookRepository.Data;
using bookRepository.Data.Models;
using bookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Busines
{
    public class PublisherController
    {
        private BookShopContext context;
        public PublisherController(BookShopContext context)
        {
            this.context = context;
        }

        //Added new publisher to the database
        public void AddPublisher(Publisher publisher)
        {
            this.context.Publishers.Add(publisher);
            this.context.SaveChanges();
        }

        //Fetch list of all publishers in the database
        public List<Publisher> GetAllPublishers()
        {
            return context.Publishers.OrderBy(p=>p.Name).ToList();
        }

        //Fetch certain publisher from the database by ID
        public Publisher GetPublisherById(int id)
        {
            var publisher = this.context.Publishers.FirstOrDefault(x => x.Id == id);
            return publisher;
        }

        //Fetch certain publisher from the databas by name
        public Publisher GetPublisherByName(string name)
        {
            var publisher = this.context.Publishers.FirstOrDefault(x => x.Name == name);
            return publisher;
        }

        //Updated certain publisher from the database with new publisher characteristics
        public void UpdatePublisher(Publisher publisher)
        {
            var publisherItem = this.GetPublisherById(publisher.Id);
            this.context.Entry(publisherItem).CurrentValues.SetValues(publisher);
            this.context.SaveChanges();
        }

        //Deleted certain publisher from the database by ID
        public void DeletePublisher(int id)
        {
            var publisherItem = this.GetPublisherById(id);
            this.context.Publishers.Remove(publisherItem);
            this.context.SaveChanges();
        }
    }
}
