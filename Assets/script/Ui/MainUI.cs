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
        float setWidth = 1920; // ����� ���� �ʺ�
        float setHeight = 1080; // ����� ���� ����

        float deviceWidth = Screen.width; // ��� �ʺ� ����
        float deviceHeight = Screen.height; // ��� ���� ����

        CanvasScaler _canvasScaler;
        _canvasScaler = GetComponent<CanvasScaler>();
        float targetAspectRatio = setWidth / setHeight;
        float currentAspectRatio = deviceWidth / deviceHeight;

        Screen.SetResolution((int)setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ� ����� ����ϱ�


        _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _canvasScaler.referenceResolution = new Vector2(setWidth, setHeight);
        _canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        _canvasScaler.matchWidthOrHeight = 1f;

        if (targetAspectRatio < currentAspectRatio) // ����� �ػ� �� �� ū ���
        {
            float newWidth = targetAspectRatio / currentAspectRatio; // ���ο� �ʺ�
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
            _canvasScaler.matchWidthOrHeight = 1f;

        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = currentAspectRatio / targetAspectRatio; // ���ο� ����
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
            _canvasScaler.matchWidthOrHeight = 0f;
        }
    }
}
