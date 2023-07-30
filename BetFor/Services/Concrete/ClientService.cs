using BetFor.Entities;
using BetFor.Repositories;
using BetFor.Helpers.ClientMapper;

namespace BetFor.Services
{
    public class ClientService : IClientService
    {
        private readonly IBaseRepository<Client> clientRepository;
        private readonly IBaseRepository<Tour> tourRepository;
        private readonly IBaseRepository<ClientTour> clientTourRepository;

        public ClientService(IBaseRepository<Client> clientRepository, IBaseRepository<Tour> tourRepository, IBaseRepository<ClientTour> clientTourRepository)
        {
            this.clientRepository = clientRepository;
            this.tourRepository = tourRepository;
            this.clientTourRepository = clientTourRepository;
        }

        public async Task<bool> TryCreateClientAsync(CreateClientRequest request)
        {
            var item = request.ToClientFromCreateClientRequest();
            return await clientRepository.TryInsertItemAsync(item);
        }

        public async Task<bool> TryUpdateClientAsync(UpdateClientRequest request)
        {
            bool isSuccess = false;
            var item = await clientRepository.GetItemAsync(x => x.Id == request.Id);

            if (item != null)
            {
                item = request.ToClientFromUpdateClientRequest(item);
                isSuccess = await clientRepository.TryUpdateItemAsync(item);
            }

            return isSuccess;
        }

        public async Task<bool> TryDeleteClientAsync(DeleteClientRequest request)
        {
            var isSuccess = false;
            var item = await clientRepository.GetItemAsync(x => x.Id == request.Id);

            if (item != null)
            {
                isSuccess = await clientRepository.TryDeleteItemAsync(item);
            }

            return isSuccess;
        }

        public async Task<GetClientResponse> GetClientAsync(GetClientRequest request)
        {
            var item = await clientRepository.GetItemAsync(x => x.Id == request.Id);

            if (item != null)
            {
                return item.ToGetClientResponseFromClient();
            }

            throw new ArgumentNullException();
        }

        public async Task<CreateBetResponse> CreateBetAsync(CreateBetRequest request)
        {
            var isSuccess = false;
            var client = await clientRepository.GetItemAsync(x => x.Id == request.ClientId);

            if (client != null)
            {
                var tour = await tourRepository.GetItemAsync(x => x.TourStartTime < DateTime.Now && DateTime.Now < x.TourEndTime);

                if (tour != null)
                {
                    var clientTour = request.ToClientTourFromCreateBetRequest();
                    clientTour.TourId = tour.Id;
                    isSuccess = await clientTourRepository.TryInsertItemAsync(clientTour);
                    var response = clientTour.ToCreatBetResponseFromClientTour();
                    response.IsCreated = true;
                    response.ResponseMessage = "Bet is created";
                    return response;
                }
            }

            return new CreateBetResponse
            {
                IsCreated = false,
                ResponseMessage = "Bet is not created!"
            };
        }

        public async Task<List<ClientTour>> GetClientTourListAsync(long tourId)
        {
            var clientTourList = (await clientTourRepository.GetFilteredItemsAsync(x => x.TourId == tourId)).ToList();

            if (clientTourList.Any())
            {
                return clientTourList;
            }

            return null;
        }

        public async Task<List<GetBetResultResponse>> GetBetResultListAsync(GetBetResultRequest request)
        {
            List<GetBetResultResponse> responseList = new List<GetBetResultResponse>();

            var clientTourList = await clientTourRepository.GetFilteredItemsAsync(x => x.ClientId == request.ClientId);

            foreach (var clientTour in clientTourList)
            {
                var tour = await tourRepository.GetItemAsync(x => x.Id == clientTour.TourId);

                responseList.Add(new GetBetResultResponse
                {
                    TourId = tour.Id,
                    TourNumber = tour.TourNumber,
                    BetNumber = clientTour.BetNumber,
                    IsWinner = tour.TourNumber == clientTour.BetNumber
                });
            }

            return responseList;
        }
    }
}