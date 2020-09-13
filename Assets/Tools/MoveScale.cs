using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 从某个位置移动到指定位置的泡泡，并且逐渐变大
/// </summary>
public class MoveScale : MonoBehaviour
{
    public float ReachTime;
    public float EndScale;
    void Start()
    {
        transform.localScale = Vector3.one;
        transform.DOLocalMove(Vector3.up*3, ReachTime).SetEase(Ease.InOutQuad);
        transform.DOScale(Vector3.one* EndScale, ReachTime).OnComplete(() => { Debug.Log("Destory"); Destroy(this.gameObject); });
    }

}
