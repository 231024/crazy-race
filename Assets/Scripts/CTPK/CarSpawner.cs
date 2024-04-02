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
			for (int i = 0, count = PhotonNetwork.CountOfPlayers; i != count; ++i)
			{
				var go = PhotonNetwork.Instantiate(_prefabName, _spawnPoints[i].position,
					_spawnPoints[i].rotation);
				var cameras = FindObjectsOfType<CarCamera>();
				foreach (var carCamera in cameras)
				{
					carCamera.SetCar(go.GetComponentInChildren<CarController>().gameObject);
				}
			}
		}
	}
}
