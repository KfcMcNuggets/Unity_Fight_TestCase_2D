using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public event UnityAction EnemyKilled;

    [SerializeField]
    private int _hp;

    private int maxHp;
    private HPBar hpBar;
    private Animator animator;
    private Image image;

    public int HP
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

    public void Init(int startHp)
    {
        hpBar = GetComponentInChildren<HPBar>();
        maxHp = startHp;
        HP = maxHp;
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    public void GetHit(int damage)
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

    public void UpdateHp()
    {
        hpBar.UpdateHp(_hp, maxHp);
    }
}
