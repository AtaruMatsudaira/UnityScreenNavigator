using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace Demo.Subsystem.PresentationFramework.UnityScreenNavigatorExtensions
{
    public abstract class ModalPresenter<TModal> : Presenter<TModal>, IModalPresenter where TModal : Modal
    {
        protected ModalPresenter(TModal view) : base(view)
        {
            View = view;
        }

        private TModal View { get; }

#if USN_USE_ASYNC_METHODS
        Task IModalLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View);
        }
#elif USN_USE_UNITASK
        UniTask IModalLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View);
        }
#else
        IEnumerator IModalLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View);
        }
#endif

#if USN_USE_ASYNC_METHODS
        Task IModalLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View);
        }
#elif USN_USE_UNITASK
        UniTask IModalLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View);
        }
#else
        IEnumerator IModalLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View);
        }
#endif

        void IModalLifecycleEvent.DidPushEnter()
        {
            ViewDidPushEnter(View);
        }

#if USN_USE_ASYNC_METHODS
        Task IModalLifecycleEvent.WillPushExit()
        {
            return ViewWillPushExit(View);
        }
#elif USN_USE_UNITASK
        UniTask IModalLifecycleEvent.WillPushExit()
        {
            return ViewWillPushExit(View);
        }
#else
        IEnumerator IModalLifecycleEvent.WillPushExit()
        {
            return ViewWillPushExit(View);
        }
#endif

        void IModalLifecycleEvent.DidPushExit()
        {
            ViewDidPushExit(View);
        }

#if USN_USE_ASYNC_METHODS
        Task IModalLifecycleEvent.WillPopEnter()
        {
            return ViewWillPopEnter(View);
        }
#elif USN_USE_UNITASK
        UniTask IModalLifecycleEvent.WillPopEnter()
        {
            return ViewWillPopEnter(View);
        }
#else
        IEnumerator IModalLifecycleEvent.WillPopEnter()
        {
            return ViewWillPopEnter(View);
        }
#endif

        void IModalLifecycleEvent.DidPopEnter()
        {
            ViewDidPopEnter(View);
        }

#if USN_USE_ASYNC_METHODS
        Task IModalLifecycleEvent.WillPopExit()
        {
            return ViewWillPopExit(View);
        }
#elif USN_USE_UNITASK
        UniTask IModalLifecycleEvent.WillPopExit()
        {
            return ViewWillPopExit(View);
        }
#else
        IEnumerator IModalLifecycleEvent.WillPopExit()
        {
            return ViewWillPopExit(View);
        }
#endif

        void IModalLifecycleEvent.DidPopExit()
        {
            ViewDidPopExit(View);
        }

#if USN_USE_ASYNC_METHODS
        Task IModalLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View);
        }
#elif USN_USE_UNITASK
        UniTask IModalLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View);
        }
#else
        IEnumerator IModalLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View);
        }
#endif

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewDidLoad(TModal view)
        {
            return Task.CompletedTask;
        }
#elif USN_USE_UNITASK
        protected virtual UniTask ViewDidLoad(TModal view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewDidLoad(TModal view)
        {
            yield break;
        }
#endif


#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewWillPushEnter(TModal view)
        {
            return Task.CompletedTask;
        }
#elif USN_USE_UNITASK
        protected virtual UniTask ViewWillPushEnter(TModal view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewWillPushEnter(TModal view)
        {
            yield break;
        }
#endif

        protected virtual void ViewDidPushEnter(TModal view)
        {
        }

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewWillPushExit(TModal view)
        {
            return Task.CompletedTask;
        }
#elif USN_USE_UNITASK
        protected virtual UniTask ViewWillPushExit(TModal view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewWillPushExit(TModal view)
        {
            yield break;
        }
#endif

        protected virtual void ViewDidPushExit(TModal view)
        {
        }

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewWillPopEnter(TModal view)
        {
            return Task.CompletedTask;
        }
#elif USN_USE_UNITASK
        protected virtual UniTask ViewWillPopEnter(TModal view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewWillPopEnter(TModal view)
        {
            yield break;
        }
#endif

        protected virtual void ViewDidPopEnter(TModal view)
        {
        }

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewWillPopExit(TModal view)
        {
            return Task.CompletedTask;
        }
#elif USN_USE_UNITASK
        protected virtual UniTask ViewWillPopExit(TModal view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewWillPopExit(TModal view)
        {
            yield break;
        }
#endif

        protected virtual void ViewDidPopExit(TModal view)
        {
        }

#if USN_USE_ASYNC_METHODS
        protected virtual Task ViewWillDestroy(TModal view)
        {
            return Task.CompletedTask;
        }
#elif USN_USE_UNITASK
        protected virtual UniTask ViewWillDestroy(TModal view)
        {
            return UniTask.CompletedTask;
        }
#else
        protected virtual IEnumerator ViewWillDestroy(TModal view)
        {
            yield break;
        }
#endif

        protected override void Initialize(TModal view)
        {
            // The lifecycle event of the view will be added with priority 0.
            // Presenters should be processed after the view so set the priority to 1.
            view.AddLifecycleEvent(this, 1);
        }

        protected override void Dispose(TModal view)
        {
            view.RemoveLifecycleEvent(this);
        }
    }
}