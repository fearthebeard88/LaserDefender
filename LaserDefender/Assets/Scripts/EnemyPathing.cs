using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] public List<Transform> waypoints;
    [SerializeField] public float moveSpeed = 5f;
    public int waypointIndex = 0;

	// Use this for initialization
	void Start ()
	{
	    transform.position = this.waypoints[this.waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    private void Move()
    {
        if (this.waypointIndex <= this.waypoints.Count - 1)
        {
            var targetPosition = this.waypoints[this.waypointIndex].transform.position;
            var movementThisFrame = this.moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                this.waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
