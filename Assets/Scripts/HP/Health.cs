using UnityEngine;

public class Health : MonoBehaviour,IDamagable
{
    public int _value = 100;
   [SerializeField] private string _tag;

    private GunModel _gunModelScript;
    private HealthUI _healthUI;
    [Zenject.Inject]
    private void Constructor(GunModel gunModelScript,HealthUI healthUI)
    {
        _gunModelScript = gunModelScript;
        _healthUI = healthUI;
    }

    private void Update()
    {
        if (_value <= 0)
        {
            Destroy(gameObject);
        }
    }


    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent(out Bullet bullet))
    //    {
    //        TakeDamage(_gunModelScript.Damage);
    //    }
    //}
    public void TakeDamage(int damage)
    {
        _value -= damage;
        _healthUI.ChangeText(_value);
    }
}
