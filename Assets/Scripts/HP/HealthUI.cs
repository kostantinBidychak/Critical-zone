using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HealthUI 
{
    [SerializeField] private Image _image;

    public void ChangeText(int health) => _image.fillAmount = health / 100f;
}
