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

		public void DestroyMe()
		{
			IsAlive = false;

			transform.DOScale(CrazyBallConstants.CoinDestroyEndSize,
				CrazyBallConstants.CoinDestroyEndDuration).
				SetEase(Ease.OutElastic).
				OnComplete(DoTween_OnComplete);
		}

		private void DoTween_OnComplete()
		{
			Destroy(gameObject);
		}
	}
}