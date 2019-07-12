using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section07.Video02.OptimizePhysics_Complete
{
	public class OptimizePhysicsSetup: MonoBehaviour
	{
		protected void Awake()
		{
			// ------------------------------------
			// TESTING ADVICE

			// The number of VSyncs that should pass between each frame. 
			// Use 'Don't Sync' (0) to not wait for VSync for faster editor framerates
			// This is useful when TESTING framerates. 
			QualitySettings.vSyncCount = 0;

			// ------------------------------------
			// OPTIMIZATION ADVICE

			// 1
			// Upgrade Unity
			// The latest public release probably gives the best results

			// 2
			// Build your project
			// While the editor runs efficiently, you get better performance 

			// 3
			// Go to the one light in the scene and turn off shadows 

			// 4
			// Go to the floor in scene and set static. I see improved FPS

			// 5
			// Go to the Thing prefab. Use a primitive collider (box) not the mesh collider

			// 6
			// Default 0.02f
			// Higher number is more efficient FPS yet less accurate physics
			// Ex. 1.0f is high framerate but poor physics accuracy
			// Ex. 0.08f is a good compromise
			// Ex. 0.02f is low framerate but high physics accuracy
			Time.fixedDeltaTime = .08f;
			Time.maximumDeltaTime = 1;

			// 7 - MAYBE Tweak Physics Settings
			//		( For Possible Improvements? Not for me.)
			// Default 0.005
			// Higher value, earlier sleep.
			//Physics.sleepThreshold = 5;
			//Physics.defaultContactOffset = 0.05f;
			//Physics.defaultSolverIterations = 1;

			// 8
			//Open Menu: Unity -> Edit -> Project Settings -> Physics -> Adaptive Force... 
			//	(Enable For Possible Improvements? Not for me.)

		}
	}
}