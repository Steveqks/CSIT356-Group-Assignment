using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileSelectorController : MonoBehaviour
{
    [SerializeField] GameObject OptionL1;
    [SerializeField] GameObject OptionL2;
    [SerializeField] GameObject Canvas1;



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

    public void closeOption()
    {
        OptionL2.SetActive(false);
        OptionL1.SetActive(true);
        Canvas1.SetActive(false);
    }
}
