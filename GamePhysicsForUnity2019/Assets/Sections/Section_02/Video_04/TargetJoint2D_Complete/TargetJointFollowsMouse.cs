using UnityEngine;
namespace RMC.UnityGamePhysics.Sections.Section02
{
	/// <summary>
	/// Updates the target destination of the TargetJoint2D
	/// to follow the mouse cursor position.
	/// </summary>
	public class TargetJointFollowsMouse : MonoBehaviour
	{
		[SerializeField]
		private TargetJoint2D _targetJoint2D = null;

		protected void Update()
		{
			if (_targetJoint2D == null)
			{
				return;
			}

			Vector3 mousePosition3D = Input.mousePosition;
			mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition3D);
			_targetJoint2D.target = new Vector2(mousePosition3D.x, mousePosition3D.y);
		}
	}
}