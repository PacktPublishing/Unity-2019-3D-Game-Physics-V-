using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class OnTriggerEventsDemo_01 : MonoBehaviour
	{
		protected void OnTriggerEnter (Collider collider)
		{
			Debug.Log("1. Enter");
		}

		protected void OnTriggerStay (Collider collider)
		{
			Debug.Log("2. Stay");
		}

		protected void OnTriggerExit (Collider collider)
		{
			Debug.Log("3. Exit");
		}
	}
}
