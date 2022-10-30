using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer mesh;
    void Start()
    {
        mesh= transform.GetChild(0).GetComponent<MeshRenderer>();
    }

    public void destroy()
    {
        StartCoroutine(WaitforDestroy());
    }

    IEnumerator WaitforDestroy()
    {
        mesh.enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
