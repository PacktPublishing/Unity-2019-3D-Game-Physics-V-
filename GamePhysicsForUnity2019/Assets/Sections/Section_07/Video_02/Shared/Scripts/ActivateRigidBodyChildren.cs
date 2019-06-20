using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section07
{
	/// <summary>
	/// This does not completely toggle Physics, but it handles 
	/// some common functionality to make something fall or not fall.
	/// </summary>
	public class ActivateRigidBodyChildren: MonoBehaviour
	{
		[SerializeField]
		private Transform _parent = null;

		[SerializeField]
		private bool _isActivatedOnStart = false;

		[SerializeField]
		private bool _isActivatedOnClick = true;

		protected void Start()
		{
			if (_isActivatedOnStart)
			{
				Activate();
			}
		}

		protected void Update()
		{
			if (_isActivatedOnClick)
			{
				if (Input.GetMouseButton(0))
				{
					Activate();
				}
			}
		}

		public void Activate()
		{
			for (int c = 0; c < transform.childCount; c++)
			{
				Rigidbody rigidBody = _parent.GetChild(c).gameObject.GetComponent<Rigidbody>();
				if (rigidBody != null)
				{
					rigidBody.useGravity = true;
					rigidBody.isKinematic = false;
				}
			}
		}
	}
}