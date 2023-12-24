using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBoardView : MonoBehaviour
{
    [SerializeField] private Button _abilityFirstButton;
    [SerializeField] private Button _abilitySecondButton;

    public event EventHandler<int> OnAbilityChanged;

    private void Awake()
    {
        _abilityFirstButton.onClick.AddListener(ChangeFirstAbility);
        _abilitySecondButton.onClick.AddListener(ChangeSecondAbility);
    }

    private void Start()
    {
        ChangeFirstAbility();
    }

    private void ChangeFirstAbility()
    {
        _abilityFirstButton.interactable = false;
        _abilitySecondButton.interactable = true;

        _abilitySecondButton.image.color = Color.white;
        _abilityFirstButton.image.color = Color.gray;

        OnAbilityChanged?.Invoke(this, 0);
    }

    private void ChangeSecondAbility()
    {
        _abilitySecondButton.interactable = false;
        _abilityFirstButton.interactable = true;

        _abilityFirstButton.image.color = Color.white;
        _abilitySecondButton.image.color = Color.gray;

        OnAbilityChanged?.Invoke(this, 1);
    }
}
