using System;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class AddTorqueDemo : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidbody = null;

		[SerializeField]
		private KeyCode _posForceKeyCode = KeyCode.UpArrow;

		[SerializeField]
		private KeyCode _negForceKeyCode = KeyCode.DownArrow;

		[SerializeField]
		private Vector3 _force = new Vector3();

		[SerializeField]
		private ForceMode _forceMode = ForceMode.Force;

		protected void FixedUpdate()
		{
			if (Input.GetKey (_posForceKeyCode))
			{
				_rigidbody.AddTorque(_force, _forceMode);
			}

			if (Input.GetKey(_negForceKeyCode))
			{
				_rigidbody.AddTorque( - _force, _forceMode);
			}
		}
	}
}
