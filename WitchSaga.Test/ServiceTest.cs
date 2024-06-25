using WitchSaga.Service.Dto;
using WitchSaga.Service.Service;

namespace WitchSaga.Test
{
    public class ServiceTest
    {
        [Fact]
        public void CalculateAverageKillings_ValidData_ReturnsCorrectAverage()
        {
            var villagers = new List<VillagerDto>
                {
                    new VillagerDto(10, 12),
                    new VillagerDto(13, 18)
                };

            IWitchService witchService = new WitchService();
            double result = witchService.CalculateAverageKillings(villagers);

            Assert.Equal(7, result, 1);
        }

        [Fact]
        public void CalculateAverageKillings_InvalidData_ReturnsNegativeOne()
        {
            var villagers = new List<VillagerDto>
                {
                    new VillagerDto(-10, 12), // Invalid age
                    new VillagerDto(13, 17)
                };

            IWitchService witchService = new WitchService();
            double result = witchService.CalculateAverageKillings(villagers);

            Assert.Equal(-1, result);
        }
    }
}