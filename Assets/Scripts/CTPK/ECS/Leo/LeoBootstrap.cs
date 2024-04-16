using Leopotam.EcsLite;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace CTPK.ECS.Leo
{
	public class LeoBootstrap : MonoBehaviour
	{
		private EcsSystems _systems;
		private EcsWorld _world;

		private void Start()
		{
			_world = new EcsWorld();
			_systems = new EcsSystems(_world);

			AddSystems();

			_systems.ConvertScene();

			_systems.Init();
		}

		private void Update()
		{
			_systems?.Run();
		}

		private void OnDestroy()
		{
			if (_systems != null)
			{
				_systems.Destroy();
				_systems = null;
			}

			if (_world != null)
			{
				_world.Destroy();
				_world = null;
			}
		}

		private void AddSystems()
		{
			_systems.Add(new SpawnSystem())
				.Add(new RotationSystem());
		}
	}
}
