using UnityEngine;
namespace RMC.UnityGamePhysics.Sections.Section05.Video05
{
	public class Catapult : MonoBehaviour
	{
		/// <summary>
		/// Setup "Singleton" Design Pattern
		/// See http://bit.ly/Unity_Singleton
		/// </summary>
		private static Catapult _instance;
		public static Catapult Instance { get { return _instance; } }

		[SerializeField]
		private GameObject _asteroidPrefab;

		[SerializeField]
		private GameObject _centerPoint;

		protected void Awake()
		{
			_instance = this;
		}

		public Asteroid AddAsteroid()
		{
			GameObject asteroidGameObject = Instantiate(_asteroidPrefab);
			asteroidGameObject.transform.position = _centerPoint.gameObject.transform.position;

			Asteroid asteroid = asteroidGameObject.GetComponent<Asteroid>();
			return asteroid;
		}
	}
}