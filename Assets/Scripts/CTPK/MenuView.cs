using MessagePipe;
using UnityEngine;
using VContainer;

namespace CTPK
{
	public class MenuView : MonoBehaviour
	{
		[Inject] private readonly IPublisher<int> _publisher;

		public void OnButtonClick(int value)
		{
			_publisher.Publish(value);
		}
	}
}
