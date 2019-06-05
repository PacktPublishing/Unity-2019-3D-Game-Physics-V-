using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RMC.UnityGamePhysics.Sections.Section07
{
	public class TrajectoryPrediction : MonoBehaviour
	{
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
		private GameObject _markerPrefab;

		private Vector3 _forceForLastPrediction;

		//private Scene sceneMain;
		private Scene scenePrediction;
		private PhysicsScene scenePredictionPhysics;
		private PhysicsScene sceneMainPhysics;
		private List<GameObject> _markerList = new List<GameObject>();

		private void Start()
		{
			//Physics.autoSimulation = false;
			//sceneMain = SceneManager.CreateScene("MainScene");
			//sceneMainPhysics = sceneMain.GetPhysicsScene();

			CreateSceneParameters sceneParam = new CreateSceneParameters(LocalPhysicsMode.Physics3D);
			scenePrediction = SceneManager.CreateScene("ScenePredicitonPhysics", sceneParam);
			scenePredictionPhysics = scenePrediction.GetPhysicsScene();

		}

		protected void OnValidate()
		{
			ShootBall();
		}

		private void FixedUpdate()
		{
			return;
			if (!sceneMainPhysics.IsValid())
				return;

			sceneMainPhysics.Simulate(Time.fixedDeltaTime);
		}

		private void Update()
		{
				
		}

		private void ShootBall()
		{

			if (!sceneMainPhysics.IsValid() || !scenePrediction.IsValid() || !scenePredictionPhysics.IsValid())
			{
				return;
			}
				

			if (_forceForLastPrediction == _force)
			{
				return;
			}

			_forceForLastPrediction = _force;

			DestroyMarkers();

			//GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			//SceneManager.MoveGameObjectToScene(ball, SceneManager.GetActiveScene());
			//ball.AddComponent<Rigidbody>().AddForce(_force, ForceMode.Impulse);

			GameObject predictionBall = Instantiate(_markerPrefab);
			SceneManager.MoveGameObjectToScene(predictionBall, scenePrediction);
			predictionBall.AddComponent<Rigidbody>().AddForce(_force, ForceMode.Impulse);

			for (int i = 0; i < _predictionTotalIterations; i++)
			{
				scenePredictionPhysics.Simulate(Time.fixedDeltaTime);

				if (i % _predictionSteps == 0)
				{
					GameObject pathMarkSphere = Instantiate(_markerPrefab);
					_markerList.Add(pathMarkSphere);

					pathMarkSphere.transform.position = predictionBall.transform.position;
					SceneManager.MoveGameObjectToScene(pathMarkSphere, scenePrediction);
				}
			}

			Destroy(predictionBall);

		}

		private void DestroyMarkers()
		{
			for (int i = _markerList.Count - 1; i >= 0; i--)
			{
				Destroy(_markerList[i]);
			}
		}

		protected void OnDestroy()
		{
			DestroyMarkers();
		}
	}
}