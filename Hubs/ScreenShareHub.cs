using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using ScreenShareApp.Database;

namespace ScreenShareApp.Hubs{

    public class ScreenShareHub:Hub{
        
        private ITempDb _db ;
        public ScreenShareHub(ITempDb db){
            _db =db;
        }

         public async Task sendConnectionId(string id){
             _db.AddPeer(id);
             //For debug purposes
             foreach(var a in _db.GetAllPeerId()){
                 Console.WriteLine(a);
             }
             await Clients.All.SendAsync("ReceiveId", new {peers = _db.GetAllPeerId()});
         }

         public async Task DisconnectPeer(string id){
             _db.DeletePeer(id);
             Console.WriteLine($"this connection id disconnected:{id}");
             await Clients.All.SendAsync("DeletePeerId",new {peers = _db.GetAllPeerId()});
         }

         public async Task DisconnectCall(string id,string peer){
             await Clients.All.SendAsync("DisconnectedCall", id,peer);
         }



    }

}