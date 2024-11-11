using DG.Tweening;
using UnityEngine;

public class AnimationsLibrary:MonoBehaviour {
    [SerializeField] private Transform cubeTransform;
    [SerializeField] private Vector3 vector;

    public void KillAllTweens() {
        DOTween.KillAll();
    }

    public void ResetTransform() {
        cubeTransform.position = new Vector3(-3, 0,0);
        cubeTransform.rotation = Quaternion.identity;
        cubeTransform.localScale = Vector3.one;
    }

    public void SimpleMove() {
        cubeTransform.DOMove(vector, 1);
    }

    public void YoyoMove() {
        cubeTransform.DOMove(vector, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    public void YoyoRotate() {
        cubeTransform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }

    public void YoyoScale() {
        cubeTransform.DOScale(new Vector3(1.2f, 1.2f, 1.2f),.5f).SetLoops(-1,LoopType.Yoyo);
    }

    public void ChangeTransformParams() {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(cubeTransform.DOMove(new Vector3(3, 0, 0), 2f));
        sequence.Join(cubeTransform.DOScale(new Vector3(2, 2, 2), 2f));
        sequence.Join(cubeTransform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360));
    }

    public void RevealEffect() {
        cubeTransform.localScale=Vector3.zero;
        cubeTransform.DOScale(Vector3.one,1).SetEase(Ease.OutBounce);
    }

    public void Chain() {
        Sequence sequence= DOTween.Sequence();
        sequence.Append(cubeTransform.DOMoveX(3, 1));
        sequence.Append(cubeTransform.DOMoveY(2, 1));
        sequence.Append(cubeTransform.DOScale(2, 1));
        sequence.Append(cubeTransform.DORotate(new Vector3(0, 180, 0), 1));
    }

    public void Random() {
        Sequence sequence = DOTween.Sequence();

        for (int i = 0; i < 5; i++) {
            sequence.Append(cubeTransform.DOMove(new Vector3(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(0, 5), UnityEngine.Random.Range(-5, 5)), 0.5f));
            sequence.Join(cubeTransform.DOScale(UnityEngine.Random.Range(0.5f, 1.5f), 0.5f));
        }

        //sequence.SetLoops(-1);
    }


}
