using GorillaNetworking;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreezeV2.Mods
{
    internal class RoomMods
    { 
        public static void Joinroommod(string roomName)
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(roomName, JoinType.Solo);
        }
    }
}
