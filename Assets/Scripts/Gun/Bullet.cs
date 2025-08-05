using System.Collections;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeOfDestroy;
    [SerializeField] private float _speed;
    private int _damage = 100;
    public void Init(int  damage) => _damage = damage;

    private void Start() => StartCoroutine(nameof(Enumerator));
    private void Update()
    {
        transform.position += -transform.right * _speed * Time.deltaTime;
    }

    private IEnumerator Enumerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeOfDestroy);
            DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }
    public class Factory : PlaceholderFactory<Bullet> { }

}
