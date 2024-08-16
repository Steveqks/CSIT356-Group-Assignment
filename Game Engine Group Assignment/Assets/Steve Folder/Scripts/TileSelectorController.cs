using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileSelectorController : MonoBehaviour
{
    // options background
    [SerializeField] GameObject Options;

    // options layer 1
    [SerializeField] GameObject OptionL1;

    // options layer 2
    [SerializeField] GameObject OptionL2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setLayer1()
    {
        OptionL1.SetActive(true);
    }

    public void setLayer2()
    {
        OptionL1.SetActive(false);
        OptionL2.SetActive(true);
    }

    public void backButton()
    {
        OptionL2.SetActive(false);
        OptionL1.SetActive(true);
    }

    public void closeOption()
    {
        OptionL2.SetActive(false);
        OptionL1.SetActive(true);
        Options.SetActive(false);
    }
}
