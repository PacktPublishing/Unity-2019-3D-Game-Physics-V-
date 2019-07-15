using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video03
{
	public class Coin : MonoBehaviour
	{
		public bool IsAlive = true;

		protected void Update()
		{
			/////////////////////////////
			//1. Rotate the graphics
			/////////////////////////////
			transform.Rotate(CrazyBallConstants.CoinRotationPerFrame);
		}

		public void DestroyMe()
		{
			/////////////////////////////
			//2. Mark me 'dead' and delete me
			//	(Later we'll use programmatic motion here)
			/////////////////////////////
			IsAlive = false;
			Destroy(gameObject);
		}
	}
}