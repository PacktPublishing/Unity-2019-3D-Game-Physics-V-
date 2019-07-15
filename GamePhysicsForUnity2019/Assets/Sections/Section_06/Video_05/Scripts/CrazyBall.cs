using RMC.UnityGamePhysics.Shared;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video05
{
	public class CrazyBall : MonoBehaviour
	{
		[SerializeField]
		private bool _isDebug = false;

		[SerializeField]
		private float _speed = 20;

		[SerializeField]
		private Rigidbody _rigidbody = null;

		private Vector3 _lastInput = Vector3.zero;

		private Ray _isCrazyBallGroundedRay;

		private bool _isCrazyBallGrounded = true;
		private bool _isSpeedTooHigh = false;

		protected void Start()
		{
			_isCrazyBallGroundedRay = new Ray(transform.position, Vector3.down);
		}

		protected void Update()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			_lastInput = new Vector3(moveHorizontal, 0.0f, moveVertical);
			_isSpeedTooHigh = _rigidbody.velocity.magnitude > CrazyBallConstants.CrazyBallMaxSpeed;
		}

		protected void FixedUpdate()
		{
			if (CrazyBallGame.Instance.IsGameOver)
			{
				// When the game ends, come to a quick but gradual stop
				_rigidbody.angularDrag = CrazyBallConstants.CrazyBallAngularDragAtFinishArea;
				return;
			}

			// Check if we are on the ground (or close)
			_isCrazyBallGroundedRay.origin = transform.position;
			_isCrazyBallGrounded = Physics.Raycast(_isCrazyBallGroundedRay,
				CrazyBallConstants.IsCrazyBallGroundedRayDistance);

			if (_isDebug)
			{
				Debug.DrawRay(_isCrazyBallGroundedRay.origin, _isCrazyBallGroundedRay.direction,
								Color.red, 0.01f);
			}

			// Only allow forces if we are on the ground and not going too fast
			if (_isCrazyBallGrounded && !_isSpeedTooHigh)
			{
				_rigidbody.AddForce(_lastInput * _speed, ForceMode.Force);
			}
		}

		protected void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.layer == LayerMask.NameToLayer (CrazyBallConstants.FloorLayer))
			{
				return;
			}

			SoundManager.Instance.PlayAudioClip(CrazyBallConstants.CollisionSound);
		}

		protected void OnTriggerEnter(Collider collider)
		{
			if (collider.gameObject.tag == CrazyBallConstants.CoinTag)
			{
				Coin coin = collider.gameObject.GetComponent<Coin>();
				if (coin != null && coin.IsAlive)
				{
					coin.DestroyMe();
					CrazyBallGame.Instance.Score += CrazyBallConstants.PointsPerCoin;

					//////////////////////////////////
					//1. Play Sound
					//////////////////////////////////
					SoundManager.Instance.PlayAudioClip(CrazyBallConstants.CoinSound);
				}
			}

			if (collider.gameObject.tag == CrazyBallConstants.FinishAreaTag)
			{
				CrazyBallGame.Instance.EndTheGame(true);
			}
		}
	}
}