using UnityEngine;
using UnityEngine.UI;

namespace RMC.UnityGamePhysics.Sections.Section05.Video05
{
	public class UpsetDucksUI : MonoBehaviour
	{
		/// <summary>
		/// Setup "Singleton" Design Pattern
		/// See http://bit.ly/Unity_Singleton
		/// </summary>
		private static UpsetDucksUI _instance;
		public static UpsetDucksUI Instance { get { return _instance; } }

		[SerializeField]
		private Text _asteroidsText;

		[SerializeField]
		private Text _scoreText;

		protected void Awake()
		{
			_instance = this;
		}

		protected void Start()
		{
			//Debug.Log("Start");
		}

		public void ShowAsteroids(int value)
		{
			_asteroidsText.text = string.Format("Asteroids: {0:00}", value);
		}

		public void ShowScore(int value)
		{
			_scoreText.text = string.Format("Score: {0:00}", value);
		}
	}
}