using BetFor.Context;
using BetFor.Dtos;
using BetFor.Entities;
using BetFor.Repositories;

namespace BetFor.Services
{
    public class ClientService : IClientService
    {
        private readonly IBaseRepository<Client> repository;
        public ClientService(IBaseRepository<Client> repository)
        {
            this.repository = repository;
        }

        public void TryCreateClient(Client client)
        {
            repository.Add(client);
        }

        public void TryUpdateClient(UpdateClientDto request)
        {
            var client = TryGetClientById(request.Id);
            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.UserName = request.UserName;

            repository.Update(client);
        }

        public Client TryGetClientById(long id)
        {
            return repository.GetById(id);
        }

        public void TryDeleteClient(long id)
        {
            var client = TryGetClientById(id);
            repository.Delete(client);
        }
    }
}