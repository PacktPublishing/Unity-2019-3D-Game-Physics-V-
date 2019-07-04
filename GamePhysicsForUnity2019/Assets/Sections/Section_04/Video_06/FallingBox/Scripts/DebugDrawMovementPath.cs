using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section04
{
	public class DebugDrawMovementPath : MonoBehaviour
	{
		[SerializeField]
		private bool _isDebug = true;

		[SerializeField]
		private Color _color = Color.white;

		[SerializeField]
		private float _duration = 1f;

		private Vector3 _lastPosition = new Vector3();

		protected void Start()
		{
			_lastPosition = transform.position;
		}

		protected void Update ()
		{
			if (_isDebug)
			{
				Debug.DrawLine(_lastPosition, transform.position, _color, _duration);
			}

			_lastPosition = transform.position;
		}
	}
}
