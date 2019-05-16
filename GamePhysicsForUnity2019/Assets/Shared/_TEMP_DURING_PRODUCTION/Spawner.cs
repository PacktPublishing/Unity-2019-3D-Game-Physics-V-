
using UnityEngine;

namespace RMC.UnityGamePhysics.Shared
{
	public class Spawner : MonoBehaviour
	{
		public float spawnTime = 3f;            // How long between each spawn.
		public GameObject prefab;                // The enemy prefab to be spawned.
		public Transform parent;
		public Transform origin;
		public Vector3 originOffsetRandom;


		void Start()
		{
			// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
			InvokeRepeating("Spawn", spawnTime, spawnTime);

			// Also spawn one immediatly
			Spawn();
		}

		void Spawn()
		{
			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			GameObject spawned = Instantiate<GameObject>(prefab);
			spawned.transform.SetParent(parent, true);
			spawned.transform.position = origin.position;

			// Randomize starting position
			float x = Random.RandomRange(-originOffsetRandom.x, originOffsetRandom.x);
			float y = Random.RandomRange(-originOffsetRandom.y, originOffsetRandom.y);
			spawned.transform.Translate(new Vector3(x, y, 0));
		}
	}
}