using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoundManager : IRoundManager
{
    public int Round { get; set; }

    public RoundManager()
    {
        Round = 0;
    }

    public void NextRound()
    {
        Round++;
    }
}
