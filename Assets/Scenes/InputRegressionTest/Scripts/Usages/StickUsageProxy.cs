using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class StickUsageProxy : MonoBehaviour
{
    public XRNode node;
    public string usageName;

    public Text textComponent;
    public Slider horizontalSliderComponent;
    public Slider verticalSliderComponent;
    public Text valueTextComponent;

    public float currentXValue { get; private set; }
    public float currentYValue { get; private set; }

    private void Start()
    {
        if (textComponent != null)
        {
            textComponent.text = usageName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var stickValueMaybe = GetStickValue(XRNode.RightHand,"Primary2DAxis");
        if (stickValueMaybe == null)
            return;
        Vector2 value = stickValueMaybe.Value;
        
        //use output
        if (horizontalSliderComponent != null)
            horizontalSliderComponent.value = value.x;

        if (verticalSliderComponent != null)
            verticalSliderComponent.value = value.y;

        if (valueTextComponent != null)
            valueTextComponent.text = string.Format("[{0},{1}]", value.x.ToString("F"), value.y.ToString("F"));
    }

    private Vector2? GetStickValue(XRNode node,string axisName)
    {
        Vector2 value;
        InputDevice device = InputDevices.GetDeviceAtXRNode(node);

        if (!device.TryGetFeatureValue(new InputFeatureUsage<Vector2>(axisName), out value))
            return null;

        return value;
    }
}
