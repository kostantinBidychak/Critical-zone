using UnityEngine;

public class Health : MonoBehaviour,IDamagable
{
    [SerializeField] private int value = 100;
    private const string BulletTag = "Bullet";

    [Zenject.Inject]private GunModelScript gunModelScript;

    private void OnCollisionEnter(Collision collision)
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(BulletTag))
        {
            TakeDamage(gunModelScript.Damage);
        }
    }
    public void TakeDamage(int damage)
    {
        value -= damage;
        if (value <= 0) 
        {
           Destroy(gameObject);
        }
    }
}
