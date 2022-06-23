using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    void Start()
    {
        StartCoroutine(waitBum());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitBum()
    {
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));
        yield return new WaitForSeconds(.05f);
    }

    IEnumerator CreateExplosions(Vector3 direction)
    {
        for (int i = 0; i < 4; i++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit, i);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Destr")
                    Destroy(hit.collider.gameObject);
                if (hit.collider.gameObject.tag == "Finish")
                    Destroy(hit.collider.gameObject.transform.parent.gameObject);
            }
            if (!hit.collider)
            {
                GameObject p = Instantiate(ExplosionPrefab, transform.position + (i * direction), ExplosionPrefab.transform.rotation);
                yield return new WaitForSeconds(0.15f);
                Destroy(p);
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(.05f);
        }
    }
}
