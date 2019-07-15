using DG.Tweening;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video05
{
	public class Coin : MonoBehaviour
	{
		public bool IsAlive = true;

		protected void Update()
		{
			if (CrazyBallGame.Instance.IsGameOver)
			{
				return;
			}

			transform.Rotate(CrazyBallConstants.CoinRotationPerFrame);
		}

		/// <summary>
		/// This custom destroy method is used so that LATER
		/// we can add an fade-out animation
		/// </summary>
		public void DestroyMe()
		{
			IsAlive = false;

			//////////////////////////////////
			//1. Scale from full-size to nothing 
			//		over several milliseconds
			//////////////////////////////////
			transform.DOScale(CrazyBallConstants.CoinDestroyEndSize,
				CrazyBallConstants.CoinDestroyEndDuration).
				SetEase(Ease.OutElastic).
				OnComplete(DoTween_OnComplete);
		}

		private void DoTween_OnComplete()
		{
			//////////////////////////////////
			//2. Wait for animation to be complete
			//		Then destroy
			//////////////////////////////////
			Destroy(gameObject);
		}
	}
}