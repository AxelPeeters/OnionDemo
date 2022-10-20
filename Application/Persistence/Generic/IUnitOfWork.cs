namespace Application.Persistence.Generic;

public interface IUnitOfWork
{
    Task Commit();
}