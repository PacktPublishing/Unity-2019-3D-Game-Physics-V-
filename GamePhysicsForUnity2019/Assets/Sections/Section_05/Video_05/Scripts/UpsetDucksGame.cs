using System.Collections.Generic;
using UnityEngine;
namespace RMC.UnityGamePhysics.Sections.Section05.Video05
{
	public class UpsetDucksGame : MonoBehaviour
	{
		/// <summary>
		/// Setup "Singleton" Design Pattern
		/// See http://bit.ly/Unity_Singleton
		/// </summary>
		private static UpsetDucksGame _instance;
		public static UpsetDucksGame Instance { get { return _instance; } }

		public int Score
		{
			get
			{
				return _score;
			}
			set
			{
				_score = value;
				UpsetDucksUI.Instance.ShowScore(_score);
			}
		}

		public int Asteroids
		{
			get
			{
				return _asteroids;
			}
			set
			{
				_asteroids = value;
				UpsetDucksUI.Instance.ShowAsteroids(_asteroids);
			}
		}

		public List<WorldItem> _worldItems = new List<WorldItem>();

		private int _asteroids = 0;
		private int _score = 0;
		private bool _isGameOver = false;
		private int _upsetDuckCount = 0;
		private Asteroid _currentAsteroid = null;

		protected void Awake()
		{
			_instance = this;
		}

		protected void Start()
		{
			// TODO: Hardcode this to 3 for simplicity?
			foreach (WorldItem worldItem in _worldItems)
			{
				if (worldItem.gameObject.tag == UpsetDucksConstants.UpsetDuckTag)
				{
					_upsetDuckCount++;
				}
			}

			Score = 0;
			Asteroids = 3;
			AddAsteroid();
		}

		private void AddAsteroid()
		{
			if (Asteroids > 0)
			{
				Asteroids -= 1;
				_currentAsteroid = Catapult.Instance.AddAsteroid();
			}
			else
			{
				UpsetDucksUI.Instance.ShowResult(false);
				_isGameOver = true;
			}
		}

		public void AddObstacle(WorldItem worldItem)
		{
			_worldItems.Add(worldItem);
		}

		protected void Update()
		{
			if (_isGameOver)
			{
				return;
			}

			if (_currentAsteroid != null)
			{
				if (_currentAsteroid.IsReleased && 
					_currentAsteroid.Rigidbody2D.IsSleeping())
				{
					_currentAsteroid = null;
					AddAsteroid();
				}
			}

			foreach (WorldItem worldItem in _worldItems)
			{
				if (worldItem.gameObject.tag == UpsetDucksConstants.UpsetDuckTag)
				{
					if (worldItem.IsAlive && worldItem.Health <= 0)
					{
						worldItem.IsAlive = false;
						Score += 1;
					}
				}
			}

			if (Score >= _upsetDuckCount)
			{
				UpsetDucksUI.Instance.ShowResult(true);
				_isGameOver = true;
			}
			
		}
	}
}