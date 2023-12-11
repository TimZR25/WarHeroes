using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class HostGameMain : MonoBehaviour
    {
        [SerializeField] private HostGameUIView _gameUIView;

        public void Awake()
        {
            var view = _gameUIView;
            HostGamePresenter presenter = new HostGamePresenter(view);

            view.Init(presenter);
        }
    }
}
