using UnityEngine;

namespace RMC.UnityGamePhysics.Shared
{
	public class CopyAndConnect : MonoBehaviour
	{
		public bool willCreate = true;
		public int totalToCreate = 5;

		void Start()
		{
			if (!willCreate)
			{
				return;
			}

			GameObject parent = this.gameObject;

			HingeJoint hingeJoint = this.GetComponent<HingeJoint>();

			// Use the original offset, for every new link in the chain
			Vector3 positionOffset = hingeJoint.transform.position - hingeJoint.connectedBody.transform.position;
			hingeJoint.connectedAnchor = positionOffset / 2;
			Debug.Log(positionOffset);

			for (int i = 0; i < totalToCreate; i++)
			{
				GameObject childGO = Instantiate<GameObject>(this.gameObject, this.transform.parent);

				CopyAndConnect childCopyAndConnect = childGO.GetComponent<CopyAndConnect>();
				childCopyAndConnect.willCreate = false;
				childCopyAndConnect.transform.position = parent.transform.position + positionOffset;

				HingeJoint childHingeJoint = childGO.GetComponent<HingeJoint>();
				childHingeJoint.connectedBody = parent.GetComponent<Rigidbody>();
				childHingeJoint.connectedAnchor = positionOffset / 2;

				parent = childGO;
			}
		}
	}
}
