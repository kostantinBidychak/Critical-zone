using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeOfDestroy;
   private void Update()
    {
     transform.Translate(Vector3.forward * Time.deltaTime);
        DestroyBullet();
    }

   private void DestroyBullet() 
   {
    Destroy(gameObject,_timeOfDestroy);
   }
}
