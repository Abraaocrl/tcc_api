namespace TCC_API.Models.Database
{
    public abstract class BaseTable
    {
        public long Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataEdicao { get; set; }
    }
}
