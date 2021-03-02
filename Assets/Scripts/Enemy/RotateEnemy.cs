using UnityEngine;

public class RotateEnemy : MonoBehaviour{
    [SerializeField] private float rotatingSpeed = 100;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotatingSpeed*Time.deltaTime));   
    }
}
