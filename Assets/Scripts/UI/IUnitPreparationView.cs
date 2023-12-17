using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public interface IUnitPreparationView
    {
        public PlayerNumber PlayerNumber { get; }
        public TypeRole TypeRole { get; }

        public Image Image { get; set; }

        public Button MinusButton { get; }
        public Button PlusButton { get; }

        public TextMeshProUGUI UnitAmount { get; set; }

        public event EventHandler<IUnitPreparationView> OnMinusButtonClicked;
        public event EventHandler<IUnitPreparationView> OnPlusButtonClicked;

        public void ChangeUnitAmount(object sender, int unitAmount);
    }

    public enum PlayerNumber
    {
        Player1, Player2
    }
}
