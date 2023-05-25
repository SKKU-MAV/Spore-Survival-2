using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropBehavior : MonoBehaviour

{
    [SerializeField]
    private Land land;

    //Information on what the crop will grow into
    SeedData seedToGrow;

    [Header("Stages of Life")]
    public GameObject seed;
    private GameObject seedling;
    private GameObject harvestable;
    public enum CropState
    {
        Seed, Seedling, Harvestable
    }
    //The current stage in the crop's growth
    public CropState cropState;

    void Start()
    {
        SwitchState(CropState.Seed);
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void Update()
    {
        if(land.currentCropStatus == 1)
        {
            SwitchState(CropState.Seedling);
        } 
        else if(land.currentCropStatus == 2) 
        {
            SwitchState(CropState.Harvestable);
        }
    }


    //Function to handle the state change
    void SwitchState(CropState stateToSwitch)
    {
        //Reset everything and set all GameObjects to inactive
        transform.GetChild(1).gameObject.SetActive(true);

        switch (stateToSwitch)
        {
            case CropState.Seed:
                //Enable the Seed GameObject
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(false);
                break;
            case CropState.Seedling:
                //Enable the Seedling GameObejct
                transform.GetChild(2).gameObject.SetActive(true);
                break;
            case CropState.Harvestable:
                //Enable the Harvestable GameObjct
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                break;
        }

        //Set the current crop state to the state we're switching to
        cropState = stateToSwitch;
    }
}
