﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
//标识牌
namespace PLAYERTWO.PlatformerProject
{
	[RequireComponent(typeof(Collider))]
	public class Sign : MonoBehaviour
	{
		[Header("Sign Settings")]
		[TextArea(15, 20)]
		public string text = "Hello World";
		public float viewAngle = 90f;//可观察到的角度范围

		[Header("Canvas Settings")]
		public Canvas canvas;
		public Text uiText;
		public float scaleDuration = 0.25f;

		[Space(15)]
		public UnityEvent onShow; //显示
		public UnityEvent onHide; //隐藏

		protected Vector3 m_initialScale;//初始化scale
		protected bool m_showing; //是否在展示中
		protected Collider m_collider;//碰撞器
		protected Camera m_camera;

		public virtual void Show()
		{
			if (!m_showing)
			{
				m_showing = true;
				onShow?.Invoke();
				StopAllCoroutines();
				StartCoroutine(Scale(Vector3.zero, m_initialScale));
			}
		}

		//隐藏
		public virtual void Hide()
		{
			if (m_showing)
			{
				m_showing = false;
				onHide?.Invoke();
				StopAllCoroutines();
				StartCoroutine(Scale(canvas.transform.localScale, Vector3.zero));
			}
		}

		//缩放这个指示牌
		protected virtual IEnumerator Scale(Vector3 from, Vector3 to)
		{
			var elapsedTime = 0f;
			var scale = canvas.transform.localScale;

			while (elapsedTime < scaleDuration)
			{
				scale = Vector3.Lerp(from, to, (elapsedTime / scaleDuration));
				canvas.transform.localScale = scale;
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			canvas.transform.localScale = to;
		}

		protected virtual void Awake()
		{
			uiText.text = text;
			m_initialScale = canvas.transform.localScale;
			canvas.transform.localScale = Vector3.zero; //这里直接把ui的canvas大小变成0，避免了重构
			canvas.gameObject.SetActive(true);
			m_collider = GetComponent<Collider>();
			m_camera = Camera.main;
		}

		//可触发
		protected virtual void OnTriggerExit(Collider other)
		{
			if (other.CompareTag(GameTags.Player))
			{
				Hide();
			}
		}

		
		protected virtual void OnTriggerStay(Collider other)
		{
			if (other.CompareTag(GameTags.Player))
			{
				var direction = (other.transform.position - transform.position).normalized;
				var angle = Vector3.Angle(transform.forward, direction);//观察角
				var allowedHeight = other.transform.position.y > m_collider.bounds.min.y;//在允许的高度内
				var inCameraSight = Vector3.Dot(m_camera.transform.forward, transform.forward) < 0;//在摄像机内

				if (angle < viewAngle && allowedHeight && inCameraSight)
				{
					Show();
				}
				else
				{
					Hide();
				}
			}
		}
	}
}
