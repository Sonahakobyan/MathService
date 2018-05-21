namespace DataTransferLayer
{
    public interface IServer
    {
        void Send(object obj, string text);
        string Receive(object obj);
        object AcceptClient();
    }
}
