using MessagePipe;
using UnityEngine;
using VContainer;

namespace CTPK
{
	public class MenuView : MonoBehaviour
	{
		[Inject] private readonly IPublisher<string> _publisher;
		[Inject] private readonly IPublisher<PhotonCommand> _punPublisher;

		private string _nickname;

		public void OnValueChanged(string nickname)
		{
			_nickname = nickname;
		}

		public void OnEndEdit(string nickname)
		{
			_nickname = nickname;
		}

		public void OnSendButtonClick()
		{
			_publisher.Publish(_nickname);
		}

		public void OnStartButtonClick()
		{
			_punPublisher.Publish(PhotonCommand.StartGame);
		}
	}
}
