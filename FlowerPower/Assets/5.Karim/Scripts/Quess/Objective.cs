using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Objective : MonoBehaviour
{
    [Header ("beginning")]
    public Quest quest;
    public List<GameObject> enabledOnBegin;
    public List<GameObject> disabledOnBegin;
    public UnityEvent onBegin;
    [Space]
    [Header ("End")]
    public List<GameObject> enabledOnComplete;
    public List<GameObject> diabledOnComplete;
    public UnityEvent onEnd;
    
    
    
    public void Begin()
    {
        if(enabledOnBegin != null)
        {

            for (int i = 0; i < enabledOnBegin.Count; i++)
            {
                enabledOnBegin[i].SetActive(true);
            }
        }
        if (disabledOnBegin != null)
        {

            for (int i = 0; i < disabledOnBegin.Count; i++)
            {
                disabledOnBegin[i].SetActive(false);
            }
        }
    }

    public void Complete()
    {
        if (enabledOnBegin != null)
        {

            for (int i = 0; i < enabledOnBegin.Count; i++)
            {
                enabledOnBegin[i].SetActive(true);
            }
        }
        if (disabledOnBegin != null)
        {

            for (int i = 0; i < disabledOnBegin.Count; i++)
            {
                disabledOnBegin[i].SetActive(false);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
