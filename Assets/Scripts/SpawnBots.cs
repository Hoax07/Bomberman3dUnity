using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBots : MonoBehaviour
{
    public GameObject GameData;
    public Transform playerforfollow;
    private GameObject Pbot;
    void Start()
    {
        Pbot = GameData.GetComponent<GameData>().BotPrefab;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        while (true)
        {
            var child = Instantiate(Pbot);
            child.transform.SetParent(this.transform, true);
            yield return new WaitForSeconds(5f);
        }
    }
}
