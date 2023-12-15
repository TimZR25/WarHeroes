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
    public class UnitPreparationView : MonoBehaviour, IUnitPreparationView
    {
        [SerializeField] private Image _image;
        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        [SerializeField] private Button _minusButton;
        public Button MinusButton => _minusButton;

        [SerializeField] private Button _plusButton;
        public Button PlusButton => _plusButton;

        [SerializeField] private TextMeshProUGUI _unitAmount;
        public TextMeshProUGUI UnitAmount
        {
            get { return _unitAmount; }
            set { _unitAmount = value; }
        }
    }
}
