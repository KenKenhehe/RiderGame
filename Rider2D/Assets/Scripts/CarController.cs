using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    public float speed;
    public GameObject deathFX;
    bool isLand;

    Rigidbody2D rb2d;
    TrailRenderer trailRenderer;
    SceneHandler sceneHandler;
	// Use this for initialization
	void Start () {
        isLand = true;
        rb2d = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        sceneHandler = FindObjectOfType<SceneHandler>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        HorizontalMovement();
        IfFlipedDestory();
    }

    private void HorizontalMovement()
    {
        if (Input.GetButton("Fire1") && isLand)
        {
            trailRenderer.enabled = true;
            rb2d.AddForce(new Vector3(speed * Time.fixedDeltaTime, 0, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<BezierCurveCollider2D>() != null)
        {
            isLand = true;
        }
        if(collision.gameObject.tag == "Death")
        {
            OnGameOver();
        }
  
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BezierCurveCollider2D>() != null)
        {
            isLand = false;
        }
    }

    void OnGameOver()
    {
        sceneHandler.Finished = true;
        sceneHandler.ReloadLevel(false);
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void IfFlipedDestory()
    {
        if(gameObject.transform.rotation.z > 0.9 || gameObject.transform.rotation.z < -0.9)
        {
            OnGameOver();
        }
    }

    public void OnGameFinish()
    {
        sceneHandler.Finished = true;
        sceneHandler.ReloadLevel(true);
    }
}
