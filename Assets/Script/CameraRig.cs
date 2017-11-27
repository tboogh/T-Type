using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    [SerializeField]
    private CameraRigData _cameraRigData;

	[SerializeField]
	private bool _enableMove;
	
	
	
	// Use this for initialization
	void Start () {
		
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
