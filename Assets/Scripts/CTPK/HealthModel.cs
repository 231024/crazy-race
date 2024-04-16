using Photon.Pun;
using UnityEngine;

public class HealthModel : MonoBehaviourPunCallbacks, IPunObservable
{
	[SerializeField] private PhotonView _view;

	private int _health = 100;

	private void Update()
	{
		if (!_view.IsMine)
		{
			return;
		}

		if (Input.GetKeyDown(KeyCode.Minus))
		{
			_health--;
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			photonView.RPC("Print", RpcTarget.All);
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(_health);
		}
		else
		{
			_health = (int)stream.ReceiveNext();
		}
	}

	[PunRPC]
	private void Print()
	{
		Debug.Log("Procedure call");
	}
}
