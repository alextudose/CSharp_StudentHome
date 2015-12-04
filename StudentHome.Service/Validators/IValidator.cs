namespace StudentHome.Service
{
    public interface IValidator<T>
    {       
        string Validate(T objectToValidate);
    }
}
