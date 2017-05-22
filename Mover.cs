using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public Waypoint[] wayPoints;
	public float speed = 3f;
	public bool isCircular;
	// Always true at the beginning because the moving object will always move towards the first waypoint
	public bool inReverse = true;
    public bool qq;
    public static bool isStarting;
    public static bool startQuest;
    public bool st;
    public static bool arrived;
    public static bool startPoint;

	private Waypoint currentWaypoint;
	public static int currentIndex   = 0;
	private bool isWaiting     = false;
	private float speedStorage = 0;
    
    

	/**
	 * Initialisation
	 * 
	 */
	void Start () {
        isStarting = true;
        SetStatingPoint();
	}
	
	

	/**
	 * Update is called once per frame
	 * 
	 */
	void FixedUpdate()
	{
        st = isStarting;

        move();

        
	}

    void SetStatingPoint()
    {
        if (wayPoints.Length > 0)
        {
            currentWaypoint = wayPoints[0];
        }
    }

    void move()
    {
        qq = QuestScreen.haveQuest;
        if (currentWaypoint != null && !isWaiting)
        {
            MoveTowardsWaypoint();
        }
    }


    /**
	 * Pause the mover
	 * 
	 */
    void Pause()
	{
		isWaiting = !isWaiting;
	}


	
	/**
	 * Move the object towards the selected waypoint
	 * 
	 */
	private void MoveTowardsWaypoint()
	{
		// Get the moving objects current position
		Vector3 currentPosition = this.transform.position;
		
		// Get the target waypoints position
		Vector3 targetPosition = currentWaypoint.transform.position;
		
		// If the moving object isn't that close to the waypoint
		if(Vector3.Distance(currentPosition, targetPosition) > .1f) {

			// Get the direction and normalize
			Vector3 directionOfTravel = targetPosition - currentPosition;
			directionOfTravel.Normalize();
			
			//scale the movement on each axis by the directionOfTravel vector components
			this.transform.Translate(
				directionOfTravel.x * speed * Time.deltaTime,
				directionOfTravel.y * speed * Time.deltaTime,
				directionOfTravel.z * speed * Time.deltaTime,
				Space.World
			);
		} else {
			
			// If the waypoint has a pause amount then wait a bit
			if(currentWaypoint.waitSeconds > 0) {
				Pause();
				Invoke("Pause", currentWaypoint.waitSeconds);
			}

			// If the current waypoint has a speed change then change to it
			if(currentWaypoint.speedOut > 0) {
				speedStorage = speed;
				speed = currentWaypoint.speedOut;
			} else if(speedStorage != 0) {
				speed = speedStorage;
				speedStorage = 0;
			}

			NextWaypoint();
		}
	}



	/**
	 * Work out what the next waypoint is going to be
	 * 
	 */
	private void NextWaypoint()
	{
		if(isCircular) {
			
			if(!inReverse) {
				currentIndex = (currentIndex+1 >= wayPoints.Length) ? 0 : currentIndex+1;
			} else {
				currentIndex = (currentIndex == 0) ? wayPoints.Length-1 : currentIndex-1;
			}

		} else {
			
			// If at the start or the end then reverse
			if ((inReverse && (currentIndex == 0 || currentIndex == -1)) && isStarting == true) {
				inReverse = !inReverse;
                isStarting = false;

			}
			currentIndex = (!inReverse) ? currentIndex+1 : currentIndex-1;
            if ((!inReverse && currentIndex + 1 > wayPoints.Length) && qq == true)
            {
                inReverse = !inReverse;
                startQuest = true;
            }

        }
        if (currentIndex < 0)
        {
            startPoint = true;
            currentIndex = 0;
        }
        if (currentIndex > 2)
        {
            arrived = true;
            currentIndex = 2;
        }
        currentWaypoint = wayPoints[currentIndex];
	}
}
