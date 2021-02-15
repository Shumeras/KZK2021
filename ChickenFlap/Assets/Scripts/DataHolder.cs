using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : Singleton<DataHolder>
{
    public BackgroundColor data;

    public int currentLevel = 0;

    public Level[] levelData;


}
