using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ViveController : MonoBehaviour
{

    //컨트롤러 정의
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources any;


    //컨트롤러 입력 정의
    public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Boolean trackPadClick = SteamVR_Actions.default_Teleport;
    public SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_TrackPadTouch;
    public SteamVR_Action_Vector2 trackPadPosition = SteamVR_Actions.default_TrackPadPosition;


    private SteamVR_Action_Vibration haptic = SteamVR_Actions.default_Haptic;


    void Awake()
    {
        trigger = SteamVR_Actions.default_InteractUI;
    }

    void Update()
    {
        if (trigger.GetStateDown(leftHand))
        // 한 번 클릭했을 때 trigger 값을 호출
        {
            Debug.Log("왼손 트리거 버튼");
            haptic.Execute(0.2f, 0.3f, 120.0f, 0.7f, leftHand);
        }

        if (trigger.GetStateUp(rightHand))
        {
            Debug.Log("오른손 트리거 버튼");

        }

        if (trackPadClick.GetStateDown(any))
        {
            Debug.Log("트랙패드 클릭");
        }

        if (trackPadTouch.GetState(any))
        {
            Vector2 pos = trackPadPosition.GetAxis(any);
            Debug.Log($"터치 포스 x = {pos.x}, y = {pos.y}");

        }
        //코드가 중복되어서 삭제함
    }
}
