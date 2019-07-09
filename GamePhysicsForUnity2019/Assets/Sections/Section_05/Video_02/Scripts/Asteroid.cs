using UnityEngine;
using UnityEngine.EventSystems;

namespace RMC.UnityGamePhysics.Sections.Section05.Video02
{
	/// <summary>
	/// Detect if Mouse Clicks on Asteroid
	/// See http://bit.ly/Unity_IPointerClickHandler
	/// </summary>
	public class Asteroid : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }
		public TargetJoint2D TargetJoint2D { get { return _targetJoint2D; } }

		/// <summary>
		/// Has it been released by the mouse yet
		/// </summary>
		public bool IsReleased { get { return _isReleased; } }

		/// <summary>
		/// How far can it be dragged from the center point
		/// </summary>
		public float MaxDragDistance = 2;

		[SerializeField]
		private TargetJoint2D _targetJoint2D = null;

		[SerializeField]
		private Rigidbody2D _rigidbody2D = null;

		/// <summary>
		/// The speed factor applied once the mouse drag is released
		/// </summary>
		[SerializeField]
		private float _flightSpeed = 400;

		private Vector3 _originalPosition = new Vector3();
		private bool _isDragging = false;
		private bool _isReleased = false;

		protected void Start()
		{
			_originalPosition = transform.position;
		}

		protected void Update()
		{
			if (_isReleased)
			{
				return;
			}
			if (_isDragging)
			{
				Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

				float distance3D = Vector2.Distance(newPosition, _originalPosition);
				if (distance3D < MaxDragDistance)
				{
					_targetJoint2D.target = new Vector2(newPosition.x, newPosition.y);
				}

				Debug.DrawLine(transform.position, _originalPosition);
			}
		}

		public void OnPointerDown(PointerEventData pointerEventData)
		{
			if (_isReleased)
			{
				return;
			}

			_originalPosition = transform.position;
			_isDragging = true;
			_targetJoint2D.enabled = true;
		}

		public void OnPointerUp(PointerEventData pointerEventData)
		{
			if (_isReleased)
			{
				return;
			}
			_isDragging = false;
			_targetJoint2D.enabled = false;

			ReleaseMe();
		}

		private void ReleaseMe()
		{
			_isReleased = true;
			Vector3 trajectory3D = transform.position - _originalPosition;
			Vector2 trajectory2D = -trajectory3D;
			_rigidbody2D.AddForce(trajectory2D * _flightSpeed, ForceMode2D.Force);
		}
	}
}