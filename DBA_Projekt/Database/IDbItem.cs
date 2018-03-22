namespace DBA_Projekt
{
    public interface IDbItem<in T>
    {
        int Id { get; set; }

        bool Equals(object other);
        bool Equals(T other);
    }
}