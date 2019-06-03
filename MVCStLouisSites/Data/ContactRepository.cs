using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCStLouisSites.Models;

namespace MVCStLouisSites.Data
{
    public class ContactRepository : BaseRepository  // BaseRepository is an IModelRepository
    {
        //  override BaseRepository
        //  we override here until we get the database implemented in the BaseRepository.cs
        public override List<IModel> GetModels()
        {
            List<Contact> contacts = new List<Contact>();
            Contact contact = new Contact();
            contact.Id = 1;
            contact.PhonePublic = "(314) 781-0900";
            contacts.Add(contact);

            contact = new Contact();
            contact.Id = 2;
            contact.PhonePublic = "(800) 966-8877 Toll free";
            contacts.Add(contact);

            base.models = contacts.Cast<IModel>().ToList();

            return base.models;
        }
    }
}

