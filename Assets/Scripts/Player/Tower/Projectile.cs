using Enemy;
using Unity.Mathematics;
using UnityEngine;

namespace Player.Tower{
    public class Projectile : MonoBehaviour{
        public bool move = false;
        private Vector3 to;
        private float speed;
        private void Update(){
            if (!move) return;
            float angle = Mathf.Atan2(this.transform.position.y - to.y, this.transform.position.x - to.x) - 90 * Mathf.Rad2Deg;
            this.transform.rotation = quaternion.Euler(0,0, angle);
            this.transform.position = Vector3.MoveTowards(this.transform.position, to, speed * Time.deltaTime);
        }
        public void StartMove(Vector3 to, float speed){
            this.to = to;
            this.speed = speed;
            move = true;
        }
        public void OnTriggerEnter(Collider other){
            Debug.Log("Entered");
            if (other.GetComponent<Targetable>()){
                Destroy(this.gameObject);
            }
        }
    }
}
