using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteHeroAfterTalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Delete()
    {
        if (!gameObject.GetComponent<Talk>().ifCanTalk)
        {
           Destroy(gameObject);
        }
        
    }
}
