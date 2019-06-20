using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RMC.UnityGamePhysics.Sections.Section07
{
	public class TrajectoryPrediction : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidBody = null;

		public Vector3 Force
		{
			set
			{
				_force = value;
			}
			get
			{
				return _force;
			}
		}
		[SerializeField]
		private Vector3 _force = new Vector3(0f, 20f, 15f);

		[Range(1, 10)]
		[SerializeField]
		private int _predictionSteps = 50;

		[Range(5, 500)]
		[SerializeField]
		private int _predictionTotalIterations = 500;

		[SerializeField]
		private GameObject _markerPrefab = null;

		private Vector3 _forceLastUsed;
		private int _predictionStepsLastUsed;
		private int _predictionTotalIterationsLastUsed;

		//private Scene sceneMain;
		private Scene scenePrediction;
		private PhysicsScene scenePredictionPhysics;
		private PhysicsScene sceneMainPhysics;
		private List<GameObject> _markerList = new List<GameObject>();

		protected void Start()
		{
			CreateSceneParameters sceneParam = new CreateSceneParameters(LocalPhysicsMode.Physics3D);
			scenePrediction = SceneManager.CreateScene("ScenePredicitonPhysics", sceneParam);
			scenePredictionPhysics = scenePrediction.GetPhysicsScene();

			RebuildAndDoPrediction_Coroutine();

			PredictForce(true);
		}

		protected void OnValidate()
		{
			PredictForce(false);
		}

		protected void OnGUI()
		{
			if (GUILayout.Button("Refresh Trajectory"))
			{
				PredictForce(true);
			}

			if (GUILayout.Button("Use Force"))
			{
				UseForce();
			}
		}

		protected void OnDestroy()
		{
			DestroyMarkers();
		}

		private void UseForce()
		{
			_rigidBody.AddForce(_force, ForceMode.Impulse);
			DestroyMarkers();
		}

		private void PredictForce(bool mustPredict)
		{

			if (!sceneMainPhysics.IsValid() || !scenePrediction.IsValid() || !scenePredictionPhysics.IsValid())
			{
				return;
			}

			if (mustPredict || _predictionSteps != _predictionStepsLastUsed || 
				_predictionTotalIterations != _predictionTotalIterationsLastUsed)
			{
				StartCoroutine(RebuildAndDoPrediction_Coroutine());
			}
			else
			{
				if (_forceLastUsed == _force)
				{
					return;
				}
			}

			_forceLastUsed = _force;
			_predictionStepsLastUsed = _predictionSteps;
			_predictionTotalIterationsLastUsed = _predictionTotalIterations;

			StartCoroutine(UseMarkers_Coroutine());

		}

		private IEnumerator RebuildAndDoPrediction_Coroutine()
		{
			yield return new WaitForSeconds(0.25f);
			RebuildMarkers();
			DoPrediction();
		}

		private IEnumerator UseMarkers_Coroutine()
		{
			yield return new WaitForSeconds(0.25f);
			DoPrediction();
		}

		private void DestroyMarkers()
		{
			for (int i = _markerList.Count - 1; i >= 0; i--)
			{
				Destroy(_markerList[i]);
			}
			_markerList.Clear();
		}


		private void RebuildMarkers()
		{
			DestroyMarkers();

			int totalToCreate = _predictionTotalIterations / _predictionSteps + 1;

			for (int i = 0; i < totalToCreate; i++)
			{
				GameObject marker = Instantiate(_markerPrefab);
				marker.transform.position = transform.position;
				SceneManager.MoveGameObjectToScene(marker, scenePrediction);
				marker.name = string.Format("{0} - ({1})", marker.name, i);
				_markerList.Add(marker);
			}
		}

		private void DoPrediction()
		{
			GameObject predictionBall = Instantiate(_markerPrefab);
			SceneManager.MoveGameObjectToScene(predictionBall, scenePrediction);

			Rigidbody rigidbody = predictionBall.AddComponent<Rigidbody>();
			rigidbody.position = transform.position;
			rigidbody.AddForce(_force, ForceMode.Impulse);

			int markerIndex = 0;
			for (int i = 0; i < _predictionTotalIterations; i++)
			{
				scenePredictionPhysics.Simulate(Time.fixedDeltaTime);

				if (i % _predictionSteps == 0)
				{
					_markerList[markerIndex].transform.position = predictionBall.transform.position;
					markerIndex++;
				}
			}

			Destroy(predictionBall);
		}
	}
}