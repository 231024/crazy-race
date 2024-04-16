using Unity.Entities;

namespace CTPK.ECS.Unity
{
	public partial struct RotationSystem : ISystem
	{
		public void OnUpdate(ref SystemState state)
		{
			var dt = SystemAPI.Time.DeltaTime;

			foreach (var aspect in SystemAPI.Query<CubeRotationAspect>().WithNone<RedTagComponent>())
			{
				aspect.Rotate(dt);
			}
		}
	}
}
