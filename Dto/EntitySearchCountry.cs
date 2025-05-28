namespace BlockCountries.Dto
{
    public class EntitySearchCountry
    {
        public int page { get; set; } = 0;
        public int pageSize { get; set; } = 10;
        public string ?searchTerm { get; set; }
    }
}
