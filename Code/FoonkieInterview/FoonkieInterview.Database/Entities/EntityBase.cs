using SQLite;

namespace FoonkieInterview.Database.Entities
{
    public abstract class EntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
