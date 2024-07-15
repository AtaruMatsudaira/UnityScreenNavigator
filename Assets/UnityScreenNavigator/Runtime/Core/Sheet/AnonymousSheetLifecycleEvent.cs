using System;
using System.Collections.Generic;
#if USN_USE_ASYNC_METHODS
using System.Threading.Tasks;
using System.Linq;
#elif USN_USE_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Collections;
#endif

namespace UnityScreenNavigator.Runtime.Core.Sheet
{
    public sealed class AnonymousSheetLifecycleEvent : ISheetLifecycleEvent
    {
#if USN_USE_ASYNC_METHODS
        public AnonymousSheetLifecycleEvent(Func<Task> initialize = null,
            Func<Task> onWillEnter = null, Action onDidEnter = null,
            Func<Task> onWillExit = null, Action onDidExit = null,
            Func<Task> onCleanup = null)
#elif USN_USE_UNITASK
        public AnonymousSheetLifecycleEvent(Func<UniTask> initialize = null,
            Func<UniTask> onWillEnter = null, Action onDidEnter = null,
            Func<UniTask> onWillExit = null, Action onDidExit = null,
            Func<UniTask> onCleanup = null)
#else
        public AnonymousSheetLifecycleEvent(Func<IEnumerator> initialize = null,
            Func<IEnumerator> onWillEnter = null, Action onDidEnter = null,
            Func<IEnumerator> onWillExit = null, Action onDidExit = null,
            Func<IEnumerator> onCleanup = null)
#endif
        {
            if (initialize != null)
                OnInitialize.Add(initialize);

            if (onWillEnter != null)
                OnWillEnter.Add(onWillEnter);

            OnDidEnter = onDidEnter;

            if (onWillExit != null)
                OnWillExit.Add(onWillExit);

            OnDidExit = onDidExit;

            if (onCleanup != null)
                OnCleanup.Add(onCleanup);
        }

#if USN_USE_ASYNC_METHODS
        public List<Func<Task>> OnInitialize { get; } = new List<Func<Task>>();
        public List<Func<Task>> OnWillEnter { get; } = new List<Func<Task>>();
        public List<Func<Task>> OnWillExit { get; } = new List<Func<Task>>();
        public List<Func<Task>> OnCleanup { get; } = new List<Func<Task>>();
#elif USN_USE_UNITASK
        public List<Func<UniTask>> OnInitialize { get; } = new List<Func<UniTask>>();
        public List<Func<UniTask>> OnWillEnter { get; } = new List<Func<UniTask>>();
        public List<Func<UniTask>> OnWillExit { get; } = new List<Func<UniTask>>();
        public List<Func<UniTask>> OnCleanup { get; } = new List<Func<UniTask>>();
#else
        public List<Func<IEnumerator>> OnInitialize { get; } = new List<Func<IEnumerator>>();
        public List<Func<IEnumerator>> OnWillEnter { get; } = new List<Func<IEnumerator>>();
        public List<Func<IEnumerator>> OnWillExit { get; } = new List<Func<IEnumerator>>();
        public List<Func<IEnumerator>> OnCleanup { get; } = new List<Func<IEnumerator>>();
#endif

#if USN_USE_ASYNC_METHODS
        Task ISheetLifecycleEvent.Initialize()
        {
            return Task.WhenAll(OnInitialize.Select(x => x.Invoke()));
        }
#elif USN_USE_UNITASK
        UniTask ISheetLifecycleEvent.Initialize()
        {
            return UniTask.WhenAll(OnInitialize.Select(x => x.Invoke()));
        }
#else
        IEnumerator ISheetLifecycleEvent.Initialize()
        {
            foreach (var onInitialize in OnInitialize)
                yield return onInitialize.Invoke();
        }
#endif


#if USN_USE_ASYNC_METHODS
        Task ISheetLifecycleEvent.WillEnter()
        {
            return Task.WhenAll(OnWillEnter.Select(x => x.Invoke()));
        }
#elif USN_USE_UNITASK
        UniTask ISheetLifecycleEvent.WillEnter()
        {
            return UniTask.WhenAll(OnWillEnter.Select(x => x.Invoke()));
        }
#else
        IEnumerator ISheetLifecycleEvent.WillEnter()
        {
            foreach (var onWillEnter in OnWillEnter)
                yield return onWillEnter.Invoke();
        }
#endif

        void ISheetLifecycleEvent.DidEnter()
        {
            OnDidEnter?.Invoke();
        }


#if USN_USE_ASYNC_METHODS
        Task ISheetLifecycleEvent.WillExit()
        {
            return Task.WhenAll(OnWillExit.Select(x => x.Invoke()));
        }
#elif USN_USE_UNITASK
        UniTask ISheetLifecycleEvent.WillExit()
        {
            return UniTask.WhenAll(OnWillExit.Select(x => x.Invoke()));
        }
#else
        IEnumerator ISheetLifecycleEvent.WillExit()
        {
            foreach (var onWillExit in OnWillExit)
                yield return onWillExit.Invoke();
        }
#endif

        void ISheetLifecycleEvent.DidExit()
        {
            OnDidExit?.Invoke();
        }


#if USN_USE_ASYNC_METHODS
        Task ISheetLifecycleEvent.Cleanup()
        {
            return Task.WhenAll(OnCleanup.Select(x => x.Invoke()));
        }
        #elif USN_USE_UNITASK
        UniTask ISheetLifecycleEvent.Cleanup()
        {
            return UniTask.WhenAll(OnCleanup.Select(x => x.Invoke()));
        }
#else
        IEnumerator ISheetLifecycleEvent.Cleanup()
        {
            foreach (var onCleanup in OnCleanup)
                yield return onCleanup.Invoke();
        }
#endif

        public event Action OnDidEnter;
        public event Action OnDidExit;
    }
}