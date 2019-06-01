using System;
using DG.Tweening;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video05
{
	public class Coin : MonoBehaviour
	{
		private Vector3 _rotationPerFrame = new Vector3(0, 2f, 0);

		public bool IsAlive = true;

		public void Update()
		{
			transform.Rotate(_rotationPerFrame);
		}

		public void DestroyMe()	
		{
			IsAlive = false;
			transform.DOScale(.01f, .25f).
				SetEase(Ease.InElastic).
				OnComplete(DoTween_OnComplete);
		}	

		private void DoTween_OnComplete()
		{
			Destroy(gameObject);
		}
	}
}