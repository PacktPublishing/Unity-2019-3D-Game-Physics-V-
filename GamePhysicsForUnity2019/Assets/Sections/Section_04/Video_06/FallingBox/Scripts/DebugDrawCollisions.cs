using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class DebugDrawCollisions : MonoBehaviour
	{
		[SerializeField]
		private bool _isDebug = true;

		[SerializeField]
		private Color _color = Color.white;

		[SerializeField]
		private float _distance = 0.5f;

		[SerializeField]
		private float _duration = 1f;

		protected void OnCollisionEnter(Collision collision)
		{
			if (_isDebug)
			{
				foreach (ContactPoint contact in collision.contacts)
				{
					Debug.DrawRay(contact.point, contact.normal.normalized * _distance, _color, _duration);
				}
			}
		}
	}
}
