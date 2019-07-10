using UnityEngine;
namespace RMC.UnityGamePhysics.Sections.Section06.Video05
{
	public class CrazyBallGame : MonoBehaviour
	{
		/// <summary>
		/// Setup "Singleton" Design Pattern
		/// See http://bit.ly/Unity_Singleton
		/// </summary>
		private static CrazyBallGame _instance;
		public static CrazyBallGame Instance { get { return _instance; } }

		public int Score
		{
			get
			{
				return _score;
			}
			set
			{
				_score = value;
				CrazyBallUI.Instance.ShowScore(_score);
			}
		}

		public float TimeLeft
		{
			get
			{
				return _timeLeft;
			}
			set
			{
				_timeLeft = value;
				CrazyBallUI.Instance.ShowTime(_timeLeft);
			}
		}

		public bool IsGameOver { get { return _isGameOver; } }

		private float _timeLeft = 0;
		private int _score = 0;
		private bool _isGameOver = false;

		protected void Awake()
		{
			_instance = this;
		}

		protected void Start()
		{
			Score = 0;
			TimeLeft = 30;
		}

		protected void Update()
		{
			if (_isGameOver)
			{
				return;
			}

			TimeLeft -= Time.deltaTime;

			if (TimeLeft <= 0)
			{
				TimeLeft = 0;
				EndTheGame(false);
			}
		}

		public void EndTheGame (bool isWin)
		{
			if (_isGameOver)
			{
				return;
			}

			_isGameOver = true;

			CrazyBallUI.Instance.ShowResult(isWin);
		}
	}
}