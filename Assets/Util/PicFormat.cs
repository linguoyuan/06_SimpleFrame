using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PicFormat
{

    public static byte[] Test()
    {
        string url2 = "2";//类型是Texture
        Texture2D texture = (Texture2D)Resources.Load(url2) as Texture2D;
        Sprite spritePic = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));//ok----------2
        if (texture == null)
        {
            Debug.Log("图片加载失败");
        }
        //spriteObj.GetComponent<SpriteRenderer>().sprite = spritePic;


        Texture2D myTexture = duplicateTexture(texture);
        //bytes = texture.EncodeToPNG();
        byte[]  bytes = myTexture.EncodeToJPG();
        Debug.Log("数组长度：" + bytes.Length);
        return bytes;
    }


    public static byte[] GetBytesFromLocalPic(Texture2D texture, out byte[] picBytes)
    {
        Texture2D myTexture = duplicateTexture(texture);
        picBytes = myTexture.EncodeToJPG();
        return picBytes;
    }

    //使得本地的Texture可读，必须经过转换，否则读取不了
    private static Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }

    //从WebCamTexture得到图片数组数据
    //public static void GetBytesFromWebCamTexture(WebCamTexture t, out byte[] picBytes)
    private static byte[] picBytes;
    public static byte[] GetBytesFromWebCamTexture(WebCamTexture t)
    {
        Texture2D t2d = new Texture2D(t.width, t.height, TextureFormat.ARGB32, true);
        //Debug.Log("width = " + t.width);
        //Debug.Log("height = " + t.height);
        //将WebCamTexture 的像素保存到texture2D中
        t2d.SetPixels(t.GetPixels());
        //t2d.ReadPixels(new Rect(200,200,200,200),0,0,false);
        t2d.Apply();
        //编码
        picBytes = t2d.EncodeToJPG();
        //Debug.Log("imageTytes.Length = " + picBytes.Length);

        //下面这两句必须要有
        Resources.UnloadUnusedAssets();//卸载未占用的asset资源
        System.GC.Collect();//回收内存
        return picBytes;
    }

    /// <summary>
    /// 截图保存到本地
    /// </summary>
    /// <param name="t"></param>
    /// <param name="path">默认在Application.persistentDataPath路径下的文件夹</param>
    /// <param name=""></param>
    public static void SanpShotToLocal(WebCamTexture t, string dir, string fileName)
    {
        Texture2D t2d = new Texture2D(t.width, t.height, TextureFormat.ARGB32, true);
        //将WebCamTexture 的像素保存到texture2D中
        t2d.SetPixels(t.GetPixels());
        //t2d.ReadPixels(new Rect(200,200,200,200),0,0,false);
        t2d.Apply();
        //编码
        byte[] imageTytes = t2d.EncodeToJPG();
        Debug.Log("imageTytes.Length = " + imageTytes.Length);

        //蘑菇机本地安卓下路径为：/Android/data/com.DMAI.FoxGame/files/
        string path = Path.Combine(Application.persistentDataPath, dir);
        string fllePath = Path.Combine(path, fileName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.Log("创建文件夹：" + path);
        }

        if (!File.Exists(fllePath))
        {
            File.Delete(fllePath);
            Debug.Log("删除文件：" + fllePath);
        }
        string savePath = string.Format("{0}/{1}.jpg", path, fileName);
        File.WriteAllBytes(savePath, imageTytes);
        Resources.UnloadUnusedAssets();//卸载未占用的asset资源
        System.GC.Collect();//回收内存
    }
}
