using System;

namespace Interfaces
{
    public interface IRepo<T>
    {
        void Create(T item);
        T Read(Guid id);
        void Update(T item);
        void Delete(Guid id);
    }
}
