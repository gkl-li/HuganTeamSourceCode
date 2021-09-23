using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshAdapter : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;
    public MeshCollider meshCollider;
    public Texture2D CastTextureToTexture2D(Texture baseTexture)
    {
        if (baseTexture == null)
            return null;
        Texture mainTexture = baseTexture;
        Texture2D texture2D = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);

        RenderTexture currentRT = RenderTexture.active;

        RenderTexture renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
        Graphics.Blit(mainTexture, renderTexture);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        Color[] pixels = texture2D.GetPixels();

        RenderTexture.active = currentRT;
        return texture2D;
    }

    Sprite Texture2DToSprite(Texture2D texture)
    {

        var tex = new Texture2D(1280, 720, TextureFormat.RGBA32, false);
        Rect rex = new Rect(0, 0, (float)1280, (float)720);
        tex.ReadPixels(rex,0,0);
        tex.Apply();
        return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
    }

    Mesh SpriteToMesh(Sprite sprite)
    {
        Mesh mesh = new Mesh();
        mesh.vertices = Array.ConvertAll(sprite.vertices, i => (Vector3)i);
        mesh.uv = sprite.uv;
        mesh.triangles = Array.ConvertAll(sprite.triangles, i => (int)i);

        return mesh;
    }

    public Texture GetTexture(string path, Vector2 resolution)
    {
        if (System.IO.File.Exists(path))
        {
            byte[] imageBytes;
            imageBytes = System.IO.File.ReadAllBytes(path);
            Texture2D moddedTexture = new Texture2D((int)resolution.x, (int)resolution.y, TextureFormat.DXT1, false);
            moddedTexture.LoadImage(imageBytes);
            moddedTexture.wrapMode = TextureWrapMode.Clamp;
            moddedTexture.Apply(false, false);
            Debug.Log(path + " MEM = " + UnityEngine.Profiling.Profiler.GetRuntimeMemorySizeLong(moddedTexture) / 1000000f);
            return moddedTexture;
        }
        return null;
    }



    // Start is called before the first frame update
    IEnumerator Start()
    {
        WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
        yield return frameEnd;
        var path = Application.persistentDataPath + "/resources/";
        var tex = GetTexture(path+"0.png",new Vector2(1280,720));
        spriteMat.mainTexture = tex;
        GenerateMesh();
    }
    private enum Edge { top, left, bottom, right };

    public Material spriteMat;
    public float alphaTheshold = 0;
    public float depth = 0.0625f;
    private Color32[] m_Colors;
    private int m_Width;
    private int m_Height;

    private List<Vector3> m_Vertices = new List<Vector3>();
    private List<Vector3> m_Normals = new List<Vector3>();
    private List<Vector2> m_TexCoords = new List<Vector2>();

    private bool HasPixel(int aX, int aY)
    {
        return m_Colors[aX + aY * m_Width].a > alphaTheshold;
    }
    void AddQuad(Vector3 aFirstEdgeP1, Vector3 aFirstEdgeP2, Vector3 aSecondRelative, Vector3 aNormal, Vector2 aUV1, Vector2 aUV2, bool aFlipUVs)
    {
        m_Vertices.Add(aFirstEdgeP1);
        m_Vertices.Add(aFirstEdgeP2);
        m_Vertices.Add(aFirstEdgeP2 + aSecondRelative);
        m_Vertices.Add(aFirstEdgeP1 + aSecondRelative);
        m_Normals.Add(aNormal);
        m_Normals.Add(aNormal);
        m_Normals.Add(aNormal);
        m_Normals.Add(aNormal);
        if (aFlipUVs)
        {
            m_TexCoords.Add(new Vector2(aUV1.x, aUV1.y));
            m_TexCoords.Add(new Vector2(aUV2.x, aUV1.y));
            m_TexCoords.Add(new Vector2(aUV2.x, aUV2.y));
            m_TexCoords.Add(new Vector2(aUV1.x, aUV2.y));
        }
        else
        {
            m_TexCoords.Add(new Vector2(aUV1.x, aUV1.y));
            m_TexCoords.Add(new Vector2(aUV1.x, aUV2.y));
            m_TexCoords.Add(new Vector2(aUV2.x, aUV2.y));
            m_TexCoords.Add(new Vector2(aUV2.x, aUV1.y));
        }

    }

    void AddEdge(int aX, int aY, Edge aEdge)
    {
        Vector2 size = new Vector2(1.0f / m_Width, 1.0f / m_Height);
        Vector2 uv = new Vector3(aX * size.x, aY * size.y);
        Vector2 P = uv - Vector2.one * 0.5f;
        uv += size * 0.5f;
        Vector2 P2 = P;
        Vector3 normal;
        if (aEdge == Edge.top)
        {
            P += size;
            P2.y += size.y;
            normal = Vector3.up;
        }
        else if (aEdge == Edge.left)
        {
            P.y += size.y;
            normal = Vector3.left;
        }
        else if (aEdge == Edge.bottom)
        {
            P2.x += size.x;
            normal = Vector3.down;
        }
        else
        {
            P2 += size;
            P.x += size.x;
            normal = Vector3.right;
        }
        AddQuad(P, P2, Vector3.forward * depth, normal, uv, uv, false);
    }

    void GenerateMesh()
    {
        Texture2D tex = spriteMat.mainTexture as Texture2D;
        m_Colors = tex.GetPixels32();
        m_Width = tex.width;
        m_Height = tex.height;
        //      first point                     , second point                    , relative 3. P, normal,          lower UV,     Upper UV,    flipUV
        AddQuad(new Vector3(-0.5f, -0.5f, 0), new Vector3(-0.5f, 0.5f, 0), Vector3.right, Vector3.back, Vector2.zero, Vector2.one, false);
        AddQuad(new Vector3(-0.5f, -0.5f, depth), new Vector3(0.5f, -0.5f, depth), Vector3.up, Vector3.forward, Vector2.zero, Vector2.one, true);

        for (int y = m_Height - 1; y > -1; y--) // top to bpttom
        {
            for (int x = m_Width - 1; x > -1; x--) // right to left
            {
                if (HasPixel(x, y))
                {
                    if (x == 0 || !HasPixel(x - 1, y))
                        AddEdge(x, y, Edge.left);

                    if (x == m_Width - 1 || !HasPixel(x + 1, y))
                        AddEdge(x, y, Edge.right);

                    if (y == 0 || !HasPixel(x, y - 1))
                        AddEdge(x, y, Edge.bottom);

                    if (y == m_Height - 1 || !HasPixel(x, y + 1))
                        AddEdge(x, y, Edge.top);
                }
            }
        }
        var mesh = new Mesh();
        mesh.vertices = m_Vertices.ToArray();
        mesh.normals = m_Normals.ToArray();
        mesh.uv = m_TexCoords.ToArray();
        int[] quads = new int[m_Vertices.Count];
        for (int i = 0; i < quads.Length; i++)
            quads[i] = i;
        mesh.SetIndices(quads, MeshTopology.Quads, 0);
        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshRenderer>().material = spriteMat;
        transform.localScale = new Vector3(1, 1, 1);
    }
}
