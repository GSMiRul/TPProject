namespace TPProject.Domain.Exceptions;
public class InvalidProductStateException : Exception
{
    public InvalidProductStateException(int state, string product) : base(
        $"Invalid product state {state} for product {product}")
    {

    }
}
