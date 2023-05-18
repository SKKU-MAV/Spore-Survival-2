using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public enum LandStatus
    {
        Farmland, Watered
    }

    public LandStatus landStatus;

    public Material farmlandMat, wateredMat;
    new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        //Get the renderer component
        renderer = GetComponent<Renderer>();

        //Set the land to farmland(dry earth) by default;
        SwitchLandStatus(LandStatus.Farmland);
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
}
