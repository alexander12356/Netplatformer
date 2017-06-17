using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class FatalityManager : MonoBehaviour
    {
        private static FatalityManager m_Instance;

        public GameObject fatalityAnimator;
        Animator m_Animator = new Animator();

        public static FatalityManager Instance()
        {
            return m_Instance;
        }

        private void Awake()
        {
            if (m_Instance != null)
            {
                return;
            }
            else
            {
                m_Instance = this;
            }
        }

        public void PlayFatality(GameObject winner, GameObject loser, Transform holderParent = null)
        {
            //CharacterCompositor winnerCharacter = winner.GetComponent<CharacterCompositor>(); //TODO взять другой класс
            //CharacterCompositor loserCharacter = loser.GetComponent<CharacterCompositor>();
			
            if (holderParent != null)
				fatalityAnimator.gameObject.transform.SetParent(holderParent, false);
			
			winner.transform.SetParent(fatalityAnimator.gameObject.transform, false);
			loser.transform.SetParent(fatalityAnimator.gameObject.transform, false);

            GameObject _delta = Instantiate(fatalityAnimator) as GameObject;
            m_Animator = _delta.GetComponent <Animator > ();
            m_Animator.SetTrigger("Fatality"); //TODO тип оружия
        }

        public void StopFatality()
        {
            m_Animator.StopPlayback();
        }
    }
}