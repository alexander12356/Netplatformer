using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class FatalityManager : MonoBehaviour
    {
        private static FatalityManager m_Instance;

        public GameObject FatalityAnimator;
        Animator _animator = new Animator();

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
            Debug.Log("Play fatality");
            CharacterState winnerCharacter = winner.GetComponent<CharacterState>(); //TODO взять другой класс
            CharacterState loserCharacter = loser.GetComponent<CharacterState>();

            winnerCharacter.ChangeState(CharacterState.State.Fatality);
            loserCharacter.ChangeState(CharacterState.State.Fatality);

            if (holderParent != null)
                FatalityAnimator.gameObject.transform.SetParent(holderParent, false);

			GameObject _delta = Instantiate(FatalityAnimator) as GameObject;
			_animator = _delta.GetComponent<Animator>();
			_animator.SetTrigger("Fatality"); //TODO тип оружия

            winner.transform.SetParent(_delta.gameObject.transform, false);
            loser.transform.SetParent(_delta.gameObject.transform, false);

        }

        public void StopFatality()
        {
            _animator.StopPlayback();
        }

        #region for test
        public GameObject winner;
        public GameObject loser;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)){
                PlayFatality(winner, loser);
            }
        }
        #endregion
    }
}