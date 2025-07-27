using System.Collections;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeOfDestroy;
    private void Start() => StartCoroutine(nameof(Enumerator));
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
        DestroyBullet();
    }

    private IEnumerator Enumerator()
    {
        yield return new WaitForSeconds(_timeOfDestroy);
        DestroyBullet();
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public class Factory : PlaceholderFactory<Bullet> { }
}
