using UnityEngine;

public class SwitcherUI : MonoBehaviour 
{
  public void On() => gameObject.SetActive(true);
  public void Off() => gameObject.SetActive(false);
}
