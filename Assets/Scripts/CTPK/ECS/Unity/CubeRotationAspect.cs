using Unity.Entities;
using Unity.Transforms;

namespace CTPK.ECS.Unity
{
	public readonly partial struct CubeRotationAspect : IAspect
	{
		private readonly RefRW<LocalTransform> _localTransform;
		private readonly RefRO<Rotation> _rotation;

		public void Rotate(float dt)
		{
			_localTransform.ValueRW = _localTransform.ValueRO.RotateY(_rotation.ValueRO.Speed * dt);
		}
	}
}
