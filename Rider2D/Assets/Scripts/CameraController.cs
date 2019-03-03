using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject objectToFollow;
    public float smoothness;
    public float yOffset;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        AlignWithObj();
    }

    void AlignWithObj()
    {
        if (objectToFollow != null)
        {
            gameObject.transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, objectToFollow.transform.position.x, Time.fixedDeltaTime * smoothness),
                Mathf.Lerp(transform.position.y, objectToFollow.transform.position.y + yOffset, Time.fixedDeltaTime * smoothness),
                -10);
        }
    }
}
