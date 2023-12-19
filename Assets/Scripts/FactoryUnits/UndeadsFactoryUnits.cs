using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class UndeadsFactoryUnits : IAbstractFactoryUnits
    {
        public AbstractUnit CreateArcher(IUnitStats unitStats)
        {
        return new Unit(unitStats);
    }

        public AbstractUnit CreateMage(IUnitStats unitStats)
        {
        return new Unit(unitStats);
    }

        public AbstractUnit CreateWarrior(IUnitStats unitStats)
        {
        return new Unit(unitStats);
    }
    }

