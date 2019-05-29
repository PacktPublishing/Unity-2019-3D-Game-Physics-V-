using RMC.UnityGamePhysics.Shared;
using System.Collections.Generic;
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

		private float _timeLeft = 0;
		private int _score = 0;
		private bool _isGameOver = false;
		private int _upsetDuckCount = 0;

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
				CrazyBallUI.Instance.ShowResult(false);
				SoundManager.Instance.PlayAudioClip(CrazyBallConstants.LoseSound);
				_isGameOver = true;
			}
			
		}
	}
}