using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public interface IHostGameUIView
    {
        public TMP_InputField SizeField { get; set; }

        public TextMeshProUGUI ErrorText { get; set; }

        public List<TMP_InputField> PlayersNamesField { get; set; }
        public List<TMP_InputField> PlayersScoreField { get; set; }
        public List<TMP_Dropdown> PlayersFactionDropdown { get; set; }
    }
}
