using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video04
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
			Destroy(gameObject);
		}
	}
}