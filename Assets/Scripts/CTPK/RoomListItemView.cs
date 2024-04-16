using System;
using TMPro;
using UnityEngine;

namespace CTPK
{
	public class RoomListItemView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _label;

		private string _roomName;
		public event Action<string> RoomListItemClicked;

		public void Init(string roomName)
		{
			_roomName = roomName;
			_label.SetText(roomName);
		}

		public void OnButtonClick()
		{
			RoomListItemClicked?.Invoke(_roomName);
		}
	}
}
