using System;
using Photon.Pun;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

namespace CTPK
{
	public class CarSpawner : MonoBehaviour
	{
		[SerializeField] private Transform[] _spawnPoints;
		[SerializeField] private string _prefabName = "Player";

		private void Start()
		{
			var idxObj = PhotonNetwork.LocalPlayer.CustomProperties["index"];
			var idx = Convert.ToInt32(idxObj);
				var go = PhotonNetwork.Instantiate(_prefabName, _spawnPoints[idx].position,
					_spawnPoints[idx].rotation);
				var cameras = FindObjectsOfType<CarCamera>();
				foreach (var carCamera in cameras)
				{
					carCamera.SetCar(go.GetComponentInChildren<CarController>().gameObject);
				}
		}
	}
}
