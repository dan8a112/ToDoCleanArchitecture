﻿namespace Domain.Common;

public class Entity
{
    public int Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
            return false;
        return Id.Equals(other.Id);
    }
    
    public override int GetHashCode() => Id.GetHashCode();
}