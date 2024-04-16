using Leopotam.EcsLite;
using UnityEngine;

namespace CTPK.ECS.Leo
{
	public sealed class SpawnSystem : IEcsInitSystem
	{
		public void Init(EcsSystems ecsSystems)
		{
			var world = ecsSystems.GetWorld();
			var filter = world.Filter<SpawnComponent>().End();
			var pool = world.GetPool<SpawnComponent>();

			foreach (var entity in filter)
			{
				ref var spawn = ref pool.Get(entity);

				for (var i = 0; i < spawn.Amount; i++)
				{
					Object.Instantiate(spawn.Prefab, new Vector3(Random.Range(-3.0f, 3.0f), 0.0f, 0.0f),
						Quaternion.identity);
				}
			}
		}
	}
}
