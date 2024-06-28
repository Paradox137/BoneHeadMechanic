using System;
using System.Collections;
using UnityEngine;

namespace BHMechanic.Code.ServiceModule
{
    public class TimerCoroutineService : IDisposable
    {
        private readonly MonoBehaviour _coroutineRunner;
        private readonly float _refreshTime;
        
        private event Action onTimerEnd;
        private event Action<float> onTick;
        
        public TimerCoroutineService(MonoBehaviour __coroutineRunner, float __refreshTime,
            Action __onTimerEndCallback, Action<float> __onTickCallback)
        {
            _coroutineRunner = __coroutineRunner;
            _refreshTime = __refreshTime;

            onTimerEnd += __onTimerEndCallback;
            onTick += __onTickCallback;
        }

        public void RunLoopTimer()
        {
            _coroutineRunner.StartCoroutine(StartLoopTimer());
        }

        private IEnumerator StartLoopTimer()
        {
            float counter = _refreshTime;
            
            while (counter >= 1)
            {
                onTick?.Invoke(counter);
                
                counter--;
                yield return new WaitForSeconds(1);
            }
            
            onTimerEnd?.Invoke();

            RunLoopTimer();
        }

        public void Dispose()
        {
            onTimerEnd = null;
            onTick = null;
        }
    }
}