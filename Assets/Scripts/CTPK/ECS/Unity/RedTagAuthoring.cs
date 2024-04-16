using Unity.Entities;
using UnityEngine;

namespace CTPK.ECS.Unity
{
	public class RedTagAuthoring : MonoBehaviour
	{
		public class RedComponentBaker : Baker<RedTagAuthoring>
		{
			public override void Bake(RedTagAuthoring tagAuthoring)
			{
				var entity = GetEntity(TransformUsageFlags.None);
				AddComponent<RedTagComponent>(entity);
			}
		}
	}

	public struct RedTagComponent : IComponentData
	{
	}
}
