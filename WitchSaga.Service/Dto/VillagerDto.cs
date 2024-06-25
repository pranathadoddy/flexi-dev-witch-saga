namespace WitchSaga.Service.Dto
{
    public class VillagerDto
    {
        public int AgeOfDeath { get; set; }
        public int YearOfDeath { get; set; }

        public VillagerDto(int ageOfDeath, int yearOfDeath)
        {
            AgeOfDeath = ageOfDeath;
            YearOfDeath = yearOfDeath;
        }

        public int GetYearOfBirth()
        {
            return YearOfDeath - AgeOfDeath;
        }
    }
}
