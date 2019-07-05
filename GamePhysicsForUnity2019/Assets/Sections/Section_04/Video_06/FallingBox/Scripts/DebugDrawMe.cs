using System.Collections.Generic;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class DebugDrawMe : MonoBehaviour
	{
		[SerializeField]
		private bool _isDebug = true;

		[SerializeField]
		private Color _color = Color.white;

		[SerializeField]
		private KeyCode _keyCode = KeyCode.D;

		private List<Vector3> _debugPositionList = new List<Vector3>();

		protected void Start ()
		{
			Gizmos.color = _color;
		}

		protected void Update ()
		{
			if (_isDebug)
			{
				if (Input.GetKeyDown (_keyCode))
				{
					Debug.Log("Draw Me!");

					// Add the current position into a list
					_debugPositionList.Add(transform.position);
				}
			}
		}

		/// <summary>
		/// Implement OnDrawGizmos if you want to draw gizmos that are always drawn.
		/// This function does not get called if the component is collapsed in the Inspector.
		/// </summary>
		protected void OnDrawGizmos()
		{
			// Re-render all the cubes in the list every frame
			foreach (Vector3 debugPosition in _debugPositionList)
			{
				Gizmos.DrawWireCube(debugPosition, new Vector3(1, 1, 1));
			}
		}
	}
}
