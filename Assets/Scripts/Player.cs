using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject GameData;
    private bool antimorebomb = true;
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * GameData.GetComponent<GameData>().SpeedPlayer * Time.deltaTime;
        }
        if (Input.GetKeyDown("space"))
        {
            if(antimorebomb == true)
            StartCoroutine(InstanseBomb());
        }
    }

    IEnumerator InstanseBomb()
    {
        if (antimorebomb == true) 
        {
            antimorebomb = false;
            GameObject p = Instantiate(GameData.GetComponent<GameData>().BombPrefab, new Vector3(Mathf.RoundToInt(transform.position.x), 0.5f, Mathf.RoundToInt(transform.position.z)), GameData.GetComponent<GameData>().BombPrefab.transform.rotation);
            yield return new WaitForSeconds(1.2f);
            p.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(2f);
            antimorebomb = true;
            Destroy(p);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.tag == "Finish")
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

}
