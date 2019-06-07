using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class ClientsDirectory
    {
        public IList<Client> Clients = new List<Client>();

        public void AddClient(string name, int age, string mail, string password)
        {
            Client client = new Client(name, age, mail, password);
            this.Clients.Add(client);
        }
        public bool RemoveClient(string mail)
        {
            foreach(Client client in this.Clients)
            {
                if (client.Mail == mail)
                {
                    this.Clients.Remove(client);
                    return true;
                }
            }
            return false;
        }
    }
}