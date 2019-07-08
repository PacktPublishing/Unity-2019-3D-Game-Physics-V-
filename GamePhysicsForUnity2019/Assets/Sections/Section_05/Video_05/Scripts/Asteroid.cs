using System;
using DG.Tweening;
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
		public TargetJoint2D TargetJoint2D { get { return _targetJoint2D; } }

		public bool IsReleased { get { return _isReleased; } }

		public float MaxDragDistance = 10.3f;

		[SerializeField]
		private TargetJoint2D _targetJoint2D = null;

		[SerializeField]
		private Rigidbody2D _rigidbody2D = null;

		[SerializeField]
		private float _flightSpeed = 200;
		private Vector3 _originalPosition = new Vector3();
		private bool _isDragging = false;
		private bool _isReleased = false;

		protected void Start()
		{
			_originalPosition = transform.position;
			transform.localScale = new Vector3(0, 0, 0);
			transform.DOScale(1, 0.5f).SetEase(Ease.InOutElastic);
		}

		protected void Update()
		{
			if (_isReleased)
			{
				return;
			}

			if (_isDragging)
			{
				Vector3 newPosition = Input.mousePosition;
				newPosition = Camera.main.ScreenToWorldPoint(newPosition);

				float distance3D = Vector3.Distance(newPosition, _originalPosition);
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


			SoundManager.Instance.PlayAudioClip(UpsetDucksConstants.ShootAsteroidSound);
			UpsetDucksGame.Instance.Asteroids--;
		}
	}
}