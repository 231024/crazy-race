using System.Collections.Generic;
using MessagePipe;
using Photon.Realtime;
using UnityEngine;
using VContainer;

namespace CTPK
{
	public class RoomListView : MonoBehaviour
	{
		[SerializeField] private RoomListItemView _item;
		[SerializeField] private Transform _parent;

		[Inject] private readonly IPublisher<string, string> _publisher;

		public void Refresh(List<RoomInfo> rooms)
		{
			Clear();
			Fill(rooms);
		}

		private void Clear()
		{
			for (int i = 0, count = _parent.childCount; i != count; ++i)
			{
				var comp = _parent.GetChild(i).GetComponent<RoomListItemView>();
				comp.RoomListItemClicked -= OnRoomListItemClicked;
				Destroy(comp.gameObject);
			}
		}

		private void Fill(List<RoomInfo> rooms)
		{
			foreach (var room in rooms)
			{
				var go = Instantiate(_item, _parent);
				go.Init(room.Name);
				go.RoomListItemClicked += OnRoomListItemClicked;
			}
		}

		private void OnRoomListItemClicked(string roomName)
		{
			_publisher.Publish(Constants.PhotonCurrentRoomNameKey, roomName);
		}
	}
}
