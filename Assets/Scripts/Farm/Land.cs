using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Land : MonoBehaviour
{

    [SerializeField]
    private float dryingHour; // Time needed for the land to go from wet --> dry

    //[SerializeField]
    //private float timeMultiplier;

    [SerializeField]
    private float seedToSeedlingHour; // Time needed for the seed to be upgraded to seedling, when the ground is wet

    [SerializeField]
    private float seedlingToCabbageHour; // Time needed for the seed to be upgraded to seedling, when the ground is wet




    public enum LandStatus
    {
        Farmland, Watered
    }

    public LandStatus landStatus;

    public Material farmlandMat, wateredMat;
    new Renderer renderer;


    private TimeController timeController;


    private float timeMultiplier;
    private DateTime timeCurrent; // Current time
    private DateTime timeWatered; // Time the land was watered
    private TimeSpan dryingTime; // The time needed for land to try

    public int currentCropStatus; // Seed = 0, Seedling = 1, Cabbage = 2


    // Start is called before the first frame update
    void Start()
    {
        timeMultiplier = timeController.timeMultiplier;
        dryingTime = TimeSpan.FromHours(dryingHour);
        timeWatered = DateTime.Now.Date;
        timeCurrent = DateTime.Now.Date;
        currentCropStatus = 0;


        //Get the renderer component
        renderer = GetComponent<Renderer>();

        //Set the land to farmland(dry earth) by default // start wet during development
        SwitchLandStatus(LandStatus.Watered);
    }

    void Update()
    {
        timeCurrent = timeCurrent.AddSeconds(Time.deltaTime * timeMultiplier); // Current time update

        // (current time) - (watered time) is time passed from last watered time. If this time is bigger than seedToSeedlingHour, change to seedling.
        if (timeCurrent - timeWatered > TimeSpan.FromHours(seedToSeedlingHour))
        {
            currentCropStatus = 1; // change to seedling
            timeWatered = timeCurrent; // reset the last watered time to current time
        }
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        //Set land status accrdingly
        landStatus = statusToSwitch;
        Material materialToSwitch = farmlandMat;

        //Decide what material to switch to
        switch (statusToSwitch)
        {
            case LandStatus.Farmland:
                //Switch to farmland material
                materialToSwitch = farmlandMat;
                break;
            case LandStatus.Watered:
                //Switch to watered material
                materialToSwitch = wateredMat;
                break;
        }

        //Get the renderer to apply the changes
        renderer.material = materialToSwitch;
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
}

