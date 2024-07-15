using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Page;

namespace Demo.Subsystem.PresentationFramework.UnityScreenNavigatorExtensions
{
    public abstract class PagePresenter<TPage> : Presenter<TPage>, IPagePresenter where TPage : Page
    {
        protected PagePresenter(TPage view) : base(view)
        {
            View = view;
        }

        private TPage View { get; }

#if USN_USE_ASYNC_METHODS
        Task IPageLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View);
        }
#elif USN_USE_UNITASK
        UniTask IPageLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View);
        }
#else
        IEnumerator IPageLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View);
        }
#endif

#if USN_USE_ASYNC_METHODS
        Task IPageLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View);
        }
#elif USN_USE_UNITASK
        UniTask IPageLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View);
        }
#else
        IEnumerator IPageLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View);
        }
#endif

        void IPageLifecycleEvent.DidPushEnter()
        {
            ViewDidPushEnter(View);
        }

#if USN_USE_ASYNC_METHODS
        Task IPageLifecycleEvent.WillPushExit()
        {
            return ViewWillPushExit(View);
        }
#elif USN_USE_UNITASK
        UniTask IPageLifecycleEvent.WillPushExit()
        {
            return ViewWillPopExit(View);
        }
#else
        IEnumerator IPageLifecycleEvent.WillPushExit()
        {
            return ViewWillPushExit(View);
        }
#endif

        void IPageLifecycleEvent.DidPushExit()
        {
            ViewDidPushExit(View);
        }

#if USN_USE_ASYNC_METHODS
        Task IPageLifecycleEvent.WillPopEnter()
        {
            return ViewWillPopEnter(View);
        }
#elif USN_USE_UNITASK
        UniTask IPageLifecycleEvent.WillPopEnter()
        {
            return ViewWillPopEnter(View);
        }
#else
        IEnumerator IPageLifecycleEvent.WillPopEnter()
        {
            return ViewWillPopEnter(View);
        }
#endif

        void IPageLifecycleEvent.DidPopEnter()
        {
            ViewDidPopEnter(View);
        }

#if USN_USE_ASYNC_METHODS
        Task IPageLifecycleEvent.WillPopExit()
        {
            return ViewWillPopExit(View);
        }
#elif USN_USE_UNITASK
        UniTask IPageLifecycleEvent.WillPopExit()
        {
            return ViewWillPopExit(View);
        }
#else
        IEnumerator IPageLifecycleEvent.WillPopExit()
        {
            return ViewWillPopExit(View);
        }
#endif

        void IPageLifecycleEvent.DidPopExit()
        {
            ViewDidPopExit(View);
        }

#if USN_USE_ASYNC_METHODS
        Task IPageLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View);
        }
        
#elif USN_USE_UNITASK
        UniTask IPageLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View);
        }
#else
        IEnumerator IPageLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View);
        }
#endif

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewDidLoad(TPage view)
        {
            return Task.CompletedTask;
        }
#elif USN_USE_UNITASK
        protected virtual UniTask ViewDidLoad(TPage view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewDidLoad(TPage view)
        {
            yield break;
        }
#endif

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewWillPushEnter(TPage view)
        {
            return Task.CompletedTask;
        }

#elif USN_USE_UNITASK
        protected virtual UniTask ViewWillPushEnter(TPage view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewWillPushEnter(TPage view)
        {
            yield break;
        }
#endif

        protected virtual void ViewDidPushEnter(TPage view)
        {
        }

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewWillPushExit(TPage view)
        {
            return Task.CompletedTask;
        }
#elif USN_USE_UNITASK
        protected virtual UniTask ViewWillPushExit(TPage view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewWillPushExit(TPage view)
        {
            yield break;
        }
#endif

        protected virtual void ViewDidPushExit(TPage view)
        {
        }

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewWillPopEnter(TPage view)
        {
            return Task.CompletedTask;
        }
#elif USN_USE_UNITASK
        protected virtual UniTask ViewWillPopEnter(TPage view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewWillPopEnter(TPage view)
        {
            yield break;
        }
#endif

        protected virtual void ViewDidPopEnter(TPage view)
        {
        }

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewWillPopExit(TPage view)
        {
            return Task.CompletedTask;
        }
#elif USN_USE_UNITASK
        protected virtual UniTask ViewWillPopExit(TPage view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewWillPopExit(TPage view)
        {
            yield break;
        }
#endif

        protected virtual void ViewDidPopExit(TPage view)
        {
        }

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewWillDestroy(TPage view)
        {
            return Task.CompletedTask;
        }

#elif USN_USE_UNITASK
        protected virtual UniTask ViewWillDestroy(TPage view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewWillDestroy(TPage view)
        {
            yield break;
        }
#endif

        protected override void Initialize(TPage view)
        {
            // The lifecycle event of the view will be added with priority 0.
            // Presenters should be processed after the view so set the priority to 1.
            view.AddLifecycleEvent(this, 1);
        }

        protected override void Dispose(TPage view)
        {
            view.RemoveLifecycleEvent(this);
        }
    }
}
