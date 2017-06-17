using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class BloodSpawner : MonoBehaviour
{
    public GameObject RightBloodPrefab;
    public GameObject LeftBloodPrefab;
    public float BloodTimelife = 5.0f;

    public void BloodSpawn(Vector3 attackerPosition)
    {
        var targetPosition = transform.position;
        if (targetPosition.x < attackerPosition.x)
        {
            var blood = CreateBlood(RightBloodPrefab);
            blood.transform.position = targetPosition;
        }
        else
        {
            var blood = CreateBlood(LeftBloodPrefab);
            blood.transform.position = targetPosition;
        }
    }

    private GameObject CreateBlood(GameObject prefab)
    {
        GameObject bloodInstance = Instantiate(prefab);
        StartCoroutine(BloodFade(BloodTimelife, bloodInstance.GetComponent<SpriteRenderer>()));
        return bloodInstance;
    }

    private IEnumerator BloodFade(float duration, SpriteRenderer render)
    {
        while (duration > 0)
        {
            yield return null;
            duration -= Time.deltaTime;
            render.color = Color.Lerp(render.color, new Color(render.color.r, render.color.g, render.color.b, 0), Time.deltaTime);
        }
        Destroy(render.gameObject);
    }

    #region TEST
    [ContextMenu("Attack Left")]
    public void AttackLeft()
    {
        Vector3 attackerPosition = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        BloodSpawn(attackerPosition);
    }

    [ContextMenu("Attack Right")]
    public void AttackRight()
    {
        Vector3 attackerPosition = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        BloodSpawn(attackerPosition);
    }
    #endregion
}
