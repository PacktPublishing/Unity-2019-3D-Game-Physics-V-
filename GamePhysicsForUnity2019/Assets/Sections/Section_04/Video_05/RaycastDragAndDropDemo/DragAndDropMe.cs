using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class DragAndDropMe : MonoBehaviour
	{
		[SerializeField]
		private bool _isDebug = true;

		private float _rayDistance = 10;
		private bool _isDragging;
		private Vector3 _targetScreenSpacePosition;
		private Vector3 _targetDragOffset;
		private GameObject _target;

		private void Start()
		{
			_target = this.gameObject;
		}

		void Update()
		{
			RaycastHit hitInfo;
			GameObject hitObject = GameObjectUnderMouse(out hitInfo);

			if (Input.GetMouseButtonDown(0))
			{
				if (_target == hitObject)
				{
					_isDragging = true;
					_targetScreenSpacePosition = Camera.main.WorldToScreenPoint(_target.transform.position);

					_targetDragOffset = _target.transform.position - 
						Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _targetScreenSpacePosition.z));

					ResetVelocity(true);
				}
			}

			if (Input.GetMouseButtonUp(0))
			{
				if (_isDragging)
				{
					_isDragging = false;
					ResetVelocity(false);
				}

			}

			if (_isDragging)
			{
				Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _targetScreenSpacePosition.z);
				Vector3 mouseOffset = Camera.main.ScreenToWorldPoint(mousePosition) + _targetDragOffset;
				_target.transform.position = mouseOffset;
			}
		}

		void ResetVelocity(bool isKinematic)
		{
			//Removes all speed upon release. Maybe this is desired.
			Rigidbody rigidBody = _target.GetComponent<Rigidbody>();
			if (rigidBody != null)
			{
				rigidBody.velocity = new Vector3();
				rigidBody.angularVelocity = new Vector3();
				rigidBody.isKinematic = isKinematic;
			}
		}

		GameObject GameObjectUnderMouse(out RaycastHit hit)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// ************************
			// PHYSICS - Here is the Raycast functionality
			// ************************
			GameObject target = null;
			if (Physics.Raycast(ray.origin, ray.direction * _rayDistance, out hit))
			{
				target = hit.collider.gameObject;
			}

			if (_isDebug == true)
			{
				Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.red, 0.1f);
			}

			return target;
		}
	}
}