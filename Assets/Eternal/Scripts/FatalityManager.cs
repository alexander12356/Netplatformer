using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class FatalityManager : MonoBehaviour
    {
        private static FatalityManager m_Instance;

        private Animator _animator = new Animator();

        public static FatalityManager instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            m_Instance = this;
            _animator = GetComponent<Animator>();
        }

        public void PlayFatality(GameObject winner, GameObject loser, Transform holderParent = null)
        {
            CharacterState winnerCharacter = winner.GetComponent<CharacterState>(); //TODO взять другой класс
            CharacterState loserCharacter = loser.GetComponent<CharacterState>();

            //winnerCharacter.ChangeState(CharacterState.State.Fatality);
            //loserCharacter.ChangeState(CharacterState.State.Fatality);

            winnerCharacter.GetComponent<Animator>().enabled = false;
            loserCharacter.GetComponent<Animator>().enabled = false;

            winner.transform.SetParent(transform);
            loser.transform.SetParent(transform);
            
            _animator.Rebind();
            _animator.SetTrigger("Forwardstep"); //TODO тип оружия
        }

        public void StopFatality()
        {
            _animator.StopPlayback();
        }

        #region for test
        [Header("For test")]
        public GameObject winner;
        public GameObject loser;

        [ContextMenu("PlayFatality")]
        public void PlayFatality()
        {
            PlayFatality(winner, loser);
        }
        #endregion
    }
}