using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI
{
    public interface IPreparationView
    {
        public List<UnitsPreparationView> UnitsPreparationViews { get; }
    }
}
