using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using VContainer.Unity;

namespace CTPK
{
	public class PlayFabService : IStartable
	{
		private const string PlayerServerIdKey = "PlayerServerIdKey";

		private string _uniqueKey;

		public void Start()
		{
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

		private void OnSuccess(GetPlayerProfileResult res)
		{
			Debug.Log(res.PlayerProfile.DisplayName);
		}

		private void OnError(PlayFabError er)
		{
			Debug.LogError(er.Error);
		}
	}
}
