using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace RMC.UnityGamePhysics.Sections.Section05.Video04
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
				if (UpsetDucksUI.Instance != null)
				{
					UpsetDucksUI.Instance.ShowScore(_score, _upsetDuckCount);
				}
				
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
				if (UpsetDucksUI.Instance != null)
				{
					UpsetDucksUI.Instance.ShowAsteroids(_asteroids);
				}
			}
		}

		[SerializeField]
		private GameObject _worldItemParent = null;

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
			
			Physics.sleepThreshold = UpsetDucksConstants.PhysicsSleepThreshold;

			// Reset values
			_isGameOver = false;
			_currentAsteroid = null;
			_upsetDuckCount = 0;

			////////////////////////////////
			// 1. Create new list of worldItems
			////////////////////////////////
			_worldItems = _worldItemParent.GetComponentsInChildren<WorldItem>().ToList();
			foreach (WorldItem worldItem in _worldItems)
			{
				if (worldItem.gameObject.tag == UpsetDucksConstants.UpsetDuckTag)
				{
					// Count how many upsetducks so we know how many we must 'hit'
					_upsetDuckCount++;
				}
			}

			////////////////////////////////
			// 2. Set Beginner Gameplay Values
			////////////////////////////////	
			Score = 0;
			Asteroids = UpsetDucksConstants.MaxAsteroidsPerGame;

			// Start the catapult
			AddAsteroid();
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

			////////////////////////////////
			// 3. Check for dead ducks, give points
			////////////////////////////////	
			foreach (WorldItem worldItem in _worldItems)
			{
				if (worldItem.gameObject.tag == UpsetDucksConstants.UpsetDuckTag)
				{
					if (worldItem.IsAlive && worldItem.Health <= 0)
					{
						worldItem.IsAlive = false;
						Score += UpsetDucksConstants.PointsPerUpsetDuck;
					}
				}
			}

			////////////////////////////////
			// 4. Check GameOver
			////////////////////////////////	
			if (Score >= _upsetDuckCount)
			{
				if (UpsetDucksUI.Instance != null)
				{
					UpsetDucksUI.Instance.ShowResult(true);
				}
				_isGameOver = true;
			}
		}

		private void AddAsteroid()
		{
			if (Asteroids > 0)
			{
				if (Catapult.Instance != null)
				{
					_currentAsteroid = Catapult.Instance.AddAsteroid();
				}
			}
			else
			{
				UpsetDucksUI.Instance.ShowResult(false);
				_isGameOver = true;
			}
		}

		public void DestroyCrate(Crate crate)
		{
			_worldItems.Remove(crate.gameObject.GetComponent<WorldItem>());

			StartCoroutine(DestroyGameObjectAfterXSeconds(crate.gameObject, 
				UpsetDucksConstants.CrateDestroyDelay));
		}

		private IEnumerator DestroyGameObjectAfterXSeconds(GameObject go, float seconds)
		{
			yield return new WaitForSeconds(seconds);
			Destroy(go);
		}
	}
}