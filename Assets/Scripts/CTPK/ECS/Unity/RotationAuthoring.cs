using Unity.Entities;
using UnityEngine;

namespace CTPK.ECS.Unity
{
	public class RotationAuthoring : MonoBehaviour
	{
		public float Speed;

		private class RotationBaker : Baker<RotationAuthoring>
		{
			public override void Bake(RotationAuthoring authoring)
			{
				var entity = GetEntity(TransformUsageFlags.Dynamic);
				AddComponent(entity, new Rotation { Speed = authoring.Speed });
			}
		}
	}

	public struct Rotation : IComponentData
	{
		public float Speed;
	}
}