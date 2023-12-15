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
        public Image Image { get; set; }
        public Button MinusButton { get; }
        public Button PlusButton { get; }
        public TextMeshProUGUI UnitAmount { get; set; }
    }
}
