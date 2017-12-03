using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    [SerializeField]
    private CameraRigData _cameraRigData;

	[SerializeField]
	private bool _enableMove;

	[SerializeField]
	private GameObject _rightScreenTrigger;
	
	[SerializeField]
	private GameObject _leftScreenTrigger;
	
	// Use this for initialization
	void Start ()
	{
		SetupLeftTrigger();
		SetupRightTrigger();
	}

	private void SetupLeftTrigger()
	{
		SetupTransform(0f, -4f, _leftScreenTrigger.transform);
	}

	private void SetupRightTrigger()
	{
		SetupTransform(1f, 1f, _rightScreenTrigger.transform);
	}

	private static void SetupTransform(float viewportPosition, float offset, Transform objectTransform)
	{
		var worldPoint =
			Camera.main.ViewportToWorldPoint(new Vector3(viewportPosition, .5f, Camera.main.transform.position.x));
		var localWorldPoint = Camera.main.transform.InverseTransformPoint(worldPoint);

		worldPoint.x = worldPoint.y = 0;
		worldPoint.z += offset;
		objectTransform.position = worldPoint;
	}

	// Update is called once per frame
	void Update ()
	{
		MoveFrame();
	}

	private void MoveFrame()
	{
		if (!_enableMove)
			return;
		transform.Translate(Vector3.forward * Time.deltaTime * _cameraRigData.MovementSpeed);
	}
	
	void OnDrawGizmosSelected()
	{
		Camera camera = Camera.main;
		Vector3 p = camera.ViewportToWorldPoint(new Vector3(1f, .5f, camera.transform.position.x));
		var localWorldEnd = transform.InverseTransformPoint(p);
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(p, 1F);
	}
}
