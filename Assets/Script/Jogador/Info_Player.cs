using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Info_Player 
{
    private static int p_coins = 0;

    public static int coins{
        get { return p_coins; }
        set { p_coins  = value; }
    }
    
}
