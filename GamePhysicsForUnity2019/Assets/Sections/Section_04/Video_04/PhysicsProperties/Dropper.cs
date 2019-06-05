using RMC.UnityGamePhysics.Shared;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class Dropper : MonoBehaviour
	{
		public bool HasTouchedFloor {  get { return _hasTouchedFloor; } }
		private bool _hasTouchedFloor = false;

		protected void OnCollisionEnter(Collision collision)
		{
			if (IsFloor(collision))
			{
				_hasTouchedFloor = true;
			}
		}

		private bool IsFloor(Collision collision)
		{
			return collision.gameObject.layer == 
				LayerMask.NameToLayer(ProjectConstants.FloorLayer);
		}
	}
}
