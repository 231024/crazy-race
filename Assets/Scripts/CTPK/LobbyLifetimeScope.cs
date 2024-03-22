using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CTPK
{
	public class LobbyLifetimeScope : LifetimeScope
	{
		[SerializeField] private MenuView _view;

		protected override void Configure(IContainerBuilder builder)
		{
			var options = builder.RegisterMessagePipe();
			builder.RegisterMessageBroker<int>(options);

			builder.RegisterComponent(_view);
			builder.RegisterEntryPoint<MenuPresenter>();
		}
	}
}
