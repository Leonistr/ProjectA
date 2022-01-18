using System.Collections;
using _Root.Scripts.Models.Obstacles;
using _Root.Scripts.Views;
using DG.Tweening;
using UnityEngine;

namespace _Root.Scripts.Controllers.Obstacles
{
    public class PikeController : ObstacleController
    {
        #region Constructor

        public PikeController(ObstacleView obstacleView, IObstacleModel obstacleModel) : base(obstacleView, obstacleModel)
        {
            _obstacleView.ConnectedCollider.OnTriggerCollide += PlayAnimation;
        }

        #endregion


        #region Methods

        private void PlayAnimation()
        {
            _obstacleView.ConnectedCollider.gameObject.SetActive(false);
            _obstacleView.gameObject.transform.DOMove(new Vector3(_obstacleView.gameObject.transform.position.x,
                _obstacleView.gameObject.transform.position.y + 1.5f), 0.5f).OnComplete(OffTrap);
        }
        
        private void OffTrap()
        {
            _obstacleView.StartCoroutine(OffTrapRoutine());
        }
        
        private IEnumerator OffTrapRoutine()
        {
            yield return new WaitForSeconds(_obstacleModel.Cooldown);
            
            _obstacleView.gameObject.transform.DOMove(new Vector3(_obstacleView.gameObject.transform.position.x,
                _obstacleView.gameObject.transform.position.y - 1.5f), 0.5f);
            _obstacleView.ConnectedCollider.gameObject.SetActive(true);
        }

        #endregion
        
        
    }
}