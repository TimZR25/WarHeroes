using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.Combat
{
    public class CombatPresenter
    {
        private IRoundManager _roundManager = new RoundManager();
        private CombatManager _combatManager;

        public IField Field { get; private set; }

        public CombatPresenter(GameConfig gameConfig, List<IPlayer> players)
        {
            Field = new Field(gameConfig.FieldWidth, gameConfig.FieldHeight);

            _combatManager = new CombatManager(Field, players, _roundManager);
        }

        public void TileClicked(int x, int y)
        {
            Debug.Log($"{x} : {y}");
        }
    }
}
