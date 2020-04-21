﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DN.UI
{
	/// <summary>
	/// Takes care of the lives the player has to be added to Canvas
	/// </summary>
	public class Lives : MonoBehaviour
	{

		public int currentLives
		{
			get { return hearts.Count; }
		}

		[SerializeField] private int lives = 3;
		[SerializeField] private float size = 0.0015f;
		private Sprite heart;
		private List<GameObject> hearts;
		private RectTransform canvas;

		private void Start()
		{
			canvas = gameObject.GetComponent<RectTransform>();
			hearts = new List<GameObject>();
			heart = Resources.Load<Sprite>("Sprites/heart");

			for (int i = 0; i < lives; i++)
			{
				GameObject g = new GameObject($"heart {i}");
				g.AddComponent<Image>().sprite = heart;
				RectTransform rTransform = g.GetComponent<RectTransform>();
				g.transform.parent = transform;
				rTransform.sizeDelta = new Vector2(size * canvas.rect.height, size * canvas.rect.height);
				rTransform.position = new Vector2(rTransform.rect.width + (size * canvas.rect.width / 4 + rTransform.rect.width ) * i, canvas.rect.height - rTransform.rect.height);
				hearts.Add(g);
			}

		}

		public void LoseLife()
		{
			if (hearts.Count > 0)
			{
				Destroy(hearts[hearts.Count - 1]);
				hearts.RemoveAt(hearts.Count - 1);
			}
			else
			{
				Debug.LogError("There are no lives left");
			}
		}
	}
}
