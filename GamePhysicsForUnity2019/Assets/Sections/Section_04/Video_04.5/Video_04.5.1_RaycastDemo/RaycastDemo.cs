using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	[ExecuteInEditMode]
	public class RaycastDemo : MonoBehaviour
	{
		public bool IsDebug = true;
		public float RayDistance = 10;
		public float RayDebugDuration = 0.1f;

		private Ray _ray;
		private Vector3 _rayPosition;
		private RaycastHit _raycastHit;

		void Start()
		{
			_ray = new Ray();
			_ray.direction = Vector3.down;
		}

		// Update is called once per frame 
		// (Including in EditMode to help us debug.)
		void Update()
		{
			_ray.origin = transform.position;
			_ray.direction = Vector3.down;

			if (IsDebug == true)
			{
				Debug.DrawRay(_ray.origin, _ray.direction * RayDistance, Color.red, RayDebugDuration);
			}

			Physics.Raycast(_ray, out _raycastHit, RayDistance);

			if (_raycastHit.collider != null)
			{
				//Debug.Log("Colliding with: " + _raycastHit.collider.gameObject.name);

				if (_raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
				{
					Debug.Log("The floor is close below.");
				}
			}

		}
	}
}
