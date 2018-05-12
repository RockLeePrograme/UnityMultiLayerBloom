using UnityEngine;
using System.Collections;

public class MainCameraCombine : MonoBehaviour {

    //特效RenderTexture
    public RenderTexture effectRT;
    //特效材质球
    public Material effectMaterial;

    public ChildCameraGenerateRenderTexture childCamera;

    public RenderTexture phase1Texture;

	void Start () {
        effectRT = childCamera.renderTexture;
	}

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        effectMaterial.SetTexture("_MainTex", effectRT);
        RenderTexture temp = RenderTexture.GetTemporary(source.width, source.height, source.depth);
        Graphics.Blit(effectRT, temp, effectMaterial);
        phase1Texture = temp;
        Graphics.Blit(temp, source);
        Graphics.Blit(source, destination);
        RenderTexture.ReleaseTemporary(temp);
    }
}
