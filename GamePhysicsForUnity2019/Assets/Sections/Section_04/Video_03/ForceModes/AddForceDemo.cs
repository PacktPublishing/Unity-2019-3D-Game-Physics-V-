using System;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class AddForceDemo : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidbody;

		[SerializeField]
		private Vector3 _force;

		[SerializeField]
		private ForceMode _forceMode;

		protected void FixedUpdate()
		{
			if (Input.GetKey (KeyCode.UpArrow))
			{
				_rigidbody.AddForce(_force, _forceMode);
			}
		}
	}
}
