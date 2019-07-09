namespace RMC.UnityGamePhysics.Sections.Section05.Video05
{
	public static class UpsetDucksConstants 
	{
		// Sounds
		public const int ShootAsteroidSound = 0;
		public const int WinSound = 1;
		public const int LoseSound = 2;
		public const int CollisionSound = 3;
		public const int ExplosionSound = 4;

		// Tags
		public const string UpsetDuckTag = "UpsetDuck";

		// Physics Settings
		// Default 0.005 - Change to end turns more quickly
		public const float PhysicsSleepThreshold = 0.05f;

		// Tweakable values
		public const float MinMagnitudeForDamage = 3;
		public const float MinCrateHealthChangeForReaction = 10;
		public const float MinUpsetDuckHealthChangeForReaction = 10;
		
		public const int MaxAsteroidsPerGame = 3;
		public const int PointsPerUpsetDuck = 1;
		public const float UpsetDuckSpriteFlickerDelay = 0.5f;

		public const float ExplosionDestroyDelay = 0.25f;
		public const float CrateDestroyDelay = 0;
	}
}