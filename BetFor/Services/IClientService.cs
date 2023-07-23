using BetFor.Dtos;
using BetFor.Entities;

namespace BetFor.Services
{
    public interface IClientService
    {
        void TryCreateClient(Client client);
        void TryUpdateClient(UpdateClientDto client);
        Client TryGetClientById(long id);
        void TryDeleteClient(long id);
    }
}