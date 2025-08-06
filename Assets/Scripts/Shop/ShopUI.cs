using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameObject;

    public void SwitchText(string name) => _nameObject.text = name;
}
