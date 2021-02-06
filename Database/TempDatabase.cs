using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ScreenShareApp.Database{

    public class TempDatabase:ITempDb{
        
        private List<PeerId> Connections;
        public TempDatabase(){
            Connections = new List<PeerId>();
        }

        //Read
        public List<string> GetAllPeerId(){
            return Connections.Select(x =>x.ConnectionId).ToList();
        }

        //Create
        public void AddPeer(string PeerId){
            Connections.Add(new PeerId(){ ConnectionId = PeerId } );
        }

        //Delete
        public void DeletePeer(string peerid){
            PeerId temp = Connections.Find(x => x.ConnectionId ==  peerid);
            Connections.Remove(temp);
        }
        


    }

    public class PeerId{
        public string ConnectionId;
    }


}