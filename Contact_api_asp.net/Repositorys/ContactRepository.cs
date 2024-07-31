using Contact_api_asp.net.Classes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Contact_api_asp.net.services
{
    public class ContactRepository : IRepository<Contact, int>
    {
        private readonly DataBaseContexteClasse _context;
        public ContactRepository(DataBaseContexteClasse context)
        {
            _context = context;
        }
        public async void Add(Contact contact)
        {
                _context.Contact.Add(contact);
                await _context.SaveChangesAsync();            
        }

        public async void Delete(int id)
        {
            var dbContactRemoved = await _context.Contact.FindAsync(id);
            _context.Contact.Remove(dbContactRemoved);
            await _context.SaveChangesAsync();



        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            IEnumerable<Contact> contacts = await _context.Contact.ToListAsync();
            return contacts;
        }

        public async Task<Contact> GetById(int id)
        {
            Contact contact = await _context.Contact.FindAsync(id);
            if (contact == null) { return null; }
            return contact;
        }

        public async void Update(Contact updateContact, int idContact)
        {
            var dbContact = await _context.Contact.FindAsync(idContact);
            dbContact.nom = updateContact.nom;
            dbContact.prenom = updateContact.prenom;
            dbContact.date_naissance = updateContact.date_naissance;
            dbContact.avatar = updateContact.avatar;
            dbContact.date_naissance = updateContact.date_naissance;
            dbContact.sexe = updateContact.sexe;
        }
    }
}
