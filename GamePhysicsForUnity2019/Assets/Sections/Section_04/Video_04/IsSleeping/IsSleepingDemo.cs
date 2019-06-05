using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class IsSleepingDemo : MonoBehaviour
	{
		public Rigidbody Rigidbody;

		private bool _wasFoundSleeping = false;

		protected void Update()
		{
			if (!_wasFoundSleeping)
			{
				if (Rigidbody.IsSleeping())
				{
					_wasFoundSleeping = true;
					Debug.Log("Now I am Sleeping.");
				}
			}
		}
	}

}
