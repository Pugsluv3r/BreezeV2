using GorillaNetworking;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreezeV2.Mods
{
    internal class RoomMods
    { // OML I AM NOT using dictionaries.
        public static void Joinroommod()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("MOD", JoinType.Solo);
        }
        public static void Joinroommods()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("MODS", JoinType.Solo);
        }
        public static void JoinroomLucio()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("LUCIO", JoinType.Solo);
        }
        public static void JoinMenuRoom()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("BREEZE", JoinType.Solo);
        }
    }
}
