using System;
using UnityEngine;

namespace CTPK.ECS.Leo
{
	[Serializable]
	public struct RotationComponent
	{
		public Transform Local;
		public float Speed;
	}
}
