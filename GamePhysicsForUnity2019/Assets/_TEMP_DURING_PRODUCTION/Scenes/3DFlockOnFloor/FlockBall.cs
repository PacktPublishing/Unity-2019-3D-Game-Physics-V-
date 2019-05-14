using UnityEngine;

namespace RMC.UnityGamePhysics.Shared
{
	public class FlockBall : MonoBehaviour
	{

		public float Speed = 5;

		private Rigidbody rb;

		void Start()
		{
			rb = GetComponent<Rigidbody>();
		}

		void FixedUpdate()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

			rb.AddForce(movement * Speed);
		}
	}
}