using Leopotam.EcsLite;
using UnityEngine;

namespace CTPK.ECS.Leo
{
	public sealed class RotationSystem : IEcsRunSystem
	{
		public void Run(EcsSystems ecsSystems)
		{
			var filter = ecsSystems.GetWorld().Filter<RotationComponent>().End();
			var pool = ecsSystems.GetWorld().GetPool<RotationComponent>();

			foreach (var entity in filter)
			{
				ref var rotation = ref pool.Get(entity);
				rotation.Local.Rotate(Vector3.up, rotation.Speed * Time.deltaTime);
			}
		}
	}
}
