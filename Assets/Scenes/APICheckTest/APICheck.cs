using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
#if UNITY_2017_2_OR_NEWER
using UnityEngine.XR;
#else
using UnityEngine.VR;
#endif

public class APICheck : MonoBehaviour {

    public UnityEngine.UI.Text textField;

    public static bool isPresent()
    {
        var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);
        foreach (var xrDisplay in xrDisplaySubsystems)
        {
            if (xrDisplay.running)
            {
                return true;
            }
        }
        return false;
    }

	void Update () {
        
        if (textField != null)
        {

            string text = "";
    #if UNITY_2017_2_OR_NEWER
            text += "XRDevice\n";
            text += "\tisPresent: " + isPresent() + "\n";
            var xrInputSubsystems = new List<XRInputSubsystem>();
            SubsystemManager.GetInstances<XRInputSubsystem>(xrInputSubsystems);
            text += "\tmodel: " + xrInputSubsystems.First().subsystemDescriptor.id + "\n";
            text += "\trefreshRate: " + XRDevice.refreshRate + "\n";
            //text += "\tuserPresence: " + XRDevice.userPresence + "\n";
            text += "\tfovZoomFactor: " + XRDevice.fovZoomFactor + "\n";

            text += "\nXRSettings\n";
            text += "\teyeTextureHeight: " + XRSettings.eyeTextureHeight + "\n";
            text += "\teyeTextureWidth: " + XRSettings.eyeTextureWidth + "\n";
            text += "\teyeTextureResolutionScale: " + XRSettings.eyeTextureResolutionScale + "\n";
            text += "\tisDeviceActive: " + XRSettings.isDeviceActive + "\n";
            text += "\tloadedDeviceName: " + XRSettings.loadedDeviceName + "\n";
            text += "\tocclusionMaskScale: " + XRSettings.occlusionMaskScale + "\n";
            text += "\trenderViewportScale: " + XRSettings.renderViewportScale + "\n";
            text += "\tsupportedDevices: ";
            foreach(string device in XRSettings.supportedDevices)
            {
                text += "[" + device + "]";
            }
            text += "\n";

    #elif UNITY_2017_2_OR_NEWER
            text += "XRDevice\n";
            text += "\tisPresent: " + XRDevice.isPresent + "\n";
            text += "\tmodel: " + XRDevice.model + "\n";
            text += "\trefreshRate: " + XRDevice.refreshRate + "\n";
            text += "\tuserPresence: " + XRDevice.userPresence + "\n";
            text += "\tfovZoomFactor: " + XRDevice.fovZoomFactor + "\n";

            text += "\nXRSettings\n";
            text += "\teyeTextureHeight: " + XRSettings.eyeTextureHeight + "\n";
            text += "\teyeTextureWidth: " + XRSettings.eyeTextureWidth + "\n";
            text += "\teyeTextureResolutionScale: " + XRSettings.eyeTextureResolutionScale + "\n";
            text += "\tisDeviceActive: " + XRSettings.isDeviceActive + "\n";
            text += "\tloadedDeviceName: " + XRSettings.loadedDeviceName + "\n";
            text += "\tocclusionMaskScale: " + XRSettings.occlusionMaskScale + "\n";
            text += "\trenderViewportScale: " + XRSettings.renderViewportScale + "\n";
            text += "\tsupportedDevices: ";
            foreach(string device in XRSettings.supportedDevices)
            {
                text += "[" + device + "]";
            }
            text += "\n";
    #else
            text += "XRDevice\n";
            text += "\tisPresent: " + VRDevice.isPresent + "\n";
            text += "\tmodel: " + VRDevice.model + "\n";
            text += "\trefreshRate: " + XRDevice.refreshRate + "\n";
            text += "\tuserPresence: " + XRDevice.userPresence + "\n";
            text += "\tfovZoomFactor: " + XRDevice.fovZoomFactor + "\n";

            text += "\nVRSettings\n";
            text += "\teyeTextureHeight: " + VRSettings.eyeTextureHeight + "\n";
            text += "\teyeTextureWidth: " + VRSettings.eyeTextureWidth + "\n";
            text += "\teyeTextureResolutionScale: " + VRSettings.eyeTextureResolutionScale + "\n";
            text += "\tisDeviceActive: " + VRSettings.isDeviceActive + "\n";
            text += "\tloadedDeviceName: " + VRSettings.loadedDeviceName + "\n";
            text += "\tocclusionMaskScale: " + VRSettings.occlusionMaskScale + "\n";
            text += "\trenderViewportScale: " + VRSettings.renderViewportScale + "\n";
            text += "\tsupportedDevices: ";
            foreach(string device in VRSettings.supportedDevices)
            {
                text += "[" + device + "]";
            }
            text += "\n";
    #endif
            textField.text = text;
        }
    }

}
