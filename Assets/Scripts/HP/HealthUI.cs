using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void ChangeText(int health) => _image.fillAmount = health / 100f;
}
