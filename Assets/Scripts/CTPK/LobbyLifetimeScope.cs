using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CTPK
{
	public class LobbyLifetimeScope : LifetimeScope
	{
		[SerializeField] private MenuView _view;
		[SerializeField] private RoomListView _roomListView;
		[SerializeField] private PhotonService _photon;

		protected override void Configure(IContainerBuilder builder)
		{
			var options = builder.RegisterMessagePipe();
			builder.RegisterMessageBroker<string>(options);
			builder.RegisterMessageBroker<string, string>(options);
			builder.RegisterMessageBroker<PhotonCommand>(options);

			builder.RegisterComponent(_view);
			builder.RegisterEntryPoint<MenuPresenter>();
			builder.RegisterEntryPoint<PlayFabService>().AsSelf();
			builder.RegisterComponent(_photon);
			builder.RegisterComponent(_roomListView);
		}
	}
}
