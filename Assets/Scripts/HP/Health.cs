using UnityEngine;

public class Health : MonoBehaviour
{
    public int _value = 100;

   [SerializeField] private string _tag;

    private Wallet _wallet;
    private HealthUI _healthUI;

    [Zenject.Inject]
    private void Constructor(Wallet wallet,HealthUI healthUI)
    {
        _wallet = wallet;
        _healthUI = healthUI;
    }

    private void Update()
    {
        if (_value <= 0)
        {
            Destroy(gameObject);
            _wallet.AddMoney(500);
        }
    }

    public void TakeDamage(int damage)
    {
        _value -= damage;
        _healthUI.ChangeText(_value);
    }
}
