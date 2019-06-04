using System;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class AddForceDemo : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidbody;

		[SerializeField]
		private KeyCode _posForceKeyCode = KeyCode.UpArrow;

		[SerializeField]
		private KeyCode _negForceKeyCode = KeyCode.DownArrow;

		[SerializeField]
		private Vector3 _force;

		[SerializeField]
		private ForceMode _forceMode;

		protected void FixedUpdate()
		{
			if (Input.GetKey (_posForceKeyCode))
			{
				_rigidbody.AddForce(_force, _forceMode);
			}

			if (Input.GetKey(_negForceKeyCode))
			{
				_rigidbody.AddForce( - _force, _forceMode);
			}
		}
	}
}
