using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using MessagePipe;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using VContainer;

namespace CTPK
{
	public class PhotonService : MonoBehaviourPunCallbacks, IDisposable
	{
		[Inject] private readonly ISubscriber<PhotonCommand> _punSubscriber;
		[Inject] private readonly ISubscriber<string, string> _subscriber;
		[Inject] private RoomListView _roomListView;
		private IDisposable _subscription;

		private void Awake()
		{
			PhotonNetwork.AutomaticallySyncScene = true;
		}

		public void Start()
		{
			var sub1 = _subscriber.Subscribe(Constants.PlayFabNicknameMessageKey, NicknameReceived);
			var sub2 = _subscriber.Subscribe(Constants.PhotonCurrentRoomNameKey, JoinRoom);
			var sub3 = _punSubscriber.Subscribe(HandleCommand);

			_subscription = DisposableBag.Create(sub1, sub2, sub3);
		}

		public void Dispose()
		{
			_subscription?.Dispose();
		}

		private void NicknameReceived(string nickname)
		{
			PhotonNetwork.NickName = nickname;

			if (!PhotonNetwork.IsConnected)
			{
				PhotonNetwork.ConnectUsingSettings();
			}
			else if (!PhotonNetwork.InLobby)
			{
				PhotonNetwork.JoinLobby();
			}
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
			PhotonNetwork.JoinLobby();
		}

		public override void OnJoinedLobby()
		{
		}

		public override void OnCreateRoomFailed(short returnCode, string message)
		{
			Debug.LogError($"[Photon] OnCreateRoomFailed with code: {returnCode} and message: {message}");
		}

		public override void OnJoinRoomFailed(short returnCode, string message)
		{
			Debug.LogError($"[Photon] OnJoinRoomFailed with code: {returnCode} and message: {message}");
		}

		public override void OnCreatedRoom()
		{
			Debug.Log("OnCreatedRoom");
		}

		public override void OnJoinedRoom()
		{
			foreach (var player in PhotonNetwork.CurrentRoom.Players)
			{
				Debug.Log($"{player.Key}: {player.Value}");
			}

			PhotonNetwork.SetPlayerCustomProperties(new Hashtable
				{ { "index", PhotonNetwork.CurrentRoom.PlayerCount - 1 } });
		}

		public override void OnJoinRandomFailed(short returnCode, string message)
		{
			Debug.LogError($"[Photon] OnJoinRandomFailed with code: {returnCode} and message: {message}");
		}

		public override void OnPlayerEnteredRoom(Player newPlayer)
		{
			Debug.Log($"OnPlayerEnteredRoom {newPlayer.NickName}");
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
			Debug.Log($"OnPlayerLeftRoom {otherPlayer.NickName}");
		}

		public override void OnRoomListUpdate(List<RoomInfo> roomList)
		{
			_roomListView.Refresh(roomList);
		}

		private void HandleCommand(PhotonCommand cmd)
		{
			switch (cmd)
			{
				case PhotonCommand.StartGame:
					if (PhotonNetwork.IsMasterClient)
					{
						PhotonNetwork.LoadLevel(Constants.CoreGameplaySceneName);
					}
					break;
				case PhotonCommand.CreateRoom:
					PhotonNetwork.CreateRoom(Guid.NewGuid().ToString());
					break;
			}
		}

		public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
		{
			Debug.Log($"OnPlayerPropertiesUpdate {targetPlayer.NickName}, {changedProps["index"]}");
		}

		private void JoinRoom(string roomName)
		{
			PhotonNetwork.JoinRoom(roomName);
		}
	}
}
