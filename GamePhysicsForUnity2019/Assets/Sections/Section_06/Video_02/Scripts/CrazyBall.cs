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

		protected void Update()
		{
			/////////////////////////////
			//1. Capture Keyboard Input
			/////////////////////////////
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			_lastInput = new Vector3(moveHorizontal, 0.0f, moveVertical);

		}

		protected void FixedUpdate()
		{
			/////////////////////////////
			//2. Use Physics Motion
			/////////////////////////////
			_rigidbody.AddForce(_lastInput * _speed, ForceMode.Force);
		}
	}
}