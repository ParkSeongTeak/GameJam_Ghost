using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SetResolution();
    }
    public void SetResolution()
    {
        float setWidth = 1920; // 사용자 설정 너비
        float setHeight = 1080; // 사용자 설정 높이

        float deviceWidth = Screen.width; // 기기 너비 저장
        float deviceHeight = Screen.height; // 기기 높이 저장

        CanvasScaler _canvasScaler;
        _canvasScaler = GetComponent<CanvasScaler>();
        float targetAspectRatio = setWidth / setHeight;
        float currentAspectRatio = deviceWidth / deviceHeight;

        Screen.SetResolution((int)setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기


        _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _canvasScaler.referenceResolution = new Vector2(setWidth, setHeight);
        _canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        _canvasScaler.matchWidthOrHeight = 1f;

        if (targetAspectRatio < currentAspectRatio) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = targetAspectRatio / currentAspectRatio; // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
            _canvasScaler.matchWidthOrHeight = 1f;

        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = currentAspectRatio / targetAspectRatio; // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
            _canvasScaler.matchWidthOrHeight = 0f;
        }
    }
}
