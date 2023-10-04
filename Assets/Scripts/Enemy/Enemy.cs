using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public event UnityAction EnemyKilled;

    [SerializeField]
    private float _hp;

    private Animator animator;
    private Image image;

    public float HP
    {
        private set
        {
            _hp = value;
            if (_hp <= 0)
            {
                Kill();
            }
        }
        get { return _hp; }
    }

    public void Init(float startHp)
    {
        HP = startHp;
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    public void GetHit(float damage)
    {
        HP -= damage;
        animator.SetTrigger("GetHit");
    }

    private void Kill()
    {
        image.raycastTarget = false;
        animator.SetTrigger("Death");
        EnemyKilled?.Invoke();
    }
}
