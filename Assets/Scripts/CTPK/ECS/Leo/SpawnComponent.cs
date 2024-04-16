using System;
using UnityEngine;

namespace CTPK.ECS.Leo
{
	[Serializable]
	public struct SpawnComponent
	{
		public GameObject Prefab;
		public int Amount;
	}
}
