using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    [SerializeField]
    private CameraRigData _cameraRigData;

	[SerializeField]
	private bool _enableMove;

	[SerializeField]
	private GameObject _bulletBarrier;
	
	// Use this for initialization
	void Start ()
	{
		var worldEnd = Camera.main.ViewportToWorldPoint(new Vector3(1f, .5f, Camera.main.transform.position.x));
		var localWorldEnd = Camera.main.transform.InverseTransformPoint(worldEnd);
		
		worldEnd.x = worldEnd.y = 0;
		worldEnd.z += 10f;
		Debug.Log(localWorldEnd);
		_bulletBarrier.transform.position = worldEnd;
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
