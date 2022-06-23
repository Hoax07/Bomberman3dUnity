using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject PrefBWall,PrefNWall, GameData;
    public int DestrS = 4;
    private float Random;
    void Start()
    {
        DestrS = GameData.GetComponent<GameData>().LevelHard;
        for (int i = -31; i < 32; i++)
        {
            for (int j = -31; j < 32; j++)
            {
                if (i % 2 == 0 & j % 2 == 0)
                    if (chekygl(i, j)) { }
                    else
                    {
                        var child = Instantiate(PrefNWall, new Vector3(i, .5f, j), Quaternion.identity);
                        child.transform.SetParent(this.transform, true);
                    }
                else
                {
                    {
                        if (chekygl(i, j)) { }
                        else
                        {
                            Random = UnityEngine.Random.Range(1, 10);
                            if (Random < DestrS)
                            {
                                var child = Instantiate(PrefBWall, new Vector3(i, .5f, j), Quaternion.identity);
                                child.transform.SetParent(this.transform, true);
                            }
                        }
                    }
                }
            }
        }
    }

    private bool chekygl(int i, int j)
    {
        if (i > -27 & j > -27 || i < 27 & j < 27)
            return false;
        else
            return true;
    }
}
