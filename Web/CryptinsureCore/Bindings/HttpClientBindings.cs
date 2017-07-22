namespace CryptinsureCore.Bindings
{
    public interface IClient<in A, in B, C>
    {
        C SendRequest<C>(A request, B credentials, string Method);
    }
}
