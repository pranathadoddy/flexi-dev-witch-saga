using WitchSaga.Service.Dto;

namespace WitchSaga.Service.Service
{
    public interface IWitchService
    {
        double CalculateAverageKillings(List<VillagerDto> villagers);
    }
}
