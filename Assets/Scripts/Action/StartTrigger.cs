using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{

    [SerializeField]
    private Action action;
    // Start is called before the first frame update
    void Start()
    {
        action.onAction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
