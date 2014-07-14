namespace Demo1.MyHub
{
    using Microsoft.AspNet.SignalR;
    using System;
    public class Hub1 : Hub
    {
        public override System.Threading.Tasks.Task OnConnected()
        {
            this.Clients.Caller.ReceMsg("连接成功");
            this.Clients.Others.ReceMsg("来了个新人");
            return null;
        }

        public void Send(string nickName, string msg)
        {
            this.Clients.All.ReceMsg(DateTime.Now.ToShortTimeString() + "&nbsp;" + nickName + ":" + msg);
        }
    }
}