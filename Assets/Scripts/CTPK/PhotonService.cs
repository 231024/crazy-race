using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using VContainer.Unity;

namespace CTPK
{
	public class PhotonService : MonoBehaviourPunCallbacks
	{
		public void Start()
		{
			PhotonNetwork.ConnectUsingSettings();
		}

		public override void OnConnected()
		{
			Debug.Log("OnConnected");
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
			Debug.Log("OnDisconnected");
		}

		public override void OnConnectedToMaster()
		{
			Debug.Log("OnConnectedToMaster");
		}
	}
}
