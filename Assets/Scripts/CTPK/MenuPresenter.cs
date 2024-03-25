using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CTPK
{
	public class MenuPresenter : IStartable
	{
		[Inject] private readonly ISubscriber<int> _subscriber;

		public void Start()
		{
			_subscriber.Subscribe(PrintNumber);
		}

		private void PrintNumber(int value)
		{
			Debug.Log(value);
		}
	}
}
