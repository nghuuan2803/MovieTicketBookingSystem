using MTBS.Domain.Values;

namespace MTBS.Domain.Abstracts
{
    public abstract class Person<T> : BaseEntity<T>
    {
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; } = Gender.Unknow;
        public string? Nationality { get; set; }
    }
}
