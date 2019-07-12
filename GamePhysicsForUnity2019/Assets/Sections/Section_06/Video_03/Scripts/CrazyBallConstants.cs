using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video03
{
	public static class CrazyBallConstants
	{
		// Tags / Layers
		public const string CoinTag = "Coin";

		// Physics Settings
		public const float IsCrazyBallGroundedRayDistance = 1f;
		public const float CrazyBallMaxSpeed = 10f;

		// Tweakable values
		public static Vector3 CoinRotationPerFrame = new Vector3(0, 2f, 0);
		public static float CoinDestroyEndSize = 0.01f;
		public static float CoinDestroyEndDuration = 0.25f;
	}
}