using UnityEngine;

public class MoveEnemy : MonoBehaviour{
    
    private Transform[] waypoints;
    [SerializeField]private float speed = 10;
    private int currentWaypoint = 1;
    private float initalTimer = 1f;
    
    // Start is called before the first frame update
    void Start(){
        waypoints = FindObjectOfType<Waypoints>().GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update(){
        if (Time.time < initalTimer)
            return;
        
        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint(){

        if (currentWaypoint >= waypoints.Length)
            return;
        
        this.transform.position = Vector3.MoveTowards(this.transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        
        if (this.transform.position == waypoints[currentWaypoint].position){
            currentWaypoint++;
        }
    }
}
