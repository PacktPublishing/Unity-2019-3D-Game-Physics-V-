using UnityEditor;
using UnityEngine;

namespace RMC.UnityGamePhysics.Shared
{
	public class FolderUtilities
	{
		private static string _thePingPath = "";
		private static int _theUpdateCount = 0;

		public static void CloseAllAndOpenOne(string path)
		{
			_thePingPath = path;
			_theUpdateCount = 0;
			EditorApplication.update += CloseAllAndOpenOneWait;
		}

		private static void CloseAllAndOpenOneWait ()
		{
			_theUpdateCount++;
			
			if (_theUpdateCount < 2)
			{
				return;
			}

			EditorUtility.FocusProjectWindow();
			Ping("Assets");

			if (_theUpdateCount < 3)
			{
				return;
			}

			EditorWindow focusedWindow = EditorWindow.focusedWindow;
			if (focusedWindow != null)
			{
				// Hard close all
				focusedWindow.SendEvent(new Event { keyCode = KeyCode.LeftArrow, type = EventType.KeyDown, alt = true });
			}

			if (_thePingPath[_thePingPath.Length - 1] == '/')
			{
				_thePingPath = _thePingPath.Substring(0, _thePingPath.Length - 1);
			}

			if (_theUpdateCount < 4)
			{
				return;
			}

			EditorUtility.FocusProjectWindow();
			Ping(_thePingPath);

			if (_theUpdateCount < 5)
			{
				return;
			}

			if (focusedWindow != null)
			{
				// Soft open selected
				focusedWindow.SendEvent(new Event { keyCode = KeyCode.RightArrow, type = EventType.KeyDown, alt = false });
			}

			EditorApplication.update -= CloseAllAndOpenOneWait;
		}

		private static void Ping (string path)
		{
			UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(UnityEngine.Object));
			Selection.activeObject = obj;
			EditorGUIUtility.PingObject(obj);
		}
	}
}