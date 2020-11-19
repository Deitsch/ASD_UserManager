using System;
namespace Domain
{
    public interface IValidator<T>
    {
        bool isValid(T item);
    }

    public class PasswordValidator : IValidator<String>
    {
        public bool isValid(string item)
        {
            return true;
        }
    }
}
