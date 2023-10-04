using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Space]
    [Header("RaycastComponents")]
    [SerializeField]
    private GraphicRaycaster raycaster;

    [SerializeField]
    private PointerEventData pointerEventData;

    [SerializeField]
    private EventSystem eventSystem;

    private GameObject enemyObj;
    private Enemy enemy;
    private int gold;
    private int minDamage;
    private int maxDamage;
    private float attackDelay;
    private float lastAttackTime;
    List<RaycastResult> results = new List<RaycastResult>();

    public void Init(Balance balanceData)
    {
        gold = PlayerPrefs.GetInt("PlayerGold");
        minDamage = balanceData.minDamage;
        maxDamage = balanceData.maxDamage;
        attackDelay = balanceData.attackDelay;
    }

    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastAttackTime >= attackDelay)
            {
                lastAttackTime = Time.time;
                CheckClick();
            }
        }
    }

    private void CheckClick()
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;
        results.Clear();
        raycaster.Raycast(pointerEventData, results);

        if (results.Count > 0)
        {
            enemyObj = results[0].gameObject;
            if (enemyObj && enemyObj.CompareTag("Enemy"))
            {
                if (enemyObj.TryGetComponent<Enemy>(out enemy))
                {
                    Debug.Log("clickEnemy");
                    enemy.GetHit(Random.Range(minDamage, maxDamage + 1));
                    enemy = null;
                }
            }
        }
    }

    public void AddReward(int reward)
    {
        gold += reward;

        PlayerPrefs.SetInt("PlayerGold", gold);
        PlayerPrefs.Save();
    }
}
