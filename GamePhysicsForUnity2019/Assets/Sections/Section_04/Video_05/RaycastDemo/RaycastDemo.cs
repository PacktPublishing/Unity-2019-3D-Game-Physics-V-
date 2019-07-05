using RMC.UnityGamePhysics.Shared;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class RaycastDemo : MonoBehaviour
	{
		[SerializeField]
		private bool _isDebug = true;

		[SerializeField]
		private float _rayDistance = 3;

		[SerializeField]
		private float _rayDuration = 0.1f;

		private Ray _ray;
		private Vector3 _rayPosition;
		private RaycastHit _raycastHit;

		protected void Start()
		{
			_ray = new Ray();
			_ray.direction = Vector3.down;
		}

		protected void Update()
		{
			_ray.origin = transform.position;
			_ray.direction = Vector3.down;

			if (_isDebug == true)
			{
				Debug.DrawRay(_ray.origin, _ray.direction * _rayDistance, Color.red, _rayDuration);
			}

			// ************************
			// PHYSICS - Here is the Raycast functionality
			// ************************
			Physics.Raycast(_ray, out _raycastHit, _rayDistance);

			if (_raycastHit.collider != null)
			{
				//Debug.Log("Colliding with: " + _raycastHit.collider.gameObject.name);

				if (_raycastHit.collider.gameObject.layer == 
					LayerMask.NameToLayer(ProjectConstants.FloorLayer))
				{
					Debug.Log("The floor is close below.");
				}

				if (_raycastHit.collider.gameObject.layer ==
					LayerMask.NameToLayer(ProjectConstants.RampLayer))
				{
					Debug.Log("The ramp is close below.");
				}
			}
		}
	}
}
