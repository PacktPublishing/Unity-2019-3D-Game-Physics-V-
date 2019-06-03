
using System.Collections.Generic;
using UnityEngine;

namespace RMC.UnityGamePhysics.Shared
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField]
		private int _spawnAmount = 1;		// How amount per spawn

		[SerializeField]
		private float _spawnTime = 3f;		// How long between each spawn

		[SerializeField]
		private GameObject _prefab;			// The enemy prefab to be spawned

		[SerializeField]
		private Transform _parent;

		[SerializeField]
		private Transform _origin;

		[SerializeField]
		private Vector3 _originOffsetRandom;

		[SerializeField]
		private bool _willDestroySpawned = true;

		private List<GameObject> _spawnedObjects;

		protected void Start()
		{
			_spawnedObjects = new List<GameObject>();

			// Call the Spawn function after a delay of the spawnTime and
			// then continue to call after the same amount of time
			InvokeRepeating("Spawn", _spawnTime, _spawnTime);

			// Also spawn one immediatly
			Spawn();
		}

		private void Spawn()
		{
			for (int i = 0; i < _spawnAmount; i++)
			{
				// Create an instance of the enemy prefab at the randomly 
				// selected spawn point's position and rotation.
				GameObject spawned = Instantiate<GameObject>(_prefab);
				spawned.transform.SetParent(_parent, true);
				spawned.transform.position = _origin.position;

				_spawnedObjects.Add(spawned);

				// Randomize starting position
				float x = Random.Range(-_originOffsetRandom.x, _originOffsetRandom.x);
				float y = Random.Range(-_originOffsetRandom.y, _originOffsetRandom.y);
				float z = Random.Range(-_originOffsetRandom.z, _originOffsetRandom.z);
				spawned.transform.Translate(new Vector3(x, y, z));
			}
		}


		protected void Update()
		{
			if (_willDestroySpawned)
			{
				for (int s = _spawnedObjects.Count -1; s >= 0; s--)
				{
					// If sufficiently 'low', then delete to improve performance
					if (_spawnedObjects[s].transform.position.y < -10)
					{
						Destroy(_spawnedObjects[s]);
						_spawnedObjects.RemoveAt(s);
					}
				}
			}
		}
	}
}