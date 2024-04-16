using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Random = UnityEngine.Random;

namespace CTPK.ECS.Unity
{
	public partial class SpawnSystem : SystemBase
	{
		protected override void OnCreate()
		{
			RequireForUpdate<SpawnerComponent>();
		}

		protected override void OnUpdate()
		{
			Enabled = false;

			var singleton = SystemAPI.GetSingleton<SpawnerComponent>();

			for (var i = 0; i < singleton.Count; i++)
			{
				var entity = EntityManager.Instantiate(singleton.Entity);
				EntityManager.SetComponentData(entity, new LocalTransform
				{
					Position = new float3(Random.Range(-3.0f, 3.0f), 0.0f, 0.0f),
					Rotation = quaternion.identity,
					Scale = 1.0f
				});
			}
		}
	}
}
