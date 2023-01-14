using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowManager : MonoBehaviour
{
    public GameObject[] contents;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveContent(int idContent)
    {
        if (idContent < contents.Length || idContent >= 0)
        {
            contents[idContent].SetActive(true);
        }
        else
        {
            Debug.Log("<color=red>invalid idContent!</color>");
        }
    }

    public void DisableAllContents()
    {
        for (int i = 0; i < contents.Length; i++)
        {
            if (contents[i].activeSelf)
            {
                contents[i].GetComponent<Animator>().Play("InfoCard-Close");
            }
        }
    }
}
