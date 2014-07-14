namespace Demo2.MyConn
{
    using Microsoft.AspNet.SignalR;
    public class TrackingConn : PersistentConnection
    {
        protected override System.Threading.Tasks.Task OnReceived(IRequest request, string connectionId, string data)
        {
            return this.Connection.Broadcast(data);
        }
    }
}