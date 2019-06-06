using System;
using System.Collections.Generic;
using UnityEngine;

namespace RMC.UnityGamePhysics.Shared
{
	/// <summary>
	/// Maintain a list of AudioSources and play the next 
	/// AudioClip on the first available AudioSource.
	/// </summary>
	public class SoundManager : MonoBehaviour
	{
		/// <summary>
		/// Setup "Singleton" Design Pattern
		/// See http://bit.ly/Unity_Singleton
		/// </summary>
		private static SoundManager _instance;
		public static SoundManager Instance { get { return _instance; } }

		[SerializeField]
		private List<AudioClip> _audioClips = new List<AudioClip>();

		[SerializeField]
		private List<AudioSource> _audioSources = new List<AudioSource>();

		protected void Awake()
		{
			_instance = this;
		}

		internal void PlayAudioClip(object coinSound)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Play the AudioClip by index.
		/// </summary>
		public void PlayAudioClip(int index)
		{
			PlayAudioClip(_audioClips[index]);
		}

		/// <summary>
		/// Play the AudioClip by reference.
		/// If all sources are occupied, nothing will play.
		/// </summary>
		public void PlayAudioClip(AudioClip audioClip)
		{
			foreach (AudioSource audioSource in _audioSources)
			{
				if (!audioSource.isPlaying)
				{
					audioSource.clip = audioClip;
					audioSource.Play();
					return;
				}
			}
		}
	}
}