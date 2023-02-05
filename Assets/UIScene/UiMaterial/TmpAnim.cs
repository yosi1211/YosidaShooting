using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TmpAnim : MonoBehaviour
{
   

    [SerializeField] private TextMeshProUGUI text;



    // Start is called before the first frame update
    private void Start()
    {
        DOTweenTMPAnimator animator = new DOTweenTMPAnimator(text);
        var sequence = DOTween.Sequence();
        sequence.SetLoops(-1);//無限ループ設定

        //一文字ずつにアニメーション設定
        var duration = 0.2f;//1回辺りのTween時間
        for (int i = 0; i < animator.textInfo.characterCount; ++i)
        {
            sequence.Join(DOTween.Sequence()
              //上に移動して戻る
              .Append(animator.DOOffsetChar(i, animator.GetCharOffset(i) + new Vector3(0, 30, 0), duration).SetEase(Ease.OutFlash, 2))
              //同時に1.2倍に拡大して戻る
              .Join(animator.DOScaleChar(i, 1.2f, duration).SetEase(Ease.OutFlash, 2))
              //同時に360度回転
              .Join(animator.DORotateChar(i, Vector3.forward * -360, duration, RotateMode.FastBeyond360).SetEase(Ease.OutFlash))
              //同時に色を黄色にして戻す
              .Join(animator.DOColorChar(i, Color.yellow, duration * 0.5f).SetLoops(2, LoopType.Yoyo))
              //アニメーション後、1秒のインターバル設定
              .AppendInterval(1f)
              //開始は0.15秒ずつずらす
              .SetDelay(0.15f * i)
            );
        }

    }
}
