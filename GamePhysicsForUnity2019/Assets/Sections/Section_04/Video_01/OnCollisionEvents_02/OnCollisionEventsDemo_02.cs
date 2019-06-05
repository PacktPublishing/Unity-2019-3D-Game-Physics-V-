using RMC.UnityGamePhysics.Shared;
using System;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class OnCollisionEventsDemo_02 : MonoBehaviour
	{
		protected void OnCollisionEnter(Collision collision)
		{
			if (IsFloor(collision))
			{
				return;
			}

			Debug.Log("1. Enter: " + collision.gameObject.name);
		}

		protected void OnCollisionStay(Collision collision)
		{
			if (IsFloor(collision))
			{
				return;
			}

			Debug.Log("2. Stay: " + collision.gameObject.name);
		}

		protected void OnCollisionExit(Collision collision)
		{
			if (IsFloor(collision))
			{
				return;
			}

			Debug.Log("3. Exit: " + collision.gameObject.name);
		}

		private bool IsFloor(Collision collision)
		{
			return collision.gameObject.layer == 
				LayerMask.NameToLayer(ProjectConstants.FloorLayer);
		}
	}
}
