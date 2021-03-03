using System;
using UnityEngine;

public class ScaleEnemy : MonoBehaviour{
    private float scalingSpeed;
    private float scale = 2f;
    private bool scaleDown;
    void Update(){
        scale += scalingSpeed;
        this.transform.localScale = new Vector2(scale, scale);
        if (this.transform.localScale.x > 3f){
            scaleDown = true;
        }
        else if (this.transform.localScale.x < 2f){
            scaleDown = false;
        }
        if (scaleDown){
            scalingSpeed = -0.03f;
        }else if (!scaleDown){
            scalingSpeed = 0.03f;
        }
    }
}
