using RMC.UnityGamePhysics.Shared;
using Unity.Collections;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class RaycastCommandDemo : MonoBehaviour
	{
		[SerializeField]
		private bool _isDebug = true;

		[SerializeField]
		private float _rayDistance = 3;

		[SerializeField]
		private float _rayDuration = 0.1f;

		private void Update()
		{
			// SETUP: Allow for 1 result (the closest) per job
			var results = new NativeArray<RaycastHit>(1, Allocator.TempJob);
			var commands = new NativeArray<RaycastCommand>(1, Allocator.TempJob);

			// Here we create one command. Simple demo.
			// NOTE: This system is optimized to can handle MANY commands. 
			commands[0] = new RaycastCommand(transform.position, Vector3.down, _rayDistance);

			if (_isDebug == true)
			{
				foreach (RaycastCommand raycastCommand in commands)
				{
					Debug.DrawRay(raycastCommand.from, raycastCommand.direction * raycastCommand.distance, Color.red, _rayDuration);
				}
			}

			// ************************
			// PHYSICS - Here is the RaycastCommand functionality
			// ************************
			var handle = RaycastCommand.ScheduleBatch(commands, results, 1);

			// Wait for the batch processing job to complete
			handle.Complete();

			// Iterate through all results (Max 1 in this situation)
			foreach (RaycastHit raycastHit in results)
			{
				if (raycastHit.collider != null)
				{
					//Debug.Log("Colliding with: " + raycastHit.collider.gameObject.name);

					if (raycastHit.collider.gameObject.layer ==
						LayerMask.NameToLayer(ProjectConstants.FloorLayer))
					{
						Debug.Log("The floor is close below.");
					}

					if (raycastHit.collider.gameObject.layer ==
						LayerMask.NameToLayer(ProjectConstants.RampLayer))
					{
						Debug.Log("The ramp is close below.");
					}
				}
			}

			// Dispose the buffers
			results.Dispose();
			commands.Dispose();
		}
	}
}