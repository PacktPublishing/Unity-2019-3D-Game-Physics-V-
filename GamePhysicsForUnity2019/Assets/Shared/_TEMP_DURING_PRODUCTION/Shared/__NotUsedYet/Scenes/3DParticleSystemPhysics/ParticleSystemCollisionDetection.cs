using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 108
namespace RMC.UnityGamePhysics.Shared
{
	public class ParticleSystemCollisionDetection : MonoBehaviour
	{
		public AudioSource audioSource;
		public AudioClip audioClip;
		public ParticleSystem particleSystem;
		public GameObject splatPrefab;

		private List<ParticleCollisionEvent> _particleCollisionEvents = new List<ParticleCollisionEvent>();

		void Start()
		{
			audioSource.clip = audioClip;
		}

		void OnParticleCollision(GameObject other)
		{
			ParticlePhysicsExtensions.GetCollisionEvents(particleSystem, other, _particleCollisionEvents);

			float particleSpeed = 0;
			Vector3 position;

			for (int i = 0; i < _particleCollisionEvents.Count; i++)
			{
				particleSpeed = _particleCollisionEvents[i].velocity.magnitude;
				PlaySound(particleSpeed);

				position = _particleCollisionEvents[i].intersection;
				CreateSplat(position);

			}
		}

		private void PlaySound(float particleSpeed)
		{
			// Example: Use collision info to affect sound
			// Convert from 0 to 100, to 0 to 1
			audioSource.volume = particleSpeed / 100;

			//Debug.Log(audioSource.volume );
			audioSource.Play();
		}

		private void CreateSplat(Vector3 position)
		{
			GameObject splat = Instantiate<GameObject>(splatPrefab, null);

			// Flat on ground 
			splat.transform.position = new Vector3(position.x, 0, position.z);
		}
	}
}
