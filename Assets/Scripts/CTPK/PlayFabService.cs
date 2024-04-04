using System;
using MessagePipe;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CTPK
{
	public class PlayFabService : IStartable
	{
		private const string PlayerServerIdKey = "PlayerServerIdKey";

		[Inject] private readonly IPublisher<string, string> _publisher;
		[Inject] private readonly ISubscriber<string> _subscriber;
		private string _nickname;
		private string _uniqueKey;

		public void Start()
		{
			_subscriber.Subscribe(NicknameChanged);

			var needToCreate = false;
			if (PlayerPrefs.HasKey(PlayerServerIdKey))
			{
				_uniqueKey = PlayerPrefs.GetString(PlayerServerIdKey);
			}
			else
			{
				_uniqueKey = Guid.NewGuid().ToString();
				needToCreate = true;
			}

			var req = new LoginWithCustomIDRequest { CreateAccount = needToCreate, CustomId = _uniqueKey };
			PlayFabClientAPI.LoginWithCustomID(req, OnSuccess, OnError);
		}

		private void OnSuccess(LoginResult res)
		{
			PlayerPrefs.SetString(PlayerServerIdKey, _uniqueKey);
			PlayerPrefs.Save();

			var get = new GetPlayerProfileRequest { PlayFabId = res.PlayFabId };
			PlayFabClientAPI.GetPlayerProfile(get, OnSuccess, OnError);
		}

		private void OnSuccess(UpdateUserTitleDisplayNameResult res)
		{
			_nickname = res.DisplayName;
			_publisher.Publish(Constants.PlayFabNicknameMessageKey, _nickname);
		}

		private void OnSuccess(GetPlayerProfileResult res)
		{
			_nickname = res.PlayerProfile.DisplayName;
			_publisher.Publish(Constants.PlayFabNicknameMessageKey, _nickname);
		}

		private void OnError(PlayFabError er)
		{
			Debug.LogError(er.Error);
		}

		private void NicknameChanged(string nickname)
		{
			var nicknameReq = new UpdateUserTitleDisplayNameRequest { DisplayName = nickname };
			PlayFabClientAPI.UpdateUserTitleDisplayName(nicknameReq, OnSuccess, OnError);
		}
	}
}
