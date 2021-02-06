using System;
using System.Collections.Generic;

namespace ScreenShareApp.Database{

    public interface ITempDb{

        public List<string> GetAllPeerId();
        public void AddPeer(string PeerId);
        public void DeletePeer(string peerid);

    }

}