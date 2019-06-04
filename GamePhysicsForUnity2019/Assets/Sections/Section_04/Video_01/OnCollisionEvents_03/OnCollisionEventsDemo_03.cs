using System;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class OnCollisionEventsDemo_03 : MonoBehaviour
	{
		protected void OnCollisionEnter(Collision collision)
		{
			if (IsFloor(collision))
			{
				return;
			}

			DrawContacts(collision, Color.red);

		}

		protected void OnCollisionStay(Collision collision)
		{
			if (IsFloor(collision))
			{
				return;
			}

			DrawContacts(collision, Color.blue);
		}

		protected void OnCollisionExit(Collision collision)
		{
			if (IsFloor(collision))
			{
				return;
			}

			DrawContacts(collision, Color.green);
		}

		private void DrawContacts(Collision collision, Color color)
		{
			if (collision.contacts.Length == 0)
			{
				Debug.Log("--No Contacts--" + color);
			}

			foreach (ContactPoint contact in collision.contacts)
			{
				Debug.DrawLine(contact.point, contact.point + contact.normal, color, 100);
			}
		}

		private bool IsFloor(Collision collision)
		{
			return collision.gameObject.layer == LayerMask.NameToLayer("Floor");
		}
	}
}
