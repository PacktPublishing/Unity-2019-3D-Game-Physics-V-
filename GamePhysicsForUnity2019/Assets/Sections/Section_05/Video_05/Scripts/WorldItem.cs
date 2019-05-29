using System;
using UnityEngine;
using UnityEngine.Events;

namespace RMC.UnityGamePhysics.Sections.Section05.Video05
{
	public class OnHealthChangeUnityEvent : UnityEvent<float>
	{
		internal void AddEventListener(object obstacle_OnHealthChange)
		{
			throw new NotImplementedException();
		}
	}

	public class WorldItem : MonoBehaviour
	{
		public const float MIN_MAGNITUDE_FOR_DAMAGE = 3;

		public float Health { get { return _health; } }

		[SerializeField]
		private float _health = 100;

		[SerializeField]
		private float _defense = 1;

		public bool IsAlive = true;

		public OnHealthChangeUnityEvent OnHealthChange = new OnHealthChangeUnityEvent();

		protected void Start()
		{
			UpsetDucksGame.Instance.AddObstacle(this);
		}

		protected void OnCollisionEnter2D(Collision2D collision2D)
		{
			if (!IsAlive)
			{
				return;
			}

			float magnitude = collision2D.relativeVelocity.magnitude;

			if (magnitude < MIN_MAGNITUDE_FOR_DAMAGE)
			{
				return;
			}

			float damage = magnitude * 10 / _defense;
			
			_health -= damage;
			OnHealthChange.Invoke(damage);

			if (_health <= 0)
			{
				_health = 0;
			}

			//Debug.LogFormat("M = {0}, H = {1}", magnitude, _health);
		}
	}
}