using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class OnCollisionEventsDemo_01 : MonoBehaviour
	{
		protected void OnCollisionEnter(Collision collision)
		{
			Debug.Log("1. Enter");
		}

		protected void OnCollisionStay(Collision collision)
		{
			Debug.Log("2. Stay");
		}

		protected void OnCollisionExit(Collision collision)
		{
			Debug.Log("3. Exit");
		}
	}
}
