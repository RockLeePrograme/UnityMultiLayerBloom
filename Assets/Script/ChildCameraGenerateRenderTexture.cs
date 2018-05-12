using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class ChildCameraGenerateRenderTexture : MonoBehaviour {

    // Use this for initialization
    public RenderTexture renderTexture;

	void Start ()
    {
        renderTexture = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGB32);
        GetComponent<Camera>().targetTexture = renderTexture;
	}
}
