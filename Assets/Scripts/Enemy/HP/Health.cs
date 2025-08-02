using UnityEngine;

public class Health : MonoBehaviour,IDamagable
{
    [SerializeField] private int _value = 100;
    private const string _BulletTag = "Bullet";

    [Zenject.Inject]private GunModelScript _gunModelScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_BulletTag))
        {
            TakeDamage(_gunModelScript.Damage);
        }
    }
    public void TakeDamage(int damage)
    {
        _value -= damage;
        if (_value <= 0) 
        {
           Destroy(gameObject);
        }
    }
}
