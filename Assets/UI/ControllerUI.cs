using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{

    [SerializeField] controller spaceshipController;

    [SerializeField] private Text YRotation_text;
    [SerializeField] private Text ZRotation_text;
    [SerializeField] private Text XRotation_text;

    [SerializeField] private RectTransform shipTopIcon;
    [SerializeField] private RectTransform shipBackIcon;

    private float maxIconOffset = 51.0f;
    private float maxVisibleMagnitude = 25.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        YRotation_text.text = spaceshipController.YRotation.ToString("F1");
        ZRotation_text.text = spaceshipController.ZRotation.ToString("F1");
        XRotation_text.text = spaceshipController.XRotation.ToString("F1");

        float zOffset = getShipIconOffset(spaceshipController.forwardMagnitude, maxVisibleMagnitude, maxIconOffset);
        float yOffset = getShipIconOffset(spaceshipController.upMagnitude, maxVisibleMagnitude, maxIconOffset);
        float xOffset = getShipIconOffset(spaceshipController.rightMagnitude, maxVisibleMagnitude, maxIconOffset);

        shipTopIcon.anchoredPosition = new Vector2(xOffset, zOffset);
        shipBackIcon.anchoredPosition = new Vector2(xOffset, yOffset);

    }
    float getShipIconOffset(float magnitude, float maxMagnitude, float maxIconOffset)
    {
        if (magnitude < maxMagnitude)
        {
            return magnitude / maxMagnitude * maxIconOffset;
        }
        else return maxIconOffset;
    }

}
