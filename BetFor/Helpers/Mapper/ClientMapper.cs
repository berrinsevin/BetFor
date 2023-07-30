using BetFor.Entities;

namespace BetFor.Helpers.ClientMapper
{
    public static class ClientMapper
    {
        public static Client ToClientFromCreateClientRequest(this CreateClientRequest request)
        {
            return new Client
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };
        }

        public static Client ToClientFromUpdateClientRequest(this UpdateClientRequest request, Client item)
        {
            item.FirstName = request.FirstName;
            item.LastName = request.LastName;
            item.UserName = request.UserName;

            return item;
        }

        public static GetClientResponse ToGetClientResponseFromClient(this Client request)
        {
            return new GetClientResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };
        }

        public static ClientTour ToClientTourFromCreateBetRequest(this CreateBetRequest request)
        {
            return new ClientTour
            {
                ClientId = request.ClientId,
                BetNumber = request.BetNumber
            };
        }

        public static CreateBetResponse ToCreatBetResponseFromClientTour(this ClientTour request)
        {
            return new CreateBetResponse
            {
                ClientId = request.ClientId,
                BetNumber = request.BetNumber,
                EntryTime = DateTime.Now,
                TourId = request.TourId
            };
        }
    }
}