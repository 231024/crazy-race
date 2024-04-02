using UnityEngine;

namespace CTPK
{
	public class AudioProvider : MonoBehaviour
	{
		[SerializeField] private AudioSource _getReady, _go;

		public AudioSource GetReady => _getReady;
		public AudioSource Go => _go;
	}
}
