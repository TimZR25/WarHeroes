using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostGameView : MonoBehaviour
{
    protected HostGamePresenter _presenter;

    public void Init(HostGamePresenter presenter)
    {
        _presenter = presenter;
    }
}
