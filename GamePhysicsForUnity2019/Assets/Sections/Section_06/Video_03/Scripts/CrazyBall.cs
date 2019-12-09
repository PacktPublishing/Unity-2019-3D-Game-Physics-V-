using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video03
{
	public class CrazyBall : MonoBehaviour
	{
		
//Disable a harmless warning shown by the code editor
#pragma warning disable 0414 // The field is assigned but its value is never used
		[SerializeField]
		private bool _isDebug = false;
#pragma warning restore
		
		[SerializeField]
		private float _speed = 20;

		[SerializeField]
		private Rigidbody _rigidbody = null;

		private Vector3 _lastInput = Vector3.zero;

		private bool _isSpeedTooHigh = false;

		protected void Update()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			_lastInput = new Vector3(moveHorizontal, 0.0f, moveVertical);
			_isSpeedTooHigh = _rigidbody.velocity.magnitude > CrazyBallConstants.CrazyBallMaxSpeed;
		}

		protected void FixedUpdate()
		{
			// Only allow forces if we are on the ground and not going too fast
			if (!_isSpeedTooHigh)
			{
				_rigidbody.AddForce(_lastInput * _speed, ForceMode.Force);
			}
		}

		protected void OnTriggerEnter(Collider collider)
		{
			/////////////////////////////
			//1. Detect and collect the coin
			/////////////////////////////
			if (collider.gameObject.tag == CrazyBallConstants.CoinTag)
			{
				Coin coin = collider.gameObject.GetComponent<Coin>();
				if (coin != null && coin.IsAlive)
				{
					coin.DestroyMe();
				}
			}
		}
	}
}