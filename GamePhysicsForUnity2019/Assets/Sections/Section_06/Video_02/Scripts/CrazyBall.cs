using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video02
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