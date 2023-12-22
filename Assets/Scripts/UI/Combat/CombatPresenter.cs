using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Scripts.UI.Combat
{
    public class CombatPresenter
    {
        private ICombatView _view;

        private IRoundManager _roundManager = new RoundManager();
        public ICombatManager CombatManager { get; private set; }

        private ICell _selectedCell;

        public CombatPresenter(ICombatView view, GameConfig gameConfig, List<IPlayer> players)
        {
            _view = view;   

            Field field = new Field(gameConfig.FieldWidth, gameConfig.FieldHeight);

            CombatManager = new CombatManager(field, players, _roundManager);

            _view.SkipButton.onClick.AddListener(SkipTurn);

            SubscribeCells();

            StartFirstRound();
        }

        private void SubscribeCells()
        {
            for (int x = 0; x < _view.CellsViews.GetLength(0); x++)
            {
                for (int y = 0; y < _view.CellsViews.GetLength(1); y++)
                {
                    _view.CellsViews[x, y].OnClicked += TileClicked;
                    CombatManager.GameField.Cells[x, y].OnModelChanged += _view.CellsViews[x, y].ChangeModel;
                }
            }
        }

        public void StartFirstRound()
        {
            for (int i = 0; i < CombatManager.Players.Count; i++)
            {
                for (int j = 0; j < CombatManager.Players[i].ControlledUnits.Count; j++)
                {
                    int x = i * (CombatManager.GameField.Width - 1);
                    CombatManager.GameField.AddUnit(CombatManager.Players[i].ControlledUnits[j], x, j);
                }
            }

            CombatManager.StartGame();
        }

        public void TileClicked(int x, int y)
        {
            _selectedCell = CombatManager.GameField.Cells[x, y];
            CombatManager.CurrentUnit.TryMove(_selectedCell, CombatManager.GameField);
        }

        public void SkipTurn()
        {
            CombatManager.CurrentUnit.SkipTurn();
        }
    }
}
