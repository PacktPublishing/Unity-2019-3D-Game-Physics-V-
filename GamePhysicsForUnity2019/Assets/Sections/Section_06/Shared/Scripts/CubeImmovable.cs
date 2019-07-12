using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Shared
{
	/// <summary>
	/// Let the cube fall from starting position and come to a rest
	/// The lock it in place so the crazy ball cannot move it
	/// </summary>
	public class CubeImmovable : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidBody = null;

		protected void Update()
		{
			if (_rigidBody.IsSleeping() && !_rigidBody.isKinematic)
			{
				_rigidBody.isKinematic = true;
			}
		}
	}
}