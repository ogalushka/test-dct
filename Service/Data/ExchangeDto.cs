namespace DCT.Service.Data
{
    public class ExchangeDto
    {
        public string ExchangeUrl { get; set; } = string.Empty;
    }

    public class ExchangeDtoResponse
    {
        public ExchangeDto Data { get; set; } = null!;
    }
}
