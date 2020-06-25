using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private SteamVR_Action_Boolean teleport;
    
    private LineRenderer line;
    [Range(3.0f, 10.0f)]
    public float distance = 5.0f;
    public Color defalutColor = Color.green;
    public Color clickedColor = Color.blue;
    void Start()
    {
        pose = this.gameObject.GetComponent<SteamVR_Behaviour_Pose>(); //여기서 this는 이 스크립트를 말한다.
        hand = SteamVR_Input_Sources.LeftHand;
        teleport = SteamVR_Actions.default_Teleport; 
        CreateLine();
    }


    void CreateLine(){
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0,0,distance));


        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = defalutColor;

        line.startWidth = 0.05f;
        line.endWidth = 0.005f;
    }

}
