using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Money { get; private set; }

    public void AddMoney(int amount) => Money += amount;
    public void SpendMoney(int amount) => Money -= amount;
}
