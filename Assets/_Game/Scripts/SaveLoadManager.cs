using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    const string KEY = "diamond";

    public static void AddDiamond(int add) => PlayerPrefs.SetInt(KEY, GetDiamond() + add);
    public static int GetDiamond() => PlayerPrefs.GetInt(KEY, 0);
}
