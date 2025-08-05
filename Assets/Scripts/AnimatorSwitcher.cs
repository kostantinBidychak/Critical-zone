using UnityEngine;

public class AnimatorSwitcher : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private string _nameBool;

    private void Start() => _animator = GetComponent<Animator>();
    public void StartAnimation() => _animator.SetBool(_nameBool, true);
}
