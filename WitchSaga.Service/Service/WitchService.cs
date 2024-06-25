using WitchSaga.Service.Dto;

namespace WitchSaga.Service.Service
{
    public class WitchService : IWitchService
    {
        public double CalculateAverageKillings(List<VillagerDto> villagers)
        {
            double totalKillings = 0;
            int validVillagerCount = 0;

            foreach (var villager in villagers)
            {
                int yearOfBirth = villager.GetYearOfBirth();
                if (yearOfBirth <= 0 || villager.AgeOfDeath < 0)
                {
                    return -1; // Invalid data
                }

                int killingsInYearOfBirth = GetVillagersKilledInYear(yearOfBirth);
                totalKillings += killingsInYearOfBirth;
                validVillagerCount++;
            }

            return validVillagerCount > 0 ? totalKillings / validVillagerCount : -1;
        }

        private int GetVillagersKilledInYear(int year)
        {
            if (year <= 0)
                return -1;

            if (year == 1)
            {
                return 1;
            }

            if (year == 1)
            {
                return 1;
            }

            int previous = 1;
            int current = 1;
            int totalKill = 2;

            for (int i = 3; i <= year; i++)
            {
                int next = previous + current;
                totalKill += next;
                previous = current;
                current = next;
            }

            return totalKill;

        }
    }
}
