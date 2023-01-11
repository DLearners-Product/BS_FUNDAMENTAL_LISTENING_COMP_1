using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnablerCmtsDB
{
    public string welcome;
    public string introduction;
    public string bingo;
    public string follow_directions;
    public string coloring;
    public string silly_songs;
    public string first_and_last;
    public string start_and_stop;
    public string goodbye;

    public EnablerCmtsDB()
    {
        welcome = Main_Blended.OBJ_main_blended.enablerComments[0];
        introduction = Main_Blended.OBJ_main_blended.enablerComments[1];
        bingo = Main_Blended.OBJ_main_blended.enablerComments[2];
        follow_directions = Main_Blended.OBJ_main_blended.enablerComments[3];
        coloring = Main_Blended.OBJ_main_blended.enablerComments[4];
        silly_songs = Main_Blended.OBJ_main_blended.enablerComments[5];
        first_and_last = Main_Blended.OBJ_main_blended.enablerComments[6];
        start_and_stop = Main_Blended.OBJ_main_blended.enablerComments[7];
        goodbye = Main_Blended.OBJ_main_blended.enablerComments[8];
      
    }
}