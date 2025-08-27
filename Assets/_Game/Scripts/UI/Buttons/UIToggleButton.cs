using UnityEngine;
using System.Collections.Generic;

public class UiToggleButton : UIButtonHandler
{
    private bool _isToggled = false;

    private Animator _buttonAnimator;

    [SerializeField] private List<Animator> _otherAnimators = new List<Animator>();

    protected new void Awake()
    {
        base.Awake();
        _buttonAnimator = this.GetComponent<Animator>();
        if (_buttonAnimator != null)
        {
            _isToggled = _buttonAnimator.GetBool("isToggled");

        }
    
    }
   
    protected override void ButtonClicked()
    {
        _isToggled = !_isToggled;
        ChangeAnimationState(_isToggled);
    }

    private void ChangeAnimationState(bool state)
    {
        if (_buttonAnimator != null) {
            _buttonAnimator.SetBool("isToggled", state);
            Debug.Log("Button toggled: " + state);
        }
        if (_otherAnimators != null)
        {
            foreach (var animator in _otherAnimators)
            {
                if (animator != null)
                {
                    animator.SetBool("IsToggled", state);
                    Debug.Log("Other animator toggled: " + state);
                }
            }
        }
    }

    public void SetToggle(bool state)
    {
        if (_isToggled != state) {
            _isToggled = state;
            ChangeAnimationState(state);
        }
    }
}
