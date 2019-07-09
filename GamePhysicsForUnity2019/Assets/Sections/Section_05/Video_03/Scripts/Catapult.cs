using UnityEngine;
namespace RMC.UnityGamePhysics.Sections.Section05.Video03
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
		private GameObject _asteroidPrefab = null;

		[SerializeField]
		private GameObject _asteroidParent = null;

		[SerializeField]
		private GameObject _centerPoint = null;

		protected void Awake()
		{
			_instance = this;
		}

		public Asteroid AddAsteroid()
		{
			GameObject asteroidGameObject = Instantiate(_asteroidPrefab);
			asteroidGameObject.transform.SetParent(_asteroidParent.transform);
			asteroidGameObject.transform.position = _centerPoint.gameObject.transform.position;

			Asteroid asteroid = asteroidGameObject.GetComponent<Asteroid>();
			asteroid.TargetJoint2D.enabled = true;
			return asteroid;
		}
	}
}