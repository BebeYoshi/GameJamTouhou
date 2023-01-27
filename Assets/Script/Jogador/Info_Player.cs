using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Info_Player 
{
    private static int p_coins = 0;
    private static int p_score_snowboard = 0;

    public static int coins
    {
        get { return p_coins; }
        set { p_coins  = value; }
    }

    public static int score_snowboard
    {
        get { return p_score_snowboard; }
        set { p_score_snowboard = value; }
    }

}
