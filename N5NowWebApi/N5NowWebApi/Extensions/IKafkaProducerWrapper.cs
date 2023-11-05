namespace N5NowWebApi.Extensions
{
    public interface IKafkaProducerWrapper
    {
        Task ProduceAsync(string message);
    }

}
