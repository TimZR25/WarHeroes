using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Combat
{
    public interface ICombatView : IView
    {
        public Button AbilityButton { get; set; }
        public Button MoveButton { get; set; }
        public Button SkipButton { get; set; }
        public Button PauseButton { get; set; }
    }
}
