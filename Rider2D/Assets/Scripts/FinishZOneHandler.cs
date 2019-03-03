using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZOneHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<CarController>() != null)
        {
            collision.gameObject.GetComponent<CarController>().OnGameFinish();
            collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}
