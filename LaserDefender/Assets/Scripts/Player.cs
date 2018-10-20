using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // configuration parameters
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileFiringPeriod = 0.05f;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

	// Use this for initialization
	void Start () {
        SetUpMoveBoundaries();
	}

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(this.firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(this.laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.projectileSpeed);
            yield return new WaitForSeconds(this.projectileFiringPeriod);
        }
    }

    // Update is called once per frame
    void Update () {
        Move();
        Fire();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * this.moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, this.xMin, this.xMax);
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * this.moveSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, this.yMin, this.yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        this.xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + this.padding;
        this.xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - this.padding;
        this.yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + this.padding;
        this.yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - this.padding;
    }
}
