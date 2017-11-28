using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    [SerializeField]
    private CameraRigData _cameraRigData;

	[SerializeField]
	private bool _enableMove;
	
	
	
	// Use this for initialization
	void Start ()
	{
		var worldEnd = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane));
		Debug.Log(worldEnd);
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
}
