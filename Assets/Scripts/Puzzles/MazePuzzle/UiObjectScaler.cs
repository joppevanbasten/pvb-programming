﻿using UnityEngine;
using UnityEngine.UI;

namespace DN.UI
{
	/// <summary>
	/// Scale the ui object correctly
	/// </summary>
	public class UiObjectScaler : MonoBehaviour
	{
		[SerializeField] private float width;
		[SerializeField] private float height;
		[SerializeField] private float posX;
		[SerializeField] private float posY;
		[SerializeField] private bool changePosition = false;
		[SerializeField] private bool isSquare = false;
		private RectTransform rectTransform;
		private BoxCollider2D collider;
		private bool useCollider;

		private void Awake()
		{
			if(isSquare)
			{
				//AspectRatioFitter af = gameObject.AddComponent<AspectRatioFitter>();
				//af.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
			}
				
			rectTransform = GetComponent<RectTransform>();
			useCollider = GetComponent<BoxCollider2D>();
			if(useCollider)
				collider = GetComponent<BoxCollider2D>();
			SetValues();
		}

		public void ChangeValues(Vector2 size, Vector2 position, bool changePos)
		{
			width = size.x;
			height = size.y;
			posX = position.x;
			posY = position.y;
			changePosition = changePos;
			SetValues();
		}

		public Vector2 GetSize()
		{
			return new Vector2(width, height);
		}

		public void SetTransform(RectTransform t)
		{
			rectTransform = t;
		}

		public void SetSquare(bool square)
		{
			isSquare = square;
		}

		private void SetValues()
		{
			if (isSquare)
			{
				rectTransform.sizeDelta = new Vector2(width * Screen.width, height * Screen.width);
			}
			else
			{
				rectTransform.sizeDelta = new Vector2(width * Screen.width, height * Screen.height);
			}
			if (isSquare)
				transform.localScale = new Vector3(0.5f, 0.5f, 1);
			if (useCollider)
				collider.size = new Vector2(width * Screen.width, height * Screen.height);
			if (changePosition)
			{
				if(isSquare)
				{
					rectTransform.localPosition = new Vector2(posX * Screen.width, posY * Screen.width);
				}
				else
				{
					rectTransform.localPosition = new Vector2(posX * Screen.width, posY * Screen.height);
				}

			}
		}

		private void Update()
		{
			SetValues();
		}
	}
}
