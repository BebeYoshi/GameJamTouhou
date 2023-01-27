using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Info_Player 
{
    private static int p_coins = 0;
    private static int p_score_snowboard = 0;
    private static bool p_item_snowboard = false;
    private static bool p_item_snowfight = false;
    private static bool p_item_snowman = false;
    private static bool p_item_cooking = false;

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

       public static bool item_snowman
    {
        get { return p_item_snowman; }
        set { p_item_snowman = value; }
    }

       public static bool item_snowboard
    {
        get { return p_item_snowboard; }
        set { p_item_snowboard = value; }
    }

         public static bool item_snowfight
    {
        get { return p_item_snowfight; }
        set { p_item_snowfight = value; }
    }

     public static bool item_cooking
    {
        get { return p_item_cooking; }
        set { p_item_cooking = value; }
    }



}
