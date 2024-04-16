using Unity.Entities;
using UnityEngine;

namespace CTPK.ECS.Unity
{
	public struct SpawnerComponent : IComponentData
	{
		public int Count;
		public Entity Entity;
	}

	public class SpawnerComponentAuthoring : MonoBehaviour
	{
		[SerializeField] private GameObject _gameObject;
		[SerializeField] private int _count;

		public class SpawnerComponentBaker : Baker<SpawnerComponentAuthoring>
		{
			public override void Bake(SpawnerComponentAuthoring authoring)
			{
				var entity = GetEntity(TransformUsageFlags.None);
				AddComponent(entity, new SpawnerComponent
				{
					Entity = GetEntity(authoring._gameObject, TransformUsageFlags.Dynamic),
					Count = authoring._count
				});
			}
		}
	}
}