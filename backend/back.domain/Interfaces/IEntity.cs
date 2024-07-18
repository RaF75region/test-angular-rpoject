namespace back.domain.Interfaces;

public interface IEntity
{
    Guid? CountryId { get; set; }
    
}

public interface IEntityProvincies
{
    Guid? CountryId { get; set; }
}