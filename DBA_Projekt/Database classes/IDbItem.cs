using System;

namespace DBA_Projekt
{
    public interface IDbItem<T> : IEquatable<T>
    {
        int Id { get; set; }
    }
}