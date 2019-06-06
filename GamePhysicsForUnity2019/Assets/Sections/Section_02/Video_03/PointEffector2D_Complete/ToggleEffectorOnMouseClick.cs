using UnityEngine;
namespace RMC.UnityGamePhysics.Sections.Section02
{
	/// <summary>
	/// Allows the Effector2D to begin disabled, and then upon
	/// MouseClick anywhere in the Game Window, the Effector
	/// is enabled temporarily.
	/// </summary>
	public class ToggleEffectorOnMouseClick : MonoBehaviour
	{
		[SerializeField]
		private Effector2D _effector2D = null;

		[SerializeField]
		private bool _isEnabledOnAwake = false;

		[SerializeField]
		private bool _isAutoToggleOff = true;

		protected void Awake()
		{
			_effector2D.enabled = _isEnabledOnAwake;
		}

		protected void Update()
		{
			// (Optional) allow only 1-frame of enabled 
			if (_isAutoToggleOff && _effector2D.enabled)
			{
				_effector2D.enabled = false;
			}

			// Upon MouseClick anyhere, toggle enabled
			if (Input.GetMouseButtonDown(0))
			{
				_effector2D.enabled = !_effector2D.enabled;
			}
		}
	}
}