using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace Assets.Scripts.UI
{
    public interface IUnitsPreparationView
    {
        public TextMeshProUGUI PlayerName { get; set; }
        public List<UnitPreparationView> UnitPreparationViews { get; }
    }
}
