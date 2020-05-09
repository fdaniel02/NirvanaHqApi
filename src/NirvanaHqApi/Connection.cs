namespace NirvanaHqApi
{
    public class Connection : IConnection
    {
        public Connection(string authToken)
        {
            Token = authToken;
        }

        public string Token { get; private set; }
    }
}
