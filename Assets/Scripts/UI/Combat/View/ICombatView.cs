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
        public Button AbilityButton { get; }
        public Button MoveButton { get; }
        public Button SkipButton { get; }
        public Button PauseButton { get; }

        public CellView[,] CellsViews { get; }
    }
}
