using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class RaycastCommandDemo : MonoBehaviour
	{
		public bool IsDebug = true;

		private void RaycasExample()
		{
			// Perform a single raycast using RaycastCommand and wait for it to complete
			// Setup the command and result buffers
			var results = new NativeArray<RaycastHit>(1, Allocator.Temp);

			var commands = new NativeArray<RaycastCommand>(1, Allocator.Temp);

			// Set the data of the first command
			Vector3 origin = Vector3.forward * -10;

			Vector3 direction = Vector3.forward;

			commands[0] = new RaycastCommand(origin, direction);

			if (IsDebug == true)
			{
				foreach (RaycastCommand raycastCommand in commands)
				{
					Debug.DrawRay(raycastCommand.from, raycastCommand.direction, Color.red, 0.1f);
				}

			}

			// Schedule the batch of raycasts
			JobHandle handle = RaycastCommand.ScheduleBatch(commands, results, 1, default(JobHandle));

			// Wait for the batch processing job to complete
			handle.Complete();

			// Copy the result. If batchedHit.collider is null there was no hit
			foreach (RaycastHit raycastHit in results)
			{
				if (raycastHit.collider != null)
				{
					Debug.Log("Hit Something");
				}
			}

			// Dispose the buffers
			results.Dispose();
			commands.Dispose();
		}
	}
}