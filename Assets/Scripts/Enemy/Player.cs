using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("PlayerStats")]
    [SerializeField]
    private int minDamage;

    [SerializeField]
    private int maxDamage;

    [SerializeField]
    private float attackDelay;

    private int gold;

    private GameObject enemyObj;
    private Enemy enemy;

    [Space]
    [Header("RaycastComponents")]
    [SerializeField]
    private GraphicRaycaster raycaster;

    [SerializeField]
    private PointerEventData pointerEventData;

    [SerializeField]
    private EventSystem eventSystem;

    List<RaycastResult> results = new List<RaycastResult>();
    private float lastAttackTime;

    private void Start()
    {
        gold = PlayerPrefs.GetInt("PlayerGold");
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
