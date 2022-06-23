using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstanseBomb());
    }

     IEnumerator InstanseBomb()
     {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f,6f));
            GameObject p = Instantiate(transform.parent.gameObject.GetComponent<SpawnBots>().GameData.GetComponent<GameData>().BombPrefab, new Vector3(Mathf.RoundToInt(transform.position.x), 0.5f, Mathf.RoundToInt(transform.position.z)), transform.parent.gameObject.GetComponent<SpawnBots>().GameData.GetComponent<GameData>().BombPrefab.transform.rotation);
            yield return new WaitForSeconds(2.5f);
            Destroy(p);
        }
     }
}
