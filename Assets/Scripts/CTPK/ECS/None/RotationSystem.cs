using UnityEngine;

namespace CTPK.ECS.None
{
	public class RotationSystem : MonoBehaviour
	{
		[SerializeField] private float _speed;

		private void Update()
		{
			transform.Rotate(Vector3.up, 90 * _speed * Time.deltaTime);
		}
	}
}
