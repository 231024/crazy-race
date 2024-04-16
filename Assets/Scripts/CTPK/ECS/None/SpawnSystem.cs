using UnityEngine;
using Random = UnityEngine.Random;

namespace CTPK.ECS.None
{
	public class SpawnSystem : MonoBehaviour
	{
		[SerializeField] private GameObject _prefab;
		[SerializeField] private float _count;

		private void Start()
		{
			for (var i = 0; i < _count; i++)
			{
				Instantiate(_prefab, new Vector3(Random.Range(-3.0f, 3.0f), 0.0f, 0.0f), Quaternion.identity);
			}
		}
	}
}
