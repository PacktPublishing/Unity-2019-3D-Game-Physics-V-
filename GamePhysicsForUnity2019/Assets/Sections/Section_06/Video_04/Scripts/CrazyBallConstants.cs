using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video04
{
	public static class CrazyBallConstants
	{
		// Tags / Layers
		public const string CoinTag = "Coin";
		public const string FinishAreaTag = "FinishArea";
		public static string FloorLayer = "Floor";

		// Physics Settings
		public const float IsCrazyBallGroundedRayDistance = 1f;
		public const float CrazyBallMaxSpeed = 10f;

		// Tweakable values
		public static Vector3 CoinRotationPerFrame = new Vector3(0, 2f, 0);
		public static int MaxTime = 30;
		public static int PointsPerCoin = 1;

		public static string WinText = "You Win!";
		public static string LoseText = "You Lose!";
	}
}