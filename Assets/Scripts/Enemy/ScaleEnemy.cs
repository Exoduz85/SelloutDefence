using UnityEngine;

public class ScaleEnemy : MonoBehaviour{
    private float scalingSpeed;
    private float scale;
    private bool scaleDown;
    void Update(){
        scale += scalingSpeed;
        this.transform.localScale = new Vector2(scale, scale);
        if (this.transform.localScale.x > 2.5f){
            scaleDown = true;
        }
        else if (this.transform.localScale.x < 1.5f){
            scaleDown = false;
        }
        if (scaleDown){
            scalingSpeed = -0.02f;
        }else if (!scaleDown){
            scalingSpeed = 0.02f;
        }
    }
}
