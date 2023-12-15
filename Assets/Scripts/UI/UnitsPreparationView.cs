using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UnitsPreparationView : MonoBehaviour, IUnitsPreparationView
    {
        [SerializeField] private TextMeshProUGUI _playerName;
        public TextMeshProUGUI PlayerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        [SerializeField] private List<UnitPreparationView> units;
        public List<UnitPreparationView> UnitPreparationViews => units;
    }
}
