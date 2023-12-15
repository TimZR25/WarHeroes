using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    public class PreparationPresenter
    {
        private List<PlayerUnitsCollectionItem> playersUnits;

        private List<IDataPlayer> _dataPlayers;
        private int _sizeField;

        private UnitsConfig _unitsConfig;

        public PreparationPresenter(List<IDataPlayer> dataPlayers, int sizeField, UnitsConfig unitsConfig)
        {
            _dataPlayers = dataPlayers;
            _sizeField = sizeField;
            _unitsConfig = unitsConfig;
        }

        public void AddUnit()
        {
            
        }
    }
}
