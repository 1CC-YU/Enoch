using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Vector3 mOffset;
	[SerializeField] private Transform mPlayerTransform;

	void Start()
	{
		mOffset = transform.position - mPlayerTransform.position;
	}
	void Update()
	{
		transform.position = mOffset + mPlayerTransform.position;
	}
}
