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
        sequence.SetLoops(-1);//�������[�v�ݒ�

        //�ꕶ�����ɃA�j���[�V�����ݒ�
        var duration = 0.2f;//1��ӂ��Tween����
        for (int i = 0; i < animator.textInfo.characterCount; ++i)
        {
            sequence.Join(DOTween.Sequence()
              //��Ɉړ����Ė߂�
              .Append(animator.DOOffsetChar(i, animator.GetCharOffset(i) + new Vector3(0, 30, 0), duration).SetEase(Ease.OutFlash, 2))
              //������1.2�{�Ɋg�債�Ė߂�
              .Join(animator.DOScaleChar(i, 1.2f, duration).SetEase(Ease.OutFlash, 2))
              //������360�x��]
              .Join(animator.DORotateChar(i, Vector3.forward * -360, duration, RotateMode.FastBeyond360).SetEase(Ease.OutFlash))
              //�����ɐF�����F�ɂ��Ė߂�
              .Join(animator.DOColorChar(i, Color.yellow, duration * 0.5f).SetLoops(2, LoopType.Yoyo))
              //�A�j���[�V������A1�b�̃C���^�[�o���ݒ�
              .AppendInterval(1f)
              //�J�n��0.15�b�����炷
              .SetDelay(0.15f * i)
            );
        }

    }
}
