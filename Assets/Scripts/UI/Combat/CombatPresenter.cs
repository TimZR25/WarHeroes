using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Scripts.UI.Combat
{
    public class CombatPresenter
    {
        private ICombatView _view;

        private IRoundManager _roundManager = new RoundManager();
        public ICombatManager CombatManager { get; private set; }

        private List<ICell> _selectedCells = new List<ICell>();

        private ICell _selectedCell;

        private UnitStateAction _unitAction;

        public CombatPresenter(ICombatView view, GameConfig gameConfig, List<IPlayer> players)
        {
            _view = view;   

            Field field = new Field(gameConfig.FieldWidth, gameConfig.FieldHeight);

            CombatManager = new CombatManager(field, players, _roundManager);

            CombatManager.OnCurrentUnitChanged += CurrentUnitChanged;

            _view.SkipButton.onClick.AddListener(UnitSkipTurn);
            _view.MoveButton.onClick.AddListener(UnitMove);
            _view.AbilityButton.onClick.AddListener(UnitUseAbility);

            SubscribeCells();

            StartFirstRound();
        }

        private void SubscribeCells()
        {
            for (int x = 0; x < _view.CellsViews.GetLength(0); x++)
            {
                for (int y = 0; y < _view.CellsViews.GetLength(1); y++)
                {
                    _view.CellsViews[x, y].OnClicked += CellClicked;
                    _view.CellsViews[x, y].OnMouseEntered += CellMouseEntered;
                    CombatManager.GameField.Cells[x, y].OnModelChanged += _view.CellsViews[x, y].ChangeModel;
                    CombatManager.GameField.Cells[x, y].OnSelected += _view.CellsViews[x, y].Select;
                    CombatManager.GameField.Cells[x, y].OnDeselected += _view.CellsViews[x, y].Deselect;
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

        public void CellClicked(int x, int y)
        {
            _selectedCell = CombatManager.GameField.Cells[x, y];

            switch (_unitAction)
            {
                case UnitStateAction.None:
                    break;
                case UnitStateAction.Ability:
                    CombatManager.CurrentUnit.UseActiveAbility(CombatManager.CurrentUnit.Stats.ActiveAbilities[0], _selectedCell);
                    DeselectCells(_selectedCells);
                    _unitAction = UnitStateAction.None;
                    break;
                case UnitStateAction.Move:
                    if (CombatManager.CurrentUnit.TryMove(_selectedCell, CombatManager.GameField))
                    {
                        DeselectCells(_selectedCells);
                        _view.MoveButton.interactable = false;
                        _view.MoveButton.GetComponent<Image>().color = Color.gray;
                        _unitAction = UnitStateAction.None;
                    }
                    break;
                default:
                    break;
            }
        }

        public void CellMouseEntered(int x, int y)
        {
            
        }

        private void CurrentUnitChanged(object sender, EventArgs eventArgs)
        {
            DeselectCells(_selectedCells);

            _view.MoveButton.interactable = true;
            _view.MoveButton.GetComponent<Image>().color = Color.white;
        }

        public void UnitSkipTurn()
        {
            _unitAction = UnitStateAction.None;

            CombatManager.CurrentUnit.SkipTurn();
        }

        public void UnitUseAbility()
        {
            DeselectCells(_selectedCells);

            _unitAction = UnitStateAction.Ability;

            _selectedCells = CombatManager.GameField.GetNeighborsRadius(CombatManager.CurrentUnit.CellParent,
                CombatManager.CurrentUnit.Stats.ActiveAbilities[0].Range);

            SelectCells(_selectedCells);
        }

        public void UnitMove()
        {
            DeselectCells(_selectedCells);

            _unitAction = UnitStateAction.Move;

            _selectedCells = CombatManager.GameField.GetNeighborsRadius(CombatManager.CurrentUnit.CellParent, 
                CombatManager.CurrentUnit.Stats.DistanceOfMove);

            SelectCells(_selectedCells);
        }

        private void SelectCells(List<ICell> cells)
        {
            foreach (ICell cell in cells) cell.Select();
        }

        private void DeselectCells(List<ICell> cells)
        {
            foreach (ICell cell in cells) cell.Deselect();
        }
    }

    public enum UnitStateAction
    {
        None, Ability, Move
    }
}
