using UnityEngine;
public class EchoEffect : MonoBehaviour{
    public float startTime;
    private float timeBetweenSpawns;
    private float rotation;
    public GameObject echo;
    private GameObject instance;
    void Update(){
        rotation += 5;
        if(instance != null) instance.transform.localRotation = Quaternion.Euler(0,0,rotation);
        this.transform.localRotation = Quaternion.Euler(0,0,rotation);
        if (timeBetweenSpawns <= 0){
            instance = Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(instance, 0.6f);
            timeBetweenSpawns = startTime;
        }
        else{
            timeBetweenSpawns -= Time.deltaTime;
        }
        if (rotation > 359) rotation = 0;
    }
}
