using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class changetheBar : MonoBehaviour
{
    [SerializeField]
    Image changeBar;

    [SerializeField]
    float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeBar.fillAmount = range;
    }
}
