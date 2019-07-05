using System;
using UnityEngine;
using UnityEngine.UI;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class DropperGame : MonoBehaviour
	{
		[SerializeField]
		private Text _velocityText = null;

		[SerializeField]
		private Text _scoreText = null;

		[SerializeField]
		private GameObject _dropperParent = null;

		[SerializeField]
		private GameObject _dropperPrefab = null;

		[SerializeField]
		private Vector3 _dropperPosition = new Vector3();

		private Rigidbody _dropperRigidBody = null;

		private bool _isDragging = false;

		private float _score = 0;
		private float _maxVelocity = 0;

		protected void Start()
		{
			SetScore(0);
			AddDropper();
		}

		private void AddDropper()
		{
			GameObject dropper = Instantiate(_dropperPrefab);
			dropper.transform.SetParent(_dropperParent.transform);

			_dropperRigidBody = dropper.GetComponent<Rigidbody>();

			if (_dropperRigidBody != null)
			{
				// 1. Access Physics Properties
				_dropperRigidBody.useGravity = false;
				_dropperRigidBody.isKinematic = true;
				_dropperRigidBody.position = _dropperPosition;

				//.005
				_dropperRigidBody.sleepThreshold = .1f;

			}

			_isDragging = true;

			_maxVelocity = 0;
			SetVelocity(_maxVelocity);
			
		}

		private void SetScore(float value)
		{
			_score = value;
			_scoreText.text = string.Format("{0:000}: Score", _score);
		}

		private void SetVelocity(float value)
		{
			_velocityText.text = string.Format("Velocity: {0:000}", value);
		}


		protected void Update()
		{
			if (_isDragging)
			{
				float y = _dropperRigidBody.position.y;
				float z = _dropperRigidBody.position.z;

				Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(
					new Vector3(Input.mousePosition.x, 
								Input.mousePosition.y, 
								6));

				Vector3 newPosition = new Vector3(mouseScreenPosition.x, y, z);
				_dropperRigidBody.position = newPosition;

				if (Input.GetMouseButton(0))
				{
					_isDragging = false;

					// 2. Access Physics Properties
					_dropperRigidBody.useGravity = true;
					_dropperRigidBody.isKinematic = false;
				}
			}
			else
			{
				// 3. Access Physics Properties
				if (_dropperRigidBody.IsSleeping())
				{
					Dropper dropper = _dropperRigidBody.gameObject.GetComponent<Dropper>();

					if (dropper != null)
					{
						if (!dropper.HasTouchedFloor)
						{
							SetScore(_score + _maxVelocity);
						}
					}

					_dropperRigidBody = null;
					AddDropper();
				}
				else
				{
					// 4. Access Physics Properties
					_maxVelocity = Math.Max(_maxVelocity,
						_dropperRigidBody.velocity.magnitude);

					SetVelocity(_maxVelocity);
				}
			}
		}
	}
}
