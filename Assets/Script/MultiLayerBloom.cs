using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MultiLayerBloom : UnityStandardAssets.ImageEffects.PostEffectsBase
{
    public Shader fastBloomShader = null;
    private Material fastBloomMaterial = null;

    public RenderTexture sourceRender;
    public RenderTexture targetRenderTexture;

    //渲染摄像机
    public Camera renderCamera;

    //标记是否已经初始化RT
    private bool hasInitRenderTexture;

    public override bool CheckResources()
    {
        CheckSupport(false);

        fastBloomMaterial = CheckShaderAndCreateMaterial(fastBloomShader, fastBloomMaterial);

        if (!isSupported)
            ReportAutoDisable();
        if (!hasInitRenderTexture)
        {
            InitRT();
            hasInitRenderTexture = true;
        }
        return isSupported;
    }

    protected void InitRT()
    {
        targetRenderTexture = new RenderTexture(Screen.width, Screen.height, 0);
        renderCamera.targetTexture = targetRenderTexture;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (CheckResources() == false)
        {
            Graphics.Blit(source, destination);
            return;
        }

        sourceRender = source;

        Graphics.Blit(source, destination, fastBloomMaterial);
    }
}
