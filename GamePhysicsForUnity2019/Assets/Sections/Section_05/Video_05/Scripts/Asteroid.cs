using RMC.UnityGamePhysics.Shared;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RMC.UnityGamePhysics.Sections.Section05.Video05
{
	/// <summary>
	/// Detect if Mouse Clicks on Asteroid
	/// See http://bit.ly/Unity_IPointerClickHandler
	/// </summary>
	public class Asteroid : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }

		public bool IsReleased { get { return _isReleased; } }

		[SerializeField]
		private TargetJoint2D _targetJoint2D;

		[SerializeField]
		private Rigidbody2D _rigidbody2D;

		[SerializeField]
		private float _flightSpeed = 200;

		private Vector3 _originalPosition;

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
				Vector3 mousePosition3D = Input.mousePosition;
				mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition3D);
				_targetJoint2D.target = new Vector2(mousePosition3D.x, mousePosition3D.y);
				Debug.DrawLine(transform.position, _originalPosition);
			}
		}

		public void OnPointerDown(PointerEventData pointerEventData)
		{
			if (_isReleased)
			{
				return;
			}

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
			_isReleased = true;
			_targetJoint2D.enabled = false;

			Vector3 trajectory3D = transform.position - _originalPosition;
			Vector2 trajectory2D = - trajectory3D;

			_rigidbody2D.AddForce(trajectory2D * _flightSpeed, ForceMode2D.Force);

			SoundManager.Instance.PlayAudioClip(UpsetDucksConstants.ShootAsteroidSound);
		}
	}
}