using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video02
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
	}
}