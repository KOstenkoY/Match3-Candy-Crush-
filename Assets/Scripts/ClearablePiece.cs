using System.Collections;
using UnityEngine;

namespace Match3
{
    public class ClearablePiece : MonoBehaviour
    {
        [SerializeField] private AnimationClip _clearAnimation;
         
        public bool IsBeingCleared { get; private set; }

        protected GamePiece _piece;

        private void Awake()
        {
            _piece = GetComponent<GamePiece>();
        }

        public virtual void Clear()
        {
            _piece.GameGridRef.Level.OnPieceCleared(_piece);
            IsBeingCleared = true;
            StartCoroutine(ClearCoroutine());
        }

        private IEnumerator ClearCoroutine()
        {
            var animator = GetComponent<Animator>();

            if (animator)
            {
                animator.Play(_clearAnimation.name);

                yield return new WaitForSeconds(_clearAnimation.length);

                Destroy(gameObject);
            }
        }
    }
}
