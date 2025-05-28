namespace BlockCountries.Dto
{
    public class TemporalEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public int  DurationMinutes { get; set; }
    }
    public static class TransferBetweenTemporalEntityAndBlockedCountry
    {
        public static BlockedCountryDto ToBlockedCountry(this TemporalEntity temporalEntity)
        {
            return new BlockedCountryDto
            {
                Code = temporalEntity.Code,
                Name = temporalEntity.Name,
            };
        }
    }
}
