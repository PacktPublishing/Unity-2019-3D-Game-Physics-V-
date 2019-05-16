using UnityEngine;

namespace RMC.UnityGamePhysics.Shared
{
	public class Physics2DManualSimulation : MonoBehaviour
	{
		[Range(1, 120)]
		public int TargetFrameRate = 60;

		private float _timer;

		void Start()
		{
			// Framerate	------------------------------------
			QualitySettings.vSyncCount = 0;

			// Physics		------------------------------------
			// True is default. 
			// False requires us to manually call Simulate below
			Physics2D.autoSimulation = false;
		}

		private void OnValidate()
		{
			// Framerate	------------------------------------
			TargetFrameRate = Mathf.Clamp(TargetFrameRate, 1, 120);
			if (Application.targetFrameRate != TargetFrameRate)
			{
				Application.targetFrameRate = TargetFrameRate;
				Debug.Log(Application.targetFrameRate);
			}
		}

		void Update()
		{
			// Physics		------------------------------------
			if (Physics2D.autoSimulation)
			{
				return; // do nothing if the automatic simulation is enabled
			}

			_timer += Time.deltaTime;

			// Catch up with the game time.
			// Advance the physics simulation in portions of Time.fixedDeltaTime
			while (_timer >= Time.fixedDeltaTime)
			{
				_timer -= Time.fixedDeltaTime;

				// Note that generally, we don't want to pass variable delta to Simulate 
				// as that leads to unstable results.
				Physics2D.Simulate(Time.fixedDeltaTime);
			}

			// Here you can access the transforms state right after the simulation, if needed
		}
	}
}